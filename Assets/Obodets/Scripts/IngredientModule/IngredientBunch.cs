using System;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public sealed class IngredientBunch : MonoBehaviour
    {
        [SerializeField] private Ingredient ingredientPrefab;
        private Transform _blenderPoint;

        private void OnMouseDown()
        {
            var ingredient = SpawnIngredient();
            ingredient.AddToBlender(_blenderPoint);
        }

        private Ingredient SpawnIngredient()
        {
            return Instantiate(ingredientPrefab, transform.position, transform.rotation);
        }

        public void Initialize(Transform blenderPoint)
        {
            _blenderPoint = blenderPoint;
        }
    }
}