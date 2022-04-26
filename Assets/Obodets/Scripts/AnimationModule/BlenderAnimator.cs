using DG.Tweening;
using UnityEngine;

namespace Obodets.Scripts.AnimationModule
{
    public sealed class BlenderAnimator : MonoBehaviour
    {
        [SerializeField] private LidAnimator lidAnimator;
        [SerializeField] private int fluctuationsCount;
        [SerializeField] private float deflection;
        [SerializeField] private float shakeDuration;
        private Sequence _sequence;

        private void Shake()
        {
            var rotation = transform.localRotation.eulerAngles;
            var rotateDuration = shakeDuration / (fluctuationsCount * 2 + 1);
            for (var i = 0; i < fluctuationsCount; i++)
            {
                _sequence.Append(transform.DOLocalRotate(rotation + Vector3.forward * deflection, rotateDuration));
                _sequence.Append(transform.DOLocalRotate(rotation - Vector3.forward * deflection, rotateDuration));
            }

            _sequence.Append(transform.DOLocalRotate(rotation, shakeDuration));
        }

        public void IngredientHit()
        {
            _sequence = DOTween.Sequence();
            lidAnimator.Open(_sequence);
            lidAnimator.Close(_sequence);
            Shake();
        }
    }
}