using UnityEngine;

namespace Obodets.Scripts.Extensions
{
    public static class CanvasGroupExtension
    {
        public static void SetActive(this CanvasGroup group, bool active)
        {
            group.alpha = active ? 1f : 0f;
            group.interactable = active;
            group.blocksRaycasts = active;
        }
    }
}