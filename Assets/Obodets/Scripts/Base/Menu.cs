using System;
using Obodets.Scripts.Extensions;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public enum MenuButton
    {
        Start,
        Restart,
        NextLevel
    }

    public sealed class Menu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup menu;
        [SerializeField] private SerializedDictionary<MenuButton, HighlightButton> buttons;

        private void HideButtons()
        {
            foreach (var button in buttons.Values)
            {
                button.Hide();
            }
        }

        private void Show()
        {
            menu.SetActive(true);
        }

        private void Hide()
        {
            menu.SetActive(false);
        }

        public void ActivateButton(MenuButton buttonType)
        {
            HideButtons();
            Show();

            if (!buttons.TryGetValue(buttonType, out var button)) return;

            button.Show();
        }

        public void InitializeButton(MenuButton buttonType, Action onClick, bool hideMenuOnClick = true)
        {
            if (!buttons.TryGetValue(buttonType, out var button)) return;
            
            button.Initialize(()=>
            {
                onClick?.Invoke();
                if(hideMenuOnClick) Hide();
            });
        }
    }
}