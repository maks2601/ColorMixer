using System.Collections.Generic;
using Obodets.Scripts.BlenderModule;
using Obodets.Scripts.IngredientModule;
using Obodets.Scripts.LevelModule;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private HighlightButton startButton;
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private BunchesSpawner bunchesSpawner;
        [SerializeField] private Blender blender;
        [SerializeField] private MatchCalculator matchCalculator;

        private void Awake()
        {
            startButton.Initialize(StartGame);
        }

        private void StartGame()
        {
            blender.Initialize(OnMixed);
            levelLoader.LoadLevel(0, OnLevelLoaded);
            startButton.Hide();
        }

        private void OnLevelLoaded(List<IngredientBunch> bunches)
        {
            bunchesSpawner.Spawn(bunches, blender.IngredientPlacePoint, blender.AddIngredient);
        }

        private void OnMixed(Color resultColor)
        {
            var result = matchCalculator.Match(resultColor, levelLoader.GetCurrentLevelData().RequiredColor);
        }
    }
}