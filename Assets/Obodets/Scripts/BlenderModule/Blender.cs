using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Obodets.Scripts.AnimationModule;
using Obodets.Scripts.Extensions;
using Obodets.Scripts.IngredientModule;
using UnityEngine;

namespace Obodets.Scripts.BlenderModule
{
    public sealed class Blender : MonoBehaviour
    {
        [SerializeField] private Transform ingredientPlacePoint;
        [SerializeField] private MixButton mixButton;
        [SerializeField] private BlenderAnimator blenderAnimator;
        [SerializeField] private LiquidAnimator liquidAnimator;
        [SerializeField] private float mixingTime;
        [SerializeField] private float clearingTime;
        private readonly HashSet<Ingredient> _ingredients = new();
        private Action<Color> _onMixed;

        public Transform IngredientPlacePoint => ingredientPlacePoint;

        private void Awake()
        {
            liquidAnimator.Empty(0);
            mixButton.Initialize(Mix);
        }

        private void Mix()
        {
            var colors = _ingredients.Select(ingredient => ingredient.GetIngredientColor()).ToList();

            var resultColor = colors.CalculateAverageColor();
            _onMixed?.Invoke(resultColor);

            liquidAnimator.SetColor(resultColor);
            liquidAnimator.Fill(mixingTime);
            StartCoroutine(Mixing());
        }

        private IEnumerator Mixing()
        {
            var iterationTime = mixingTime / _ingredients.Count;

            foreach (var ingredient in _ingredients)
            {
                ingredient.Destroy();
                yield return new WaitForSeconds(iterationTime);
            }
            
            _ingredients.Clear();
        }

        public void Clear()
        {
            liquidAnimator.Empty(clearingTime);
        }

        public void Initialize(Action<Color> onMixed)
        {
            _onMixed = onMixed;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            blenderAnimator.IngredientHit();
        }
    }
}