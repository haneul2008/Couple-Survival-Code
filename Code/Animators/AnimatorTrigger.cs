using System;
using UnityEngine;

namespace _00.Works.HN.Code.Animators
{
    public class AnimatorTrigger : MonoBehaviour
    {
        public event Action OnAttack;
        public event Action OnAnimationEnd;

        public void Attack()
        {
            OnAttack?.Invoke();
        }

        public void AnimationEnd()
        {
            OnAnimationEnd?.Invoke();
        }
    }
}