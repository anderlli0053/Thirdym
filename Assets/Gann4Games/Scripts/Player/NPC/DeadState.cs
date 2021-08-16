using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{
    public class DeadState : State
    {
        [SerializeField] CharacterCustomization character;

        [Header("States")]
        [SerializeField] IdleState idleState;
        private void Awake()
        {
            stateName = "Dead";
        }
        public override State GetCurrentState()
        {
            if (character.HealthController.IsFullyAlive) return idleState;
            return this;
        }
    }
}
