using System.Collections.Generic;
using UnityEngine;

namespace Obodets.Scripts.IngredientModule
{
    public class BunchesSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPlaces;

        public void Spawn(List<IngredientBunch> bunches, Transform blenderPoint)
        {
            for (var i = 0; i < bunches.Count; i++)
            {
                var bunch = Instantiate(bunches[i], spawnPlaces[i]);
                bunch.Initialize(blenderPoint);
            }
        }
    }
}