using Obodets.Scripts.Base;
using Obodets.Scripts.LevelModule;
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
            levelLoader.LoadLevel(0);
            startButton.Hide();
        }
    }
}
