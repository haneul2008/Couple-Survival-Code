using System.Collections.Generic;
using UnityEngine;

namespace _00.Works.HN.Code.Sounds
{
    [CreateAssetMenu(fileName = "SoundListSo", menuName = "SO/Sound/SoundListSo")]
    public class SoundListSO : ScriptableObject
    {
        [SerializeField] private List<SoundSO> sounds;

        public Dictionary<string, SoundSO> SoundsDictionary;

        private void OnEnable()
        {
            if(sounds.Count == 0) return;
            
            SoundsDictionary = new Dictionary<string, SoundSO>();
            foreach (SoundSO soundSo in sounds)
            {
                SoundsDictionary[soundSo.soundName] = soundSo;
            }
        }
    }
}