using System;
using System.Collections.Generic;
using Obodets.Scripts.IngredientModule;
using UnityEngine;

namespace Obodets.Scripts.LevelModule
{
    public sealed class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private TaskDisplay taskDisplay;
        private int _currentLevelIndex;
        private Action<List<IngredientBunch>> _onLevelLoaded;
        
        public LevelData GetCurrentLevelData() => gameData.GetLevel(_currentLevelIndex);

        public void Initialize(Action<List<IngredientBunch>> onLevelLoaded)
        {
            _onLevelLoaded = onLevelLoaded;
        }

        public void Load(int levelIndex)
        {
            _currentLevelIndex = levelIndex;
            var currentLevel = gameData.GetLevel(levelIndex);

            taskDisplay.SetTask(currentLevel.RequiredColor);
            _onLevelLoaded?.Invoke(currentLevel.IngredientBunches);
        }

        public void LoadNext()
        {
            var nextLevel = (_currentLevelIndex + 1) % gameData.GetLevelsCount();
            Load(nextLevel);
        }

        public void Reload()
        {
            Load(_currentLevelIndex);
        }
    }
}