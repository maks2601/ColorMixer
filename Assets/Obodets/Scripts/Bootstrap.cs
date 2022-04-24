using Obodets.Scripts.Base;
using UnityEngine;

namespace Obodets.Scripts
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private HighlightButton startButton;

        private void Awake()
        {
            startButton.Initialize(StartGame);
        }

        private void StartGame()
        {
            levelLoader.LoadCurrentLevel();
            startButton.Hide();
        }
    }
}
