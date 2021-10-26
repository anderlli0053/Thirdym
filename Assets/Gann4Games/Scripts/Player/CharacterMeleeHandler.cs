using UnityEngine;
using Gann4Games.Thirdym.Events;

public class CharacterMeleeHandler : MonoBehaviour
{
    CharacterCustomization _character;
        
    public AnimationEventsReader animationEvents;

    private void Start()
    {
        _character = GetComponent<CharacterCustomization>();
    }

    private void OnEnable()
    {
        animationEvents.OnLeftMeleeAttack += AnimationEvents_OnLeftMeleeAttack;
        animationEvents.OnRightMeleeAttack += AnimationEvents_OnRightMeleeAttack;
    }
    private void OnDisable()
    {
        animationEvents.OnLeftMeleeAttack -= AnimationEvents_OnLeftMeleeAttack;
        animationEvents.OnRightMeleeAttack -= AnimationEvents_OnRightMeleeAttack;
    }

    private void AnimationEvents_OnLeftMeleeAttack(object sender, System.EventArgs args)
    {
        CharacterMeleeObject meleeObject = _character.baseBody.leftHand.GetComponentInChildren<CharacterMeleeObject>();
        if (!meleeObject) return;

        meleeObject.EnableCollider(true);
        _character.PlayFireSFX();
    }

    private void AnimationEvents_OnRightMeleeAttack(object sender, System.EventArgs args)
    {
        CharacterMeleeObject meleeObject = _character.baseBody.rightHand.GetComponentInChildren<CharacterMeleeObject>();
        if (!meleeObject) return;
        
        meleeObject.EnableCollider(true);
        _character.PlayFireSFX();
    }
}
