using _00.Works.HN.Code.Upgrades;
using ChipmunkKingdoms.Scripts.Utility;

namespace _00.Works.HN.Code.Ability
{
    public abstract class Ability : IUpgrade
    {
        public AbilityDataSO AbilityData { get; private set; }
        public bool Active { get; set; }
        public int Level { get; protected set; }
        
        protected readonly IContainerComponent _owner;

        protected Ability(AbilityDataSO abilityData, IContainerComponent owner)
        {
            AbilityData = abilityData;
            _owner = owner;
        }

        public virtual void Enter()
        {
            Level = 1;
        }

        public virtual void Update() {}

        public virtual void Exit() {}

        public virtual bool IsMax() => Level >= AbilityData.maxLevel;

        public virtual void Upgrade()
        {
            Level++;
        }
    }
}