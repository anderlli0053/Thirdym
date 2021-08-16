using UnityEngine;

public class LookAt : MonoBehaviour
{
    public enum LookAtUse
    {
        FollowTarget,
        CameraCenter
    }
    public LookAtUse UseMode;
    [Tooltip("Required only if 'FollowTarget' is set")]
    public Transform target;

    CharacterCustomization customizator;

    void Start()
    {
        customizator = PlayerCameraController.instance.character;
    }
    private void Update()
    {
        if (UseMode == LookAtUse.FollowTarget)
            transform.LookAt(target);
        else if (UseMode == LookAtUse.CameraCenter)
        {
            if (!customizator.HealthController.IsDead)
            {
                Transform camera = PlayerCameraController.instance.activeCamera.transform;
                transform.LookAt(camera.position + camera.forward * 100);
            }
        }
    }
}
