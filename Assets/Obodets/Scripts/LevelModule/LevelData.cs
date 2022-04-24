using System;
using System.Collections.Generic;
using Obodets.Scripts.IngredientModule;
using UnityEngine;

namespace Obodets.Scripts.LevelModule
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private List<IngredientBunch> ingredientBunches;
        [SerializeField] private Color requiredColor;

        public List<IngredientBunch> IngredientBunches => ingredientBunches;
        public Color RequiredColor => requiredColor;
    }
}