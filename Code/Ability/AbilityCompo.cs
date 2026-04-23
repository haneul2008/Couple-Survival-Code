using System;
using System.Collections.Generic;
using System.Linq;
using _00.Works.HN.Code.EventSystems;
using ChipmunkKingdoms.Scripts.Utility;
using UnityEngine;

namespace _00.Works.HN.Code.Ability
{
    public class AbilityCompo : MonoBehaviour, IContainerComponent, IAfterInitailze
    {
        public ComponentContainer ComponentContainer { get; set; }

        [SerializeField] private AbilityDataListSO abilityDatas;
        [SerializeField] private GameEventChannelSO upgradeChannel;
        [SerializeField] private GameEventChannelSO abilityChannel;
        [SerializeField] private AbilityDataSO initData;

        private readonly Dictionary<AbilityDataSO, Ability> _abilityPairs = new Dictionary<AbilityDataSO, Ability>();

        public void OnInitialize(ComponentContainer componentContainer)
        {
        }
        
        public void AfterInit()
        {
            foreach (AbilityDataSO data in abilityDatas.abilityDataList)
            {
                Type type = Type.GetType(data.className);

                if (type == null)
                {
                    Debug.LogError($"Type is null : {gameObject.name}");
                    return;
                }
                
                Ability ability = Activator.CreateInstance(type, data, this) as Ability;
                _abilityPairs.Add(data, ability);
            }
        }

        private void Start()
        {
            SelectAbility(initData);
        }

        public void DisableAbilities()
        {
            foreach (Ability ability in _abilityPairs.Values)
            {
                if(ability.Active == false) continue;
                
                ability.Exit();
            }
        }

        private void Update()
        {
            foreach (Ability ability in _abilityPairs.Values)
            {
                if(ability.Active == false) continue;
                
                ability.Update();
            }
        }

        public void SelectAbility(AbilityDataSO abilityData)
        {
            Ability ability = _abilityPairs.GetValueOrDefault(abilityData);

            if(ability is null) return;

            if (ability.Active == false)
            {
                ability.Active = true;
                ability.Enter();
            }
            else
            {
                upgradeChannel.RaiseEvent(UpgradeEvents.UpgradeEvent.Initializer(ability));
            }
            
            abilityChannel.RaiseEvent(AbilityEvents.AbilitySelectEvent.Initializer(ComponentContainer, ability));
        }

        public List<Ability> GetActiveAbilities()
        {
            return _abilityPairs.Values.Where(ability => ability.Active).ToList();
        }
        
        public List<Ability> GetMaxAbilities()
        {
            return _abilityPairs.Values.Where(ability => ability.IsMax()).ToList();
        }
        
        public List<Ability> GetNotMaxAbilities()
        {
            return _abilityPairs.Values.Where(ability => ability.IsMax() == false).ToList();
        }
    }
}