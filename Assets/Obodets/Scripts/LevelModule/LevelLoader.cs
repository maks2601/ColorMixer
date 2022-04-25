using Obodets.Scripts.IngredientModule;
using UnityEngine;

namespace Obodets.Scripts.LevelModule
{
    public sealed class LevelLoader : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private TaskDisplay taskDisplay;
        [SerializeField] private BunchesSpawner bunchesSpawner;

        public void LoadLevel(int levelIndex, Transform blenderPoint)
        {
            var currentLevel = gameData.GetLevel(levelIndex);

            taskDisplay.SetTask(currentLevel.RequiredColor);
            bunchesSpawner.Spawn(currentLevel.IngredientBunches, blenderPoint);
        }
    }
}