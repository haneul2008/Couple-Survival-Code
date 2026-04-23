using _00.Works.HN.Code.Ability;
using UnityEngine;

namespace _00.Works.HN.Code.Test
{
    public class AbilityTester : MonoBehaviour
    {
        [SerializeField] private AbilityCompo abilityCompo;
        [SerializeField] private AbilityDataSO targetData;

        [ContextMenu("Select Ability")]
        public void SelectAbility()
        {
            abilityCompo.SelectAbility(targetData);
        }
    }
}