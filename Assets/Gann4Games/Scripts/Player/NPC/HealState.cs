using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{
    /*
     * This is a state for StateMachine.cs.
     * Only works for StateMachine.cs.
     * The NPC is supposed to look for any hurt ally, and try to heal it.
     */
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
