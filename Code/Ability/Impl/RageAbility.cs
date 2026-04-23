using _00.Works.Chipmunk._01.Scripts.Enemies;
using _00.Works.HN.Code.Ability.SO;
using _00.Works.HN.Code.Effects;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class RageAbility : SkillAbility
    {
        private readonly RageAbilityDataSO _rageData;
        private readonly float _defaultMultiplier;
        private float _currentMultiplier;
        private bool _isRage;
        private Health _partnerHealth;
        private Effect _rageEffect;

        public RageAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _rageData = abilityData as RageAbilityDataSO;

            if (_rageData is null) return;

            _defaultMultiplier = _rageData.damageMultiplier;
            _currentMultiplier = _defaultMultiplier;
        }

        public override void Enter()
        {
            base.Enter();

            Player partner = _owner.Get<Player>().GetPartner();
            _partnerHealth = partner.Get<Health>();
            _partnerHealth.OnHitEvent.AddListener(HandlePartnerHit);
        }

        public override void Exit()
        {
            base.Exit();
            
            _partnerHealth.OnHitEvent.RemoveListener(HandlePartnerHit);
        }

        private void HandlePartnerHit(float healthPercent)
        {
            float percent = _partnerHealth.CurrentHealth / _partnerHealth.MaxHealth;

            if (_rageData.ragePercent >= percent && _isRage == false)
            {
                _isRage = true;

                Player player = _owner.Get<Player>();
                _rageEffect = GameObject.Instantiate(_rageData.rageEffect, player.transform);
                _rageEffect.PlayEffect(player.transform.position);
                
                StatBehavior statBehavior = _owner.Get<StatBehavior>();
                StatSO damageStat = statBehavior.GetStat(_rageData.damageStat);
                damageStat.AddModifier(this, damageStat.Value * _currentMultiplier);
            }
            else if (_isRage)
            {
                _isRage = false;

                if (_rageEffect != null)
                {
                    GameObject.Destroy(_rageEffect.gameObject);
                    _rageEffect = null;
                }
                
                StatBehavior statBehavior = _owner.Get<StatBehavior>();
                StatSO damageStat = statBehavior.GetStat(_rageData.damageStat);
                damageStat.RemoveModifier(this);
            }
        }

        public override void Upgrade()
        {
            _currentMultiplier += _rageData.damageIncreasePercent;
        }

        public override void Update()
        {
        }

        protected override void Attack()
        {
        }
    }
}