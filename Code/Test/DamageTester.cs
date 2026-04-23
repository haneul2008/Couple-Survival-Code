using _00.Works.Chipmunk._01.Scripts.Enemies;
using UnityEngine;

namespace _00.Works.HN.Code.Test
{
    public class DamageTester : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private float damage;

        [ContextMenu("Apply Damage")]
        public void ApplyDamage()
        {
            health.ApplyDamage(damage);
        }
    }
}