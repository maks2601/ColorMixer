using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Obodets.Scripts.Base
{
    public class PercentSlider : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text percentText;
        [SerializeField] private float changeDuration;
        [SerializeField] private float resetDuration;

        private void Awake()
        {
            slider.onValueChanged.AddListener(ChangePercentText);
        }

        private void ChangePercentText(float value)
        {
            percentText.text = $"{value}%";
        }

        public void SetValueInstant(int value)
        {
            slider.value = value;
        }
        
        public void SetValue(int value)
        {
            slider.DOValue(value, changeDuration).SetEase(Ease.Flash);
        }

        public void ResetValue()
        {
            slider.DOValue(0, resetDuration).SetEase(Ease.Flash);
        }
    }
}