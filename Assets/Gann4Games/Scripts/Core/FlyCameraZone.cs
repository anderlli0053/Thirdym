using UnityEngine;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.Core
{
    public class FlyCameraZone : MonoBehaviour 
    {

        PlayerCameraController playerCam;
        SmoothFollowTarget target;
        public bool cameraActive;
        private void Start()
        {
            target = GetComponentInChildren<SmoothFollowTarget>();
            if (GetComponent<Collider>().isTrigger == false)
                GetComponent<Collider>().isTrigger = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerCameraController>())
            {
                playerCam = other.GetComponent<PlayerCameraController>();
                playerCam.flyConfig.followTarget = target.transform;
                playerCam.camMode = CameraMode.FlyCam;
                target.Target = playerCam.transform;
                cameraActive = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.GetComponent<PlayerCameraController>())
            {
                playerCam.camMode = CameraMode.Player;
                cameraActive = false;
            }
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