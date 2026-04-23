using _00.Works.Chipmunk._01.Scripts;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Serialization;

namespace _00.Works.HN.Code.UI
{
    public class BossTimerUI : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private Transform fill;

        private void Update()
        {
            float x = timer.CurrentTime / timer.maxTime;
            fill.transform.localScale = new Vector3(x, fill.transform.localScale.y, 0);
        }
    }
}