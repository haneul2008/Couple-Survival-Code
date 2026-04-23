using System;
using System.Collections.Generic;
using _00.Works.HN.Code.EventSystems;
using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;

namespace _00.Works.HN.Code.UI
{
    public class AbilityPanel : MonoBehaviour
    {
        [SerializeField] private GameEventChannelSO abilityChannel;
        [SerializeField] private ComponentContainer owner;
        [SerializeField] private AbilityUI abilityUI;
        
        private readonly Dictionary<Ability.Ability, AbilityUI> _abilityPairs = new Dictionary<Ability.Ability, AbilityUI>();

        private void Awake()
        {
            abilityChannel.AddListener<AbilitySelectEvent>(HandleAbilitySelected);
        }

        private void OnDestroy()
        {
            abilityChannel.RemoveListener<AbilitySelectEvent>(HandleAbilitySelected);
        }

        private void HandleAbilitySelected(AbilitySelectEvent evt)
        {
            if(owner != evt.owner) return;
            
            Ability.Ability ability = evt.ability;
            
            if (_abilityPairs.TryGetValue(ability, out AbilityUI ui))
            {
                ui.SetLevelText(ability.Level);
            }
            else
            {
                AbilityUI newUI = Instantiate(abilityUI, transform);
                newUI.Initialize(ability);
                _abilityPairs.Add(ability, newUI);
            }
        }
    }
}