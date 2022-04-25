using UnityEngine;

namespace Obodets.Scripts.BlenderModule
{
    public sealed class Blender : MonoBehaviour
    {
        [SerializeField] private Transform ingredientPlacePoint;

        public Transform IngredientPlacePoint => ingredientPlacePoint;
    }
}