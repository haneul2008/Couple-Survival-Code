using ChipmunkKingdoms.Stats;
using UnityEngine;

namespace _00.Works.HN.Code.Test
{
    public class StatTester : MonoBehaviour
    {
        [SerializeField] private StatBehavior statBehavior;
        [SerializeField] private StatSO targetStat;
        [SerializeField] private float modifier;

        [ContextMenu("Add Modifier")]
        public void AddModifier()
        {
            statBehavior.AddModifier(targetStat, this, modifier);
        }
        
        [ContextMenu("Remove Modifier")]
        public void RemoveModifier()
        {
            statBehavior.RemoveModifier(targetStat,this);
        }
        
        [ContextMenu("Print Stat")]
        public void PrintStat()
        {
            print(statBehavior.GetStat(targetStat).Value);
        }
    }
}