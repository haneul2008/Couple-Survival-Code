using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class LoverStatAbility : StatAbility
    {
        public LoverStatAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
        }

        protected override void IncreaseStat()
        {
            if(Level > 1) RemoveModifier();
            
            StatBehavior ownerStatBehavior = _owner.Get<StatBehavior>();
            StatSO stat = ownerStatBehavior.GetStat(_statAbilityData.targetStat);
            stat.AddModifier(this, _statAbilityData.increaseAmount * Level);

            Player partner = _owner.Get<Player>().GetPartner();
            StatBehavior partnerStatBehavior = partner.Get<StatBehavior>();
            stat = partnerStatBehavior.GetStat(_statAbilityData.targetStat);
            stat.AddModifier(this, _statAbilityData.increaseAmount * Level);
        }
    }
}