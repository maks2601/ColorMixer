using System;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public sealed class IngredientBunch : MonoBehaviour
    {
        [SerializeField] private Ingredient ingredientPrefab;
        private Transform _blenderPoint;
        private Action<Ingredient> _onAddedToBlender;

        private void OnMouseDown()
        {
            var ingredient = SpawnIngredient();
            ingredient.JumpToBlender(_blenderPoint);
            _onAddedToBlender?.Invoke(ingredient);
        }

        private Ingredient SpawnIngredient()
        {
            return Instantiate(ingredientPrefab, transform.position, transform.rotation);
        }

        public void Initialize(Transform blenderPoint, Action<Ingredient> onAddedToBlender)
        {
            _blenderPoint = blenderPoint;
            _onAddedToBlender = onAddedToBlender;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}