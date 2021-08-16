using UnityEngine;
public class BillboardObject : MonoBehaviour
{
    Transform _mainCamera;
    private void Awake() => _mainCamera = Camera.main.transform;
    private void Update() => transform.LookAt(_mainCamera);
}
