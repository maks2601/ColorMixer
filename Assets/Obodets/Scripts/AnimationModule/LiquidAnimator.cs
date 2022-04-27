using DG.Tweening;
using UnityEngine;

namespace Obodets.Scripts.AnimationModule
{
    public class LiquidAnimator : MonoBehaviour
    {
        [SerializeField] private float minSizeY;
        [SerializeField] private float maxSizeY;
        [SerializeField] private Material material;
        private const string ShallowColor = "Color_F01C36BF";
        private const string DeepColor = "Color_7D9A58EC";
        private float _sizeDifference;

        public void Empty(float time)
        {
            var positionY = transform.position.y - _sizeDifference;
            transform.DOMoveY(positionY, time);
            transform.DOScaleY(minSizeY, time);
        }

        public void Fill(float time)
        {
            _sizeDifference = maxSizeY - minSizeY;
            var positionY = transform.position.y + _sizeDifference;
            transform.DOMoveY(positionY, time);
            transform.DOScaleY(maxSizeY, time);
        }

        public void SetColor(Color color)
        {
            material.SetColor(ShallowColor, color);
            material.SetColor(DeepColor, color);
        }
    }
}