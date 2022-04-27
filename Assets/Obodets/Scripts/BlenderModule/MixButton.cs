using System;
using UnityEngine;

namespace Obodets.Scripts.BlenderModule
{
    public class MixButton : MonoBehaviour
    {
        private Action _onClick;
        private bool _enabled;

        private void OnMouseDown()
        {
            if (!_enabled) return;
            
            _onClick?.Invoke();
        }

        public void Initialize(Action onClick)
        {
            _onClick = onClick;
        }

        public void Active(bool state)
        {
            _enabled = state;
        }
    }
}