using System;
using Obodets.Scripts.Extensions;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public class MatchCalculator : MonoBehaviour
    {
        [SerializeField] private PercentSlider slider;
        [SerializeField] private int requiredPercentToComplete;
        private const int Percent = 100;

        private void Awake()
        {
            slider.SetValue(0);
        }

        public bool Match(Color resultColor, Color requiredColor)
        {
            var ratio = resultColor.CalculateColorDifference(requiredColor) * Percent;
            slider.SetValue(Convert.ToInt32(ratio));
            return ratio >= requiredPercentToComplete;
        }
    }
}