using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    [CreateAssetMenu(fileName = "SkillAbilityData", menuName = "SO/Ability/SkillAbilityData", order = 0)]
    public class SkillAbilityDataSO : AbilityDataSO
    {
        public float cooldown;
        public float damageMultiplier;
        public StatSO damageStat;
    }
}