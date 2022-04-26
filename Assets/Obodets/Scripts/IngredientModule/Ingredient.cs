using System.Collections.Generic;
using Obodets.Scripts.AnimationModule;
using Obodets.Scripts.Extensions;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private JumpAnimator jumpAnimator;

        public void JumpToBlender(Transform blenderPoint)
        {
            jumpAnimator.Jump(blenderPoint.position);
        }

        public Color GetIngredientColor()
        {
            var colors = new List<Color>();

            foreach (var material in meshRenderer.materials)
            {
                colors.Add(material.color);
            }

            return colors.CalculateAverageColor();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}