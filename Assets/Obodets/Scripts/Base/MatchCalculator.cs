using System;
using Obodets.Scripts.Extensions;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public class MatchCalculator : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private PercentSlider slider;
        [SerializeField] private int requiredPercentToComplete;
        private const int Percent = 100;

        private void Awake()
        {
            canvasGroup.SetActive(false);
        }

        public void Initialize()
        {
            slider.SetValueInstant(0);
            canvasGroup.SetActive(true);
        }

        public void ResetPercent()
        {
            slider.ResetValue();
        }

        public bool Match(Color resultColor, Color requiredColor)
        {
            var ratio = resultColor.CalculateColorDifference(requiredColor) * Percent;
            slider.SetValue(Convert.ToInt32(ratio));
            return ratio >= requiredPercentToComplete;
        }
    }
}