using System;
using UnityEngine;

namespace Obodets.Scripts.BlenderModule
{
    public class MixButton : MonoBehaviour
    {
        private Action _onClick;

        private void OnMouseDown()
        {
            _onClick?.Invoke();
        }

        public void Initialize(Action onClick)
        {
            _onClick = onClick;
        }
    }
}