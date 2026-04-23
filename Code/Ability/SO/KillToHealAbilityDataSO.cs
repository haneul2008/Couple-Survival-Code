using UnityEngine;
using UnityEngine.Serialization;

namespace _00.Works.HN.Code.Ability.SO
{
    [CreateAssetMenu(fileName = "KillToHealAbilityData", menuName = "SO/Ability/KillToHealAbilityData", order = 0)]
    public class KillToHealAbilityDataSO : SkillAbilityDataSO
    {
        public int requireDeadCnt;
        public float healAmount;
        public float healIncrease;
    }
}