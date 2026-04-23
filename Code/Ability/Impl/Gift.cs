using _00.Works.HN.Code.Animators;
using _00.Works.HN.Code.Combat;
using _00.Works.HN.Code.Effects;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class Gift : MonoBehaviour
    {
        [SerializeField] private DamageCaster damageCaster;
        [SerializeField] private SpriteRenderer render;
        [SerializeField] private AnimatorTrigger animTrigger;
        [SerializeField] private float initDelay;
        [SerializeField] private float moveDuration;
        [SerializeField] private float warpDelay;
        [SerializeField] private float fadeDuration;
        [SerializeField] private float endY;
        [SerializeField] private float radius;
        [SerializeField] private Effect explosionEffect;
        [SerializeField] private Transform shadowTrm;
        
        public UnityEvent OnExplosionEvent;

        private SpriteRenderer _shadowRender;
        private Transform _partner;
        private float _damage;
        private float _originShadowAlpha;
        private float _angle;
        
        public void Initialize(Vector2 start, Transform partner, float damage, float angle)
        {
            render.color = new Color(1, 1, 1, 0);
            
            _partner = partner;
            _damage = damage;
            _angle = angle;
            
            float rad = angle * Mathf.Deg2Rad;
            Vector2 randPos = start + new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;

            transform.position = randPos;
            
            _shadowRender = shadowTrm.GetComponent<SpriteRenderer>();
            _originShadowAlpha = _shadowRender.color.a;
            shadowTrm.SetParent(null);

            render.DOColor(Color.white, fadeDuration);
            
            animTrigger.OnAnimationEnd += HandleAnimationEnd;

            DOVirtual.DelayedCall(initDelay, HandleMoveStart);
        }

        private void OnDestroy()
        {
            animTrigger.OnAnimationEnd += HandleAnimationEnd;
        }

        private void HandleAnimationEnd() => Destroy(gameObject);


        private void HandleMoveStart()
        {
            _shadowRender.DOFade(0, fadeDuration);
            transform.DOMoveY(transform.position.y + endY, moveDuration).OnComplete(() =>
            {
                transform.localScale = Vector3.zero;
                shadowTrm.position = transform.position;
                DOVirtual.DelayedCall(warpDelay, HandleWarp);
            });
        }

        private void HandleWarp()
        {
            float rad = _angle * Mathf.Deg2Rad;
            Vector2 partnerPos = _partner.transform.position;
            Vector2 endPos = partnerPos + new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
            
            transform.position = new Vector2(endPos.x, endPos.y + endY);
            transform.localScale = Vector3.one;
            shadowTrm.position = endPos;
            _shadowRender.DOFade(_originShadowAlpha, fadeDuration);

            transform.DOMoveY(transform.position.y - endY, moveDuration).SetEase(Ease.InCubic).OnComplete(HandleWarpEnd);
        }

        private void HandleWarpEnd()
        {
            Effect effect = Instantiate(explosionEffect);
            effect.PlayEffect(transform.position);
            render.DOFade(0, fadeDuration).OnComplete(() => Destroy(gameObject));
            damageCaster.CastDamage(_damage);

            Destroy(shadowTrm.gameObject);
            OnExplosionEvent?.Invoke();
        }
    }
}