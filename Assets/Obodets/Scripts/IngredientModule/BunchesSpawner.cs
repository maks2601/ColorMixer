using System;
using System.Collections.Generic;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public sealed class BunchesSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPlaces;
        private readonly List<IngredientBunch> _bunches = new();
        
        public void Spawn(List<IngredientBunch> bunches, Transform blenderPoint, Action<Ingredient> onAddedToBlender)
        {
            foreach (var bunch in _bunches)
            {
                bunch.Destroy();
            }
            
            _bunches.Clear();
            
            for (var i = 0; i < bunches.Count; i++)
            {
                var bunch = Instantiate(bunches[i], spawnPlaces[i]);
                bunch.Initialize(blenderPoint, onAddedToBlender);
                _bunches.Add(bunch);
            }
        }
    }
}