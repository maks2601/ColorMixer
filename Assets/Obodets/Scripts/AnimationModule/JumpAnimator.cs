using DG.Tweening;
using UnityEngine;

namespace Obodets.Scripts.AnimationModule
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class JumpAnimator : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float jumpPower;
        [SerializeField] private float duration;

        private void Reset()
        {
            rb = GetComponent<Rigidbody>();
        }
        
        public void Jump(Vector3 finalPoint)
        {
            rb.DOJump(finalPoint, jumpPower, 1, duration);
        }
    }
}