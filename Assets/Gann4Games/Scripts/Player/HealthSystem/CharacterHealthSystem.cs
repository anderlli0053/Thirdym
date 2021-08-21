using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Gann4Games.Thirdym.Utility;

public class CharacterHealthSystem : MonoBehaviour {
    public enum HealthStatus
    {
        Alive, Injuried, Unconcious, Dead
    }
    [HideInInspector] public HealthStatus playerLifeState;
    public List<CharacterBodypart> bodyParts;
    public bool HeavyHit;
    public bool Unconcious;
    public bool Dead;

    public EventHandler<OnDamageDealedArgs> OnDamageDealed;
    public class OnDamageDealedArgs
    {
        public Vector3 where;
    }

    CharacterCustomization _character;

    [SerializeField] UnityEvent OnInjury;
    [SerializeField] UnityEvent OnDeath;
    [SerializeField] UnityEvent OnResurrect;

    readonly TimerTool _timer = new TimerTool();

    float _health;
    float _maxHealth;
    float _injuryLevel;

    public float MaximumHealth { get => _maxHealth; }
    public float CurrentHealth { get => _health; }
    public float InjuryLevel { get => _injuryLevel; }

    private void Awake()
    {
        #region Set parameters from customizator
        _character = GetComponent<CharacterCustomization>();
        _maxHealth = _character.preset.maximumHealth;
        _injuryLevel = _character.preset.injuryLevel;
        #endregion
        _timer.SetTimeOut(3);
        bodyParts.AddRange(GetComponentsInChildren<CharacterBodypart>());
        /*foreach (PartCollision _partCollision in bodyParts)
            _partCollision.customizator.healthController = this;*/
    }
    private void Start()
    {
        if (Dead) _health = 0;
        else _health = _maxHealth;

        if (!_character.isNPC) MainHUDHandler.instance.healthbar.maxValue = _maxHealth;
    }

    bool IsOverHealed => _health >= _maxHealth;
    public bool IsFullyAlive => _health >= _injuryLevel;
    public bool IsInjuried => _health <= _injuryLevel;
    public bool IsDead => _health <= 0;
    
    private void Update()
    {
        // Health system rewrite (newest)
        
        //switch (playerLifeState)
        //{
        //    case HealthStatus.Alive:
        //        break;
        //    case HealthStatus.Injuried:
        //        break;
        //    case HealthStatus.Dead:
        //        break;
        //}


        _character.RagdollController.isRagdollState = !IsFullyAlive;
        AnimateArms(!IsDead);
        if (!_character.isNPC)
        {
            MainHUDHandler.instance.mainAlpha = 1-(_health / _maxHealth);
            MainHUDHandler.instance.healthbar.value = _health;
        }
        if (IsFullyAlive && !IsOverHealed)
        {// Health regeneration if not injuried or dead state
            if (_timer.IsTimeOut())
                _health += Time.deltaTime * ((_health/_maxHealth)* _character.preset.regeneration_rate);
            else
                _timer.CountTime();
        }
        if (IsDead)
        { 
            _health = 0;        // Limit health
            if (!_character.isNPC) IngameMenuHandler.PauseAndShowMessage("You have died!");        // Show death screen
        }
        if (IsOverHealed) // Avoid health being higher than the max value set
            _health = _maxHealth;
        if (IsInjuried)
        {
            _health -= 1 * Time.deltaTime;
            if (!_character.isNPC)
                _character.RagdollController.isRagdollState = true;
            if (!Unconcious)
            {
                _character.SoundSource.PlayOneShot(AudioTools.GetRandomClip(_character.preset.injuryStateSFX));
                OnInjury.Invoke();
            }
            Unconcious = true;
            if (IsDead)//Value_CurrentHealth <= 0)
            {
                if (!_character.isNPC)
                {
                    //_character.RagdollController.RagdollMode(false, true);
                    _character.GetComponent<BoxCollider>().enabled = false;

                    //arms.LeftShoulder[0].useSpring = false;
                    //arms.LeftShoulder[1].useSpring = false;
                    //arms.LeftBicep.useSpring = false;
                    //arms.LeftElbow.useSpring = false;
                    _character.EquipmentController.IK.spring = 0;
                    //arms.RightShoulder[0].useSpring = false;
                    //arms.RightShoulder[1].useSpring = false;
                    //arms.RightBicep.useSpring = false;
                    //arms.RightElbow.useSpring = false;
                }
                else
                {
                    _character.GetComponent<BoxCollider>().enabled = false;
                    BackgroundMusic.EnableMusic(false);
                }
                if (Dead == false)
                {
                    Dead = true;
                    _character.PlayDeathSFX();
                    _character.EquipmentController.DropAction();
                    _character.EquipmentController.DisableBlades();
                    OnDeath.Invoke();
                }
            }
            else
            {
                if (Dead)
                    OnResurrect.Invoke();
                Dead = false;
                _character.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
    void AnimateArms(bool animate)
    {
        //HingeJoint[] hj = GetComponentsInChildren<HingeJoint>();            //Requires optimization
        HingeJoint[] hj = _character.ArmController.GetUpperBodyParts().ToArray();
        foreach (HingeJoint hinge in hj)
        {
            if (hinge == null) continue;
            float smoothVal = Mathf.Lerp(hinge.spring.spring, (animate)?500:0, Time.deltaTime);
            hinge.spring = PhysicsTools.SetHingeJointSpring(hinge.spring, smoothVal);
        }
    }
    public void PlayPainSound()
    {
        //CameraShaker.Instance.ShakeOnce(0.5f, 3, 0.1f, 0.5f);
        if (Dead)
            return;
        _timer.ResetTime();
        int randomChance = UnityEngine.Random.Range(0, 4);
        if (randomChance == 0) _character.PlayPainSFX();
    }
    public void DealDamage(float amount, Vector3 damageSource, bool showScreenBlood = true)
    {
        _health -= amount;
        PlayPainSound();

        if (damageSource != Vector3.zero) OnDamageDealed.Invoke(this, new OnDamageDealedArgs { where = damageSource });

        if (!_character.isNPC && showScreenBlood)
            MainHUDHandler.instance.ShowEffect(Color.red, amount/_maxHealth, 10);
    }
}
