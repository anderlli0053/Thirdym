using System;
using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{
    public class StateMachine : MonoBehaviour
    {
        [HideInInspector] public string currentStateName;
        [SerializeField] State currentState;
        public void RunStateMachine()
        {
            State nextState = currentState?.GetCurrentState();

            if(nextState) 
                SwitchState(nextState);
        }

        private void SwitchState(State state)
        {
            currentState = state;
            currentStateName = currentState.stateName;
        }
    }
}
