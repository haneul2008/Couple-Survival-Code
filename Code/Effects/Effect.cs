using DG.Tweening;
using UnityEngine;

namespace _00.Works.HN.Code.Effects
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;

        public void PlayEffect(Vector2 pos)
        {
            transform.position = pos;
            
            particle.Play();
            float duration = particle.main.duration + 0.2f;
            DOVirtual.DelayedCall(duration, () => Destroy(gameObject));
        }
    }
}