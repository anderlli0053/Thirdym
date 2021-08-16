using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{
    public class HealState : State
    {
        [SerializeField] CharacterCustomization character;

        [Header("States")]
        [SerializeField] IdleState idleState;
        private void Awake()
        {
            stateName = "Healing";
        }
        public override State GetCurrentState()
        {
            return this;
        }
    }
}
