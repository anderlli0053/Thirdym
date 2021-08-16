using System.Collections;
using UnityEngine;
using Gann4Games.Thirdym.Utility;
using Gann4Games.Thirdym.ScriptableObjects;

[System.Serializable]
public class PumpGunOptions
{
    public bool pumpAfterShoot;
    public float pumpStartDelay;
    public float pumpDuration;
}
public class ActionShoot : MonoBehaviour {

    [SerializeField] SO_BulletPreset preset;

    Animator _anim;
    Rigidbody _handRigidbody;
    CharacterCustomization _character;
    readonly TimerTool _timer = new TimerTool();

    GameObject _muzzleFlash;
    ParticleSystem _muzzleParticle;

    public Vector3 HitPosition
    {
        get
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                return hit.point;
            }
            else
            {
                return transform.position;
            }
        }
    }

    private void Start()
    {
        _timer.SetTimeOut(preset.repeatTime);

        _anim = GetComponentInParent<Animator>();
        _handRigidbody = GetComponentInParent<Rigidbody>();

        _muzzleFlash = Instantiate(preset.muzzleFlash);
        _muzzleParticle = _muzzleFlash.GetComponent<ParticleSystem>();
        _muzzleParticle.startColor = preset.bulletColor;

        _character = GetComponentInParent<CharacterCustomization>();
    }
    private void Update()
    {
        if(!_timer.IsTimeOut()) 
        {
            _timer.CountTime();
            if(!_character.isNPC) MainHUDHandler.instance.crosshairImage.fillAmount = _timer.currentTime / preset.repeatTime;
        }
    }
    public void StartShooting()
    {
        if (_timer.IsTimeOut()) _timer.ResetTime();
        if (_timer.currentTime == 0)
        {
            Shoot();
            if (_anim != null) _anim.SetBool("Shoot", false);
        }
    }
    void Shoot()
    {
        if (gameObject.activeInHierarchy)
        {
            _character.SoundSource.PlayOneShot(preset.sfxShoot);

            _muzzleFlash.transform.position = transform.position;
            _muzzleFlash.transform.rotation = transform.rotation;

            if (_muzzleParticle.isPlaying) _muzzleParticle.Stop();
            _muzzleParticle.Play();

            _handRigidbody.AddForce(transform.forward * -(500 * (preset.damage / 10)));

            StartCoroutine(DisableMuzzleFlash(preset.muzzleDisableTime));

            CreateBullets();
            
            if (preset.PumpOptions.pumpAfterShoot) StartCoroutine(PumpGun());
            _anim?.SetBool("Shoot", true);
        }
    }
    void CreateBullets()
    {
        for (int i = 0; i < preset.bulletCount; i++)
        {
            GameObject _bulletPrefab = Instantiate(preset.bullet, transform.position + (transform.forward * 1 / 4), transform.rotation, null);
            _bulletPrefab.transform.Rotate(Random.Range(-preset.bulletSpread, preset.bulletSpread), Random.Range(-preset.bulletSpread, preset.bulletSpread), 0);

            Bullet _bulletComponent = _bulletPrefab.GetComponent<Bullet>();
            _bulletComponent.user = _character.transform;
            _bulletComponent.preset = preset;
        }
    }
    IEnumerator DisableMuzzleFlash(float time)
    {
        yield return new WaitForSeconds(time);
        if(_anim != null)
            _anim.SetBool("Shoot", false);
    }
    IEnumerator PumpGun()
    {
        yield return new WaitForSeconds(preset.PumpOptions.pumpStartDelay);
        _anim?.SetBool("Pump", true);
        _character.Animator.SetBool("Pump", true);
        _character.SoundSource.PlayOneShot(preset.sfxPump);

        yield return new WaitForSeconds(preset.PumpOptions.pumpDuration);
        _anim?.SetBool("Pump", false);
        _character.Animator.SetBool("Pump", false);
    }
}
