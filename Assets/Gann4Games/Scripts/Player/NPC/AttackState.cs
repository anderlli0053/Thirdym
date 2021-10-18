using UnityEngine;
using Gann4Games.Thirdym.Utility;

namespace Gann4Games.Thirdym.NPC
{
    public class AttackState : State
    {
        [SerializeField] CharacterCustomization character;

        [Header("States")]
        [SerializeField] IdleState idleState;
        [SerializeField] DeadState deadState;

        TimerTool _timer = new TimerTool();
        private void Awake()
        {
            stateName = "Attack";
        }
        public override State GetCurrentState()
        {
            if (character.HealthController.IsDead) return deadState;

            CharacterCustomization closestEnemy = character.NPC.GetClosestAliveRagdoll(character.preset.enemyTags);

            _timer.CountTime();

            character.NPC.SelfBalance();

            if(closestEnemy)
            {
                character.NPC.SetTargetPoint(closestEnemy.transform.position);
                character.NPC.RagdollWalk2Nav();
                character.NPC.RagdollBodyLookAt(closestEnemy.transform.position);
                character.NPC.HeadLookAt(closestEnemy.transform.position);
                character.NPC.GoTo(closestEnemy.transform.position + closestEnemy.transform.forward * 3);

                if (character.NPC.IsFacingAt(closestEnemy.transform.position, character.preset.enemyTags) && character.NPC.IsOnSight(closestEnemy.transform.position))
                {
                    if(_timer.IsTimeOut())
                    {
                        _timer.SetTimeOut(Random.Range(0, 1));
                        _timer.ResetTime();
                        character.NPC.Attack();
                    }
                    character.ArmController.AimWeapon(true);
                }
                else
                {
                    character.ArmController.AimWeapon(false);
                    return idleState;
                }
            }
            else
            {
                return idleState;
            }

            return this;
        }
    }
}
