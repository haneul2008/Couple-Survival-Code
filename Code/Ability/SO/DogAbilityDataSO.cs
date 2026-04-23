using _00.Works.HN.Code.Ability.Impl;
using UnityEngine;

namespace _00.Works.HN.Code.Ability.SO
{
    [CreateAssetMenu(fileName = "DogAbilityData", menuName = "SO/Ability/DogAbilityData", order = 0)]
    public class DogAbilityDataSO : SkillAbilityDataSO
    {
        public Dog dogPrefab;
        public float damageIncrease;
    }
}