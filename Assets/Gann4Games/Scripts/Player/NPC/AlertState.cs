using UnityEngine;
using Gann4Games.Thirdym.Utility;

namespace Gann4Games.Thirdym.NPC
{
    public class AlertState : State
    {
        [SerializeField] CharacterCustomization character;

        [Header("States")]
        [SerializeField] IdleState idleState;
        [SerializeField] AttackState attackState;
        [SerializeField] DeadState deadState;

        TimerTool _timer = new TimerTool();

        private void Awake()
        {
            stateName = "Alert";
            _timer.SetTimeOut(2);
            character.PlayAlertSFX();
        }
        public override State GetCurrentState()
        {
            if (character.HealthController.IsDead) return deadState;

            CharacterCustomization closestEnemy = character.NPC.GetClosestAliveRagdoll(character.preset.enemyTags);

            character.NPC.SelfBalance();

            if(_timer.IsTimeOut())
            {
                _timer.ResetTime();
                if (closestEnemy)
                {
                    if (character.NPC.IsFacingAt(closestEnemy.transform.position, character.preset.enemyTags) && character.NPC.IsOnSight(closestEnemy.transform.position))
                    {
                        return attackState;
                    }
                    else
                    {
                        return idleState;
                    }
                }
            }
            else
            {
                if(closestEnemy)
                {
                    if(character.NPC.IsFacingAt(closestEnemy.transform.position, character.preset.enemyTags) && character.NPC.IsOnSight(closestEnemy.transform.position))
                    {
                        character.NPC.GoTo(character.transform.position - character.transform.forward * 10);
                        character.NPC.HeadLookAt(closestEnemy.transform.position);
                        character.NPC.RagdollBodyLookAt(closestEnemy.transform.position);
                        character.NPC.RagdollWalk2Nav();
                    }
                }
                _timer.CountTime();
            }

            return this;
        }
    }
}
