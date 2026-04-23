using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _00.Works.HN.Code.Scenes
{
    public class TitleScene : MonoBehaviour
    {
        public UnityEvent OnGameStart;
        private bool _isStarted;

        private void Update()
        {
            if (_isStarted == false && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                OnGameStart?.Invoke();
                _isStarted = true;
            }
        }
    }
}