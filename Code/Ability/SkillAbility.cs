using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    public abstract class SkillAbility : Ability
    {
        protected readonly SkillAbilityDataSO _skillAbilityData;
        private float _lastAttackTime;
        
        public SkillAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _skillAbilityData = abilityData as SkillAbilityDataSO;
        }

        public override void Enter()
        {
            base.Enter();

            _lastAttackTime = Time.time;
        }

        public override void Update()
        {
            base.Update();
            
            if(_lastAttackTime + _skillAbilityData.cooldown > Time.time) return;
            
            Attack();
            _lastAttackTime = Time.time;
        }

        protected abstract void Attack();
    }
}