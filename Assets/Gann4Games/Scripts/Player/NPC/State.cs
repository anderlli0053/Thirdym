using UnityEngine;

namespace Gann4Games.Thirdym.NPC
{
    public abstract class State : MonoBehaviour
    {
        [HideInInspector] public string stateName;
        public abstract State GetCurrentState();
    }
}
