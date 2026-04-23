using _00.Works.HN.Code.Ability.SO;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class DogAbility : SkillAbility
    {
        private readonly DogAbilityDataSO _dogAbilityData;
        private readonly Player _player;
        private StatSO _damageStat;
        
        public DogAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _dogAbilityData = abilityData as DogAbilityDataSO;
            
            if(_dogAbilityData is null) return;
            
            _player = owner.Get<Player>();
        }

        public override void Enter()
        {
            base.Enter();
            
            _damageStat = _owner.Get<StatBehavior>().GetStat(_dogAbilityData.damageStat);
        }

        protected override void Attack()
        {
            Dog dog = GameObject.Instantiate(_dogAbilityData.dogPrefab, _player.transform.position, Quaternion.identity);
            float damageMultiplier = _dogAbilityData.damageMultiplier + _dogAbilityData.damageIncrease * Level;
            float damage = _damageStat.Value * damageMultiplier;
            
            dog.Initialize(_player, damage);
        }
    }
}