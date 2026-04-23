using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    [CreateAssetMenu(fileName = "StatAbilityData", menuName = "SO/Ability/StatAbilityData", order = 0)]
    public class StatAbilityDataSO : AbilityDataSO
    {
        public StatSO targetStat;
        public float increaseAmount;
    }
}