using Obodets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Obodets.Scripts.LevelModule
{
    public class TaskDisplay : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image liquid;

        private void Awake()
        {
            HideTask();
        }

        private void HideTask()
        {
            canvasGroup.SetActive(false);
        }

        private void ShowTask()
        {
            canvasGroup.SetActive(true);
        }

        public void SetTask(Color color)
        { 
            liquid.color = color;
            ShowTask();
        }
    }
}