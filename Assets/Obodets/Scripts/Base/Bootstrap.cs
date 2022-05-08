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
        [SerializeField] private BunchesList bunchesList;
        [SerializeField] private Blender blender;
        [SerializeField] private MatchCalculator matchCalculator;
        [SerializeField] private Menu menu;
        private bool _gameResult;

        private void Start()
        {
            InitializeButtons();
            blender.OnStartMixing += CalculateResult;
            blender.OnEndMixing += DisplayResult;
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
            bunchesList.Spawn(bunches, blender.IngredientPlacePoint, blender.AddIngredient);
            bunchesList.ActiveSpawn(true);
        }

        private void CalculateResult(Color resultColor)
        {
            _gameResult = matchCalculator.Match(resultColor, levelLoader.GetCurrentLevelData().RequiredColor);
            bunchesList.ActiveSpawn(false);
        }

        private void DisplayResult()
        {
            menu.ActivateButton(_gameResult ? MenuButton.NextLevel : MenuButton.Restart);
        }
    }
}