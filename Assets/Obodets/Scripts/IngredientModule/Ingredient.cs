using Obodets.Scripts.AnimationModule;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private Color color;
        [SerializeField] private JumpAnimator jumpAnimator;

        public Color IngredientColor => color;

        public void JumpToBlender(Transform blenderPoint)
        {
            jumpAnimator.Jump(blenderPoint.position);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}