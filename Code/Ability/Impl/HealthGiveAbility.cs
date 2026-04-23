using _00.Works.Chipmunk._01.Scripts.Enemies;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class HealthGiveAbility : StatAbility
    {
        private const float GIVE_AMOUNT = -120f;
        private readonly float _hurtAmount;
        
        public HealthGiveAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _hurtAmount = _statAbilityData.increaseAmount;
        }

        protected override void IncreaseStat()
        {
            Player partner = _owner.Get<Player>().GetPartner();
            Health ownerHealth = _owner.Get<Health>();
            Health partnerHealth = partner.Get<Health>();

            ownerHealth.ApplyDamage(_hurtAmount);
            partnerHealth.ApplyDamage(GIVE_AMOUNT);
        }
    }
}