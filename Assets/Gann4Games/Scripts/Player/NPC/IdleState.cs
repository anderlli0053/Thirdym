using UnityEngine;
using Gann4Games.Thirdym.Utility;

namespace Gann4Games.Thirdym.NPC
{
    public class IdleState : State
    {
        [SerializeField] CharacterCustomization character;

        [Header("States")]
        [SerializeField] AlertState alertState;
        [SerializeField] DeadState deadState;

        TimerTool _timer = new TimerTool();
        private void Awake()
        {
            stateName = "Idle";
            _timer.SetTimeOut(5);
        }
        public override State GetCurrentState()
        {
            if (character.HealthController.IsDead) return deadState;

            CharacterCustomization closestEnemy = character.NPC.GetClosestAliveRagdoll(character.preset.enemyTags);
            if (character.NPC.targetPoint == Vector3.zero) character.NPC.targetPoint = character.transform.position + character.transform.forward;
            character.NPC.SelfBalance();
            character.NPC.RagdollBodyLookAt(character.NPC.targetPoint);
            character.Animator.SetFloat("X", 0);
            character.Animator.SetFloat("Y", 0);

            if(closestEnemy)
            {
                if (character.NPC.IsFacingAt(closestEnemy.transform.position, character.preset.enemyTags) && character.NPC.IsOnSight(closestEnemy.transform.position))
                {
                    return alertState;
                }
            }

            _timer.CountTime();

            if(_timer.IsTimeOut())
            {
                _timer.ResetTime();
                character.NPC.HeadLookAt(character.NPC.GetRandomPlaceAround(character.transform.position, Vector2.one*10));
            }

            return this;
        }
    }
}
