using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{    
    // Template state machine element for StateMachine.cs
    public abstract class State : MonoBehaviour
    {
        [HideInInspector] public string stateName;
        public abstract State GetCurrentState();
    }
}
