using System;
using Obodets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Obodets.Scripts.Base
{
    [RequireComponent(typeof(Button))]
    public class HighlightButton : MonoBehaviour
    {
        [SerializeField] private protected Button button;
        [SerializeField] private protected CanvasGroup canvasGroup;
        private Action _onClickEvent;

        private void Reset()
        {
            button = GetComponent<Button>();
        }

        private void OnClick()
        {
            _onClickEvent?.Invoke();
        }

        public void Initialize(Action onClick)
        {
            _onClickEvent = onClick;
            button.onClick.AddListener(OnClick);
        }

        public void Show()
        {
            canvasGroup.SetActive(true);
        }

        public void Hide()
        {
            canvasGroup.SetActive(false);
        }
    }
}