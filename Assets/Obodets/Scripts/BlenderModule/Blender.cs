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
        
        public Transform IngredientPlacePoint => ingredientPlacePoint;
        public event Action<Color> OnStartMixing;
        public event Action OnEndMixing;

        private void Awake()
        {
            liquidAnimator.Empty(0);
            mixButton.Initialize(Mix);
        }

        private void Mix()
        {
            if (_ingredients.Count == 0) return;
            
            mixButton.Active(false);
            var colors = _ingredients.Select(ingredient => ingredient.IngredientColor).ToList();

            var resultColor = colors.CalculateAverageColor();
            OnStartMixing?.Invoke(resultColor);

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
            OnEndMixing?.Invoke();
        }

        public void Clear()
        {
            mixButton.Active(true);
            liquidAnimator.Empty(clearingTime);
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            blenderAnimator.IngredientHit();
        }
    }
}