using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Obodets.Scripts.Base
{
    public class PercentSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text percentText;

        public void SetValue(int value)
        {
            slider.value = value;
            percentText.text = $"{value}%";
        }
    }
}