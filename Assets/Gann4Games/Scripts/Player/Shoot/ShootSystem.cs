using UnityEngine;
public class ShootSystem : MonoBehaviour {
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
        }
    }
    public void Shoot()
    {
        if (!_character.isNPC && IngameMenuHandler.instance.paused) return;
        _shootScript.StartShooting();
    }
}
