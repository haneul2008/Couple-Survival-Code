using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    public class StatAbility : Ability
    {
        protected readonly StatAbilityDataSO _statAbilityData;
        
        public StatAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _statAbilityData = abilityData as StatAbilityDataSO;
        }

        public override void Enter()
        {
            base.Enter();

            IncreaseStat();
        }

        public override void Upgrade()
        {
            base.Upgrade();
            
            IncreaseStat();
        }

        protected virtual void IncreaseStat()
        {
            if(Level > 1) RemoveModifier();
            
            StatBehavior statBehavior = _owner.Get<StatBehavior>();
            StatSO stat = statBehavior.GetStat(_statAbilityData.targetStat);
            stat.AddModifier(this, _statAbilityData.increaseAmount * Level);
        }

        public override void Exit()
        {
            base.Exit();
            
            RemoveModifier();
        }

        protected void RemoveModifier()
        {
            StatBehavior statBehavior = _owner.Get<StatBehavior>();
            StatSO stat = statBehavior.GetStat(_statAbilityData.targetStat);
            stat.RemoveModifier(this);
        }
    }
}