using _00.Works.Chipmunk._01.Scripts.Enemies;
using _00.Works.HN.Code.Ability.SO;
using _00.Works.HS.Code.Manager;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;

namespace _00.Works.HN.Code.Ability.Impl
{
    public class KillToHealAbility : SkillAbility
    {
        private readonly KillToHealAbilityDataSO _killToHealAbilityData;
        private EnemySpawner _spawner;
        private Health _partnerHealth;
        private int _healCnt;
        
        public KillToHealAbility(AbilityDataSO abilityData, IContainerComponent owner) : base(abilityData, owner)
        {
            _killToHealAbilityData = abilityData as KillToHealAbilityDataSO;
        }

        public override void Enter()
        {
            base.Enter();

            Player player = _owner.Get<Player>();
            Player partner = player.GetPartner();
            
            _partnerHealth = partner.Get<Health>();
            _spawner = GameManager.Instance.GetSpawner(player);
            _spawner.OnDead.AddListener(HandleEnemyDead);
        }

        public override void Exit()
        {
            base.Exit();
            
            _spawner.OnDead.RemoveListener(HandleEnemyDead);
        }

        private void HandleEnemyDead()
        {
            int requireCnt = _killToHealAbilityData.requireDeadCnt;
            
            if (_spawner.deadCount / requireCnt > _healCnt)
            {
                _healCnt++;
                float healAmount = -_killToHealAbilityData.healAmount + _killToHealAbilityData.healIncrease * Level;
                _partnerHealth.ApplyDamage(healAmount);
            }
        }
        
        public override void Update()
        {
        }
        
        protected override void Attack()
        {
        }
    }
}