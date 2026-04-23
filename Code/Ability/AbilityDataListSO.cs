using System.Collections.Generic;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    [CreateAssetMenu(fileName = "AbilityDataList", menuName = "SO/Ability/AbilityDataList", order = 0)]
    public class AbilityDataListSO : ScriptableObject
    {
        public List<AbilityDataSO> abilityDataList;
    }
}