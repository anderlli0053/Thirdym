using UnityEngine;
using System;

namespace Gann4Games.Thirdym.Events
{
    [RequireComponent(typeof(Animator))]
    public class AnimationEventsReader : MonoBehaviour
    {
        public event EventHandler OnRightMeleeAttack;

        public event EventHandler OnLeftMeleeAttack;


        public void MeleeAttack_Right() => OnRightMeleeAttack?.Invoke(this, EventArgs.Empty);

        public void MeleeAttack_Left() => OnLeftMeleeAttack?.Invoke(this, EventArgs.Empty);
    }
}
