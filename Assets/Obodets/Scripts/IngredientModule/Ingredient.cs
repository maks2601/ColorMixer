using Obodets.Scripts.AnimationModule;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private JumpAnimator jumpAnimator;

        public void AddToBlender(Transform blenderPoint)
        {
            jumpAnimator.Jump(blenderPoint.position);
        }
    }
}