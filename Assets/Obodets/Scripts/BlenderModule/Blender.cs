using System;
using System.Collections;
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
        [SerializeField] private float mixingTime;
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

            StartCoroutine(ClearBlender());
        }

        private IEnumerator ClearBlender()
        {
            var iterationTime = mixingTime / _ingredients.Count;

            foreach (var ingredient in _ingredients)
            {
                ingredient.Destroy();
                yield return new WaitForSeconds(iterationTime);
            }
            
            _ingredients.Clear();
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