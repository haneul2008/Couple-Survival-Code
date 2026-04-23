using _00.Works.HN.Code.Ability.Impl;
using UnityEngine;
using UnityEngine.Serialization;

namespace _00.Works.HN.Code.Ability.SO
{
    [CreateAssetMenu(fileName = "GiftAbilityData", menuName = "SO/Ability/GiftAbilityData", order = 0)]
    public class GiftAbilityDataSO : SkillAbilityDataSO
    {
        public Gift giftPrefab;
        public int increaseGiftCnt;
    }
}