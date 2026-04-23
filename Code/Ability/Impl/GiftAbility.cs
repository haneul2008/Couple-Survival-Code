using _00.Works.HN.Code.Ability.SO;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class GiftAbility : SkillAbility
    {
        private readonly GiftAbilityDataSO _giftData;
        
        public GiftAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _giftData = abilityData as GiftAbilityDataSO;
        }

        protected override void Attack()
        {
            StatBehavior statBehavior = _owner.Get<StatBehavior>();
            float damage = statBehavior.GetStat(_giftData.damageStat).Value * _giftData.damageMultiplier;

            Player player = _owner.Get<Player>();
            Player partner = player.GetPartner();

            int giftCnt = _giftData.increaseGiftCnt * Level;
            float randAngle = Random.Range(0, 360f);
            float angleAdder = 360f / giftCnt;
            
            for (int i = 0; i < giftCnt; ++i)
            {
                Gift newGift = GameObject.Instantiate(_giftData.giftPrefab);
                newGift.Initialize(player.transform.position, partner.transform, damage, randAngle + angleAdder * i);
            }
        }
    }
}