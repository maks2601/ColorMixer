using DG.Tweening;
using UnityEngine;

namespace Obodets.Scripts.AnimationModule
{
    public sealed class LidAnimator : MonoBehaviour
    {
        [SerializeField] private float openDuration;
        [SerializeField] private float closeDuration;
        [SerializeField] private Vector3 endRotation;
        private Vector3 _startRotation;

        private void Awake()
        {
            _startRotation = transform.localRotation.eulerAngles;
        }

        public void Open(Sequence sequence)
        {
            sequence.Append(transform.DOLocalRotate(endRotation, openDuration).SetEase(Ease.Flash));
        }

        public void Close(Sequence sequence)
        {
            sequence.Append(transform.DOLocalRotate(_startRotation, closeDuration).SetEase(Ease.Flash));
        }
    }
}