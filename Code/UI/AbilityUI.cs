using System;
using _00.Works.HN.Code.Ability;
using _00.Works.HN.Code.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _00.Works.HN.Code.UI
{
    public class AbilityUI : MonoBehaviour
    {
        [SerializeField] private Image abilityImage;
        [SerializeField] private TextMeshProUGUI levelText;

        private Ability.Ability _ability;
        private AbilityDataSO _abilityData;

        public void Initialize(Ability.Ability ability)
        {
            _abilityData = ability.AbilityData;
            abilityImage.sprite = _abilityData.icon;
            SetLevelText(1);
        }

        public void SetLevelText(int level) => levelText.text = level.ToString();
    }
}