using UnityEngine;
public class ShootSystem : MonoBehaviour {
    public bool canShoot;

    [SerializeField] ActionShoot[] shootScripts;

    RectTransform _crosshair;
    CharacterCustomization _character;
    Transform _user;
    private void Awake()
    {
        _character = GetComponent<CharacterCustomization>();
    }
    private void Start()
    {
        canShoot = true;
        _user = transform;
        shootScripts = transform.GetComponentsInChildren<ActionShoot>(true);

        if (!_character.isNPC) _crosshair = MainHUDHandler.instance.crosshair;
    }
    private void Update()
    {

        if (!_character.HealthController.IsDead && !IngameMenuHandler.instance.paused)
        {
            foreach (ActionShoot shootScript in shootScripts)
            {
                if (InputHandler.instance.firing && !_character.isNPC)
                    shootScript.StartShooting();
            }
            for (int i = 0; i < shootScripts.Length; i++)
            {
                if (shootScripts[i].gameObject.activeInHierarchy)
                {
                    Vector3 hitPosition = shootScripts[i].HitPosition;
                    Debug.DrawLine(shootScripts[i].transform.position, hitPosition);
                    if (!_character.isNPC)
                    {
                        if (_character.CameraController.enabled)
                            _crosshair.anchoredPosition = Vector2.Lerp(_crosshair.anchoredPosition,
                                CanvasToWorld.WorldToCanvasPosition(_crosshair.parent.GetComponent<RectTransform>(), _character.CameraController.activeCamera, hitPosition),
                                Time.deltaTime * 10);
                        else
                        {
                            Camera[] newActiveCamera = FindObjectsOfType<Camera>();
                            for(int c = 0; c < newActiveCamera.Length; c++)
                            {
                                if(newActiveCamera[c].isActiveAndEnabled)
                                {
                                    _crosshair.anchoredPosition = Vector2.Lerp(
                                        _crosshair.anchoredPosition,
                                        CanvasToWorld.WorldToCanvasPosition(_crosshair.parent.GetComponent<RectTransform>(), newActiveCamera[c], hitPosition), 
                                        Time.deltaTime*10);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    public void Shoot()
    {
        if (!_character.isNPC && IngameMenuHandler.instance.paused) return;
        foreach (ActionShoot shootscripts in shootScripts)
            shootscripts.StartShooting();
    }
}
