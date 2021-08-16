using UnityEngine;
using UnityEngine.Audio;
using UnityEditor;

namespace Gann4Games.Thirdym.Interactables
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody))]
    public class MovableObject : MonoBehaviour
    {
        public Transform objectToMove;
        public Vector3[] positions;
        [Tooltip("The index of 'positions' to follow.")]
        public int positionToFollow;
        [Tooltip("Speed in units per frame.")]
        public float speed = 0.05f;

        [Header("Audio")]
        public AudioMixerGroup output;
        [Range(0, 1)] public float spatialBlend = 1;
        public float maxDistance = 100;
        public AudioClip startSFX;
        public AudioClip stopSFX;

        AudioSource _soundSource;
        bool _moving;
        private void Start()
        {
            _soundSource = GetComponent<AudioSource>();
            _soundSource.outputAudioMixerGroup = output;
            _soundSource.spatialBlend = spatialBlend;
            _soundSource.maxDistance = maxDistance;
            for (int i = 0; i < positions.Length; i++)
                positions[i] = positions[i] + objectToMove.position;
        }
        private void FixedUpdate()
        {
            if (objectToMove.position != positions[positionToFollow])
            {
                if (_moving == false)
                {
                    _moving = true;
                    _soundSource.PlayOneShot(startSFX);
                }
                if (_moving)
                    objectToMove.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(objectToMove.position, positions[positionToFollow], speed * Time.timeScale));
            }
            else if (objectToMove.position == positions[positionToFollow])
            {
                if (_moving == true)
                {
                    _moving = false;
                    _soundSource.Stop();
                    _soundSource.PlayOneShot(stopSFX);
                }
            }
        }
        public void MoveAt(int position) => positionToFollow = position;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            MeshFilter mesh_filter = GetComponent<MeshFilter>();
            if (!objectToMove) Handles.Label(transform.position, "Parameter 'objectToMove' is empty!");
            if (positions.Length == 0) Handles.Label(transform.position, "Position array is empty! Set at least one point.");

            if (positions.Length > 0 && objectToMove)
            {
                for (int i = 0; i < positions.Length; i++)
                {
                    Gizmos.color = Color.green * new Color(1, 1, 1, 0.1f);

                    if (mesh_filter) Gizmos.DrawMesh(mesh_filter.mesh, -1, positions[i] + objectToMove.position, transform.rotation, transform.localScale);

                    Gizmos.color = Color.blue * new Color(1, 1, 1, 0.5f);
                    Gizmos.DrawCube(positions[i] + objectToMove.position, Vector3.one / 2);
                    Handles.color = Color.white;
                    Handles.Label(positions[i] + objectToMove.position, $"[{gameObject.name}] Position {i}");

                    Gizmos.color = Color.red;

                    if (i + 1 >= positions.Length)
                        continue;

                    Gizmos.DrawLine(positions[i] + objectToMove.position, positions[i + 1] + objectToMove.position);
                }
            }
        }
#endif
    }
}