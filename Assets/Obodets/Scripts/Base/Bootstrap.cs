using System.Collections.Generic;
using Obodets.Scripts.BlenderModule;
using Obodets.Scripts.IngredientModule;
using Obodets.Scripts.LevelModule;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private BunchesSpawner bunchesSpawner;
        [SerializeField] private Blender blender;
        [SerializeField] private MatchCalculator matchCalculator;
        [SerializeField] private Menu menu;

        private void Start()
        {
            InitializeButtons();
            blender.Initialize(OnMixed);
            levelLoader.Initialize(OnLevelLoaded);
            menu.ActivateButton(MenuButton.Start);
        }

        private void InitializeButtons()
        {
            menu.InitializeButton(MenuButton.Start, StartGame);
            menu.InitializeButton(MenuButton.Restart, levelLoader.Reload);
            menu.InitializeButton(MenuButton.NextLevel, levelLoader.LoadNext);
        }

        private void StartGame()
        {
            matchCalculator.Initialize();
            levelLoader.Load(0);
        }

        private void OnLevelLoaded(List<IngredientBunch> bunches)
        {
            matchCalculator.ResetPercent();
            blender.Clear();
            bunchesSpawner.Spawn(bunches, blender.IngredientPlacePoint, blender.AddIngredient);
        }

        private void OnMixed(Color resultColor)
        {
            var completed = matchCalculator.Match(resultColor, levelLoader.GetCurrentLevelData().RequiredColor);

            if (completed)
            {
                menu.ActivateButton(MenuButton.NextLevel);
                return;
            }

            menu.ActivateButton(MenuButton.Restart);
        }
    }
}