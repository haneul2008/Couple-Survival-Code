using System;
using System.Collections.Generic;
using _00.Works.HS.Code.Player;
using ChipmunkKingdoms.Scripts.Utility;
using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.LoverStat
{
    public class LoverStatObserver : MonoBehaviour, IContainerComponent, IAfterInitailze
    {
        [SerializeField] private List<StatSO> increaseStats;
        [SerializeField] private StatSO loverStat;

        public ComponentContainer ComponentContainer { get; set; } 

        public void OnInitialize(ComponentContainer componentContainer)
        {
        }

        public void AfterInit()
        {
            StatBehavior statBehavior = this.Get<StatBehavior>();
            StatSO stat = statBehavior.GetStat(loverStat);
            stat.OnValueChange += HandleLoverStatChange;
        }

        private void OnDestroy()
        {
            StatBehavior statBehavior = this.Get<StatBehavior>();
            StatSO stat = statBehavior.GetStat(loverStat);
            stat.OnValueChange -= HandleLoverStatChange;
        }

        private void HandleLoverStatChange(StatSO stat, float current, float previous)
        {
            Player partner = this.Get<Player>().GetPartner();

            StatBehavior partnerStatBehavior = partner.Get<StatBehavior>();
            
            foreach (StatSO item in increaseStats)
            {
                StatSO getStat = partnerStatBehavior.GetStat(item);
                getStat.AddModifier(this, getStat.Value * current);
            }
        }
    }
}