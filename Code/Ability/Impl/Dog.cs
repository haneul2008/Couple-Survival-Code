using System;
using _00.Works.HN.Code.Combat;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using DG.Tweening;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class Dog : MonoBehaviour
    {
        [SerializeField] private StatSO moveSpeedStat;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private DamageCaster damageCaster;
        [SerializeField] private float fadeDuration;
        [SerializeField] private float moveAmount;
        [SerializeField] private float moveDuration;
        
        private Player _owner;
        private float _xMove;
        private float _damage;

        private void Awake()
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
        }

        public void Initialize(Player owner, float damage)
        {
            _owner = owner;
            _damage = damage;
            _xMove = _owner.IsFirstPlayer ? moveAmount : -moveAmount;
            float angle = _owner.IsFirstPlayer ? -180f : 0;
            transform.eulerAngles = new Vector3(0, angle, 0);

            StatSO speedStat = _owner.Get<StatBehavior>().GetStat(moveSpeedStat);
            float moveAmountMultiplier = speedStat.Value / speedStat.BaseValue;
            moveAmount *= moveAmountMultiplier;
            
            spriteRenderer.DOFade(1, fadeDuration);
            transform.DOMoveX(transform.position.x + _xMove, moveDuration).SetEase(Ease.Linear)
                .OnComplete(HandleMoveEnd);
        }

        private void HandleMoveEnd()
        {
            Player partner = _owner.GetPartner();
            Vector3 partnerPos = partner.transform.position;
            float startX = partnerPos.x - _xMove;
            float endX = partnerPos.x + _xMove * 2;
            transform.position = new Vector3(startX, partnerPos.y);
            transform.DOMoveX(endX, moveDuration * 3).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
        }

        private void FixedUpdate()
        {
            
            damageCaster.CastDamage(_damage);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
        }
    }
}