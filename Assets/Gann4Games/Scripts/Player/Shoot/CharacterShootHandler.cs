using System.Collections;
using UnityEngine;
using Gann4Games.Thirdym.Utility;
using Gann4Games.Thirdym.ScriptableObjects;

public class CharacterShootHandler : MonoBehaviour {

    
    Animator _weaponAnimator;
    Rigidbody _handRigidbody;
    TimerTool _timer = new TimerTool();

    CharacterCustomization _character;

    SO_WeaponPreset _weapon => _character.EquipmentController.currentWeapon;

    float _repeatTime => _weapon.repeatTime;
    public Vector3 HitPosition
    {
        get
        {
            if (Physics.Raycast(transform.position, transform.right, out RaycastHit hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);
                return hit.point;
            }
            else
            {
                return transform.position;
            }
        }
    }
    private void Awake()
    {
        _character = GetComponentInParent<CharacterCustomization>();
    }
    private void Start()
    {
        _weaponAnimator = _character.Animator;
        _handRigidbody = _character.baseBody.rightHand.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_weapon == null) return;

        if (_timer.GeTimeOut != _repeatTime) 
            _timer.SetTimeOut(_repeatTime);

        if(!_timer.IsTimeOut()) 
        {
            _timer.CountTime();
            if(!_character.isNPC) MainHUDHandler.instance.crosshairImage.fillAmount = _timer.currentTime / _weapon.repeatTime;
        }
    }
    public void StartShooting()
    {
        if (_timer.IsTimeOut() && _weapon != null)
        {
            _timer.ResetTime();
            _weaponAnimator?.SetBool("Shoot", false);
            Shoot();
        }
    }
    void Shoot()
    {
        _character.SoundSource.PlayOneShot(_weapon.sfxShoot);
        if(_character.EquipmentController.currentWeapon.useRecoil)
            _character.baseBody.rightElbow.GetComponent<Rigidbody>().AddForce(PlayerCameraController.instance.activeCamera.transform.forward * -(500 * (_weapon.damage / 10)));

        CreateBullets();
            
        if (_weapon.useReload) StartCoroutine(ReloadWeapon());
        _weaponAnimator?.SetBool("Shoot", true);
    }
    void CreateBullets()
    {
        Vector3 shootPosition = transform.position + transform.TransformDirection(_weapon.shootPoint);

        for (int i = 0; i < _weapon.bulletCount; i++)
        {
            GameObject _bulletPrefab = Instantiate(_weapon.bulletType.bullet, shootPosition, transform.rotation, null);
            _bulletPrefab.transform.Rotate(Random.Range(-_weapon.bulletSpread, _weapon.bulletSpread), Random.Range(-_weapon.bulletSpread, _weapon.bulletSpread), 0);

            Bullet _bulletComponent = _bulletPrefab.GetComponent<Bullet>();
            _bulletComponent.user = _character.transform;
            _bulletComponent.weapon = _weapon;
        }
    }
    IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(_weapon.reloadStartDelay);
        _character.Animator.SetBool("WeaponReload", true);
        _character.SoundSource.PlayOneShot(_weapon.sfxReload);
        _weaponAnimator?.SetBool("WeaponReload", true);

        yield return new WaitForSeconds(_weapon.reloadDuration);
        _character.Animator.SetBool("WeaponReload", false);
        _weaponAnimator?.SetBool("WeaponReload", false);
    }
}
