using System;
using UnityEngine;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.NPC
{
    public class NPC_StateMachine : MonoBehaviour
    {
        public enum NPCState
        {
            Idle,
            Alert,
            Attacking,
        }
        public NPCState NPCStatus;

        void Update() => RunStateMachine();

        void RunStateMachine()
        {

            /*
             * An NPC can't go into attack mode directly.
             * An NPC will analyze a player before attacking, this action takes two seconds.
             * Once the enemy is identified, the attack state will begin.
             *      Once the enemy is beaten, the idle state will begin.
             * Idle <> Alert v
             *  ^-------- Attacking
             */

            switch(NPCStatus)
            {
                case NPCState.Idle:
                    break;

                case NPCState.Alert:
                    break;

                case NPCState.Attacking:
                    break;
            }
        }
    }
}
