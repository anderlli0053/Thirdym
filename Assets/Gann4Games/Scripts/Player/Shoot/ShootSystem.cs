using UnityEngine;
public class ShootSystem : MonoBehaviour {
    RectTransform _crosshair;
    CharacterCustomization _character;
    Transform _user;

    CharacterShootHandler _shootScript;

    private void Awake()
    {
        _shootScript = GetComponentInChildren<CharacterShootHandler>();
        _character = GetComponent<CharacterCustomization>();
    }
    private void Start()
    {
        _user = transform;

        if (!_character.isNPC) _crosshair = MainHUDHandler.instance.crosshair;
    }
    private void Update()
    {
        bool isCharacterDead = _character.HealthController.IsDead;
        bool isCharacterDisarmed = _character.EquipmentController.disarmed;
        bool isCharacterNPC = _character.isNPC;
        bool isGamePaused = IngameMenuHandler.instance.paused;

        bool canShoot = !isCharacterDead && !isCharacterDisarmed && !isGamePaused && !isCharacterNPC;
        if (canShoot && InputHandler.instance.firing && InputHandler.instance.aiming)
        {
            _shootScript.StartShooting();
            Vector3 hitPosition = _shootScript.HitPosition;
            if (!_character.isNPC)
            {
                if (_character.CameraController.enabled)
                {
                    _crosshair.anchoredPosition = Vector2.Lerp(_crosshair.anchoredPosition,
                        CanvasToWorld.WorldToCanvasPosition(_crosshair.parent.GetComponent<RectTransform>(), _character.CameraController.activeCamera, hitPosition),
                        Time.deltaTime * 10);
                }
                else
                {
                    Camera[] newActiveCamera = FindObjectsOfType<Camera>();
                    for (int c = 0; c < newActiveCamera.Length; c++)
                    {
                        if (newActiveCamera[c].isActiveAndEnabled)
                        {
                            _crosshair.anchoredPosition = Vector2.Lerp(
                                _crosshair.anchoredPosition,
                                CanvasToWorld.WorldToCanvasPosition(_crosshair.parent.GetComponent<RectTransform>(), newActiveCamera[c], hitPosition),
                                Time.deltaTime * 10);
                        }
                    }
                }
            }
        }
    }
    public void Shoot()
    {
        if (!_character.isNPC && IngameMenuHandler.instance.paused) return;
        _shootScript.StartShooting();
    }
}
