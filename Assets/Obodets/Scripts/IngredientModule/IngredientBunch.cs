using System;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public sealed class IngredientBunch : MonoBehaviour
    {
        [SerializeField] private Ingredient ingredient;

        private void OnMouseDown()
        {
            throw new NotImplementedException();
        }

        public void SpawnIngredient()
        {
            Instantiate(ingredient);
        }
    }
}