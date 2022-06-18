using UnityEngine;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.Core
{
    public class FlyCameraZone : MonoBehaviour 
    {
        SmoothFollowTarget _smoothFollowTarget;
        Collider _collider;
        private void Start()
        {
            _smoothFollowTarget = GetComponentInChildren<SmoothFollowTarget>();
            if (TryGetComponent(out _collider))
            {
                if (_collider.isTrigger) return;
                Debug.LogWarning($"Camera zone '{name}' is not set as trigger!");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            PlayerCameraController playerCamera = other.GetComponent<PlayerCameraController>();
            if (!playerCamera) return;

            playerCamera.flyConfig.followTarget = _smoothFollowTarget.transform;
            playerCamera.camMode = CameraMode.FlyCam;
            _smoothFollowTarget.Target = playerCamera.transform;
        }
        private void OnTriggerExit(Collider other)
        {
            PlayerCameraController playerCamera = other.GetComponent<PlayerCameraController>();
            if (!playerCamera) return;

            playerCamera.camMode = CameraMode.Player;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red * new Color(1, 1, 1, 0.1f);
            Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
            UnityEditor.Handles.color = Color.white;
            UnityEditor.Handles.Label(transform.position + GetComponent<BoxCollider>().center, gameObject.name);
        }
#endif
    }
}