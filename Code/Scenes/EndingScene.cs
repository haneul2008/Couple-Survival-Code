using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _00.Works.HN.Code.Scenes
{
    public class EndingScene : MonoBehaviour
    {
        public UnityEvent OnSpacePressed;
        private bool _isStarted;

        private void Update()
        {
            if (_isStarted == false && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                OnSpacePressed?.Invoke();
                _isStarted = true;
            }
        }
    }
}