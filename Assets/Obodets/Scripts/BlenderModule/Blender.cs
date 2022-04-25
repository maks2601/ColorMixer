using System;
using System.Collections.Generic;
using Obodets.Scripts.Extensions;
using Obodets.Scripts.IngredientModule;
using UnityEngine;

namespace Obodets.Scripts.BlenderModule
{
    public sealed class Blender : MonoBehaviour
    {
        [SerializeField] private Transform ingredientPlacePoint;
        [SerializeField] private MixButton mixButton;
        private readonly HashSet<Ingredient> _ingredients = new();
        private Action<Color> _onMixed;

        public Transform IngredientPlacePoint => ingredientPlacePoint;

        private void Awake()
        {
            mixButton.Initialize(Mix);
        }

        private void Mix()
        {
            var colors = new List<Color>();

            foreach (var ingredient in _ingredients)
            {
                colors.Add(ingredient.GetIngredientColor());
            }

            _onMixed?.Invoke(colors.CalculateAverageColor());
        }

        public void Initialize(Action<Color> onMixed)
        {
            _onMixed = onMixed;
        }
        
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }
    }
}