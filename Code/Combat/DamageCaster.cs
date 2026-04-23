using System;
using _00.Works.Chipmunk._01.Scripts.Enemies;
using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;

namespace _00.Works.HN.Code.Combat
{
    public class DamageCaster : MonoBehaviour
    {
        [SerializeField] private ContactFilter2D contactFilter;
        [SerializeField] private float radius;
        [SerializeField] private int detectCnt;

        private Collider2D[] _res;

        private void Awake()
        {
            _res = new Collider2D[detectCnt];
        }

        public void CastDamage(float damage)
        {
            int cnt = Physics2D.OverlapCircle(transform.position, radius, contactFilter, _res);
            
            for (int i = 0; i < cnt; ++i)
            {
                print(_res[i].gameObject.name);
                if (_res[i].TryGetComponent(out ComponentContainer component))
                {
                    Debug.Log("Da");
                    Health health = component.Get<Health>();
                    health.ApplyDamage(damage);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}