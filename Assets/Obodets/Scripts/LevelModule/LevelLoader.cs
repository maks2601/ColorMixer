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
        
        public LevelData GetCurrentLevelData() => gameData.GetLevel(_currentLevelIndex);
        
        public void LoadLevel(int levelIndex, Action<List<IngredientBunch>> onLevelLoaded)
        {
            _currentLevelIndex = levelIndex;
            var currentLevel = gameData.GetLevel(levelIndex);

            taskDisplay.SetTask(currentLevel.RequiredColor);
            onLevelLoaded?.Invoke(currentLevel.IngredientBunches);
        }
    }
}