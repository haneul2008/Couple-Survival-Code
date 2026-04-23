using _00.Works.HN.Code.Effects;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.SO
{
    [CreateAssetMenu(fileName = "RageAbility", menuName = "SO/Ability/RageAbility", order = 0)]
    public class RageAbilityDataSO : SkillAbilityDataSO
    {
        public Effect rageEffect;
        public float damageIncreasePercent;
        public float ragePercent;
    }
}