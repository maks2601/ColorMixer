using Obodets.Scripts.BlenderModule;
using Obodets.Scripts.LevelModule;
using UnityEngine;

namespace Obodets.Scripts.Base
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LevelLoader levelLoader;
        [SerializeField] private HighlightButton startButton;
        [SerializeField] private Blender blender;

        private void Awake()
        {
            startButton.Initialize(StartGame);
        }

        private void StartGame()
        {
            levelLoader.LoadLevel(0, blender.IngredientPlacePoint);
            startButton.Hide();
        }
    }
}
