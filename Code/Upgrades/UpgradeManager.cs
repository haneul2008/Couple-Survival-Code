using System;
using _00.Works.HN.Code.EventSystems;
using UnityEngine;

namespace _00.Works.HN.Code.Upgrades
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] private GameEventChannelSO upgradeChannel;
        
        private void Awake()
        {
            upgradeChannel.AddListener<UpgradeEvent>(HandleUpgrade);
        }

        private void OnDestroy()
        {
            upgradeChannel.RemoveListener<UpgradeEvent>(HandleUpgrade);
        }

        private void HandleUpgrade(UpgradeEvent evt)
        {
            IUpgrade upgrade = evt.upgrade;

            if(upgrade.IsMax()) return;
            
            upgrade.Upgrade();
        }
    }
}