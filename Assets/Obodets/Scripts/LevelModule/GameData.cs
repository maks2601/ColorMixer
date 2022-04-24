using System.Collections.Generic;
using UnityEngine;

namespace Obodets.Scripts.LevelModule
{
    [CreateAssetMenu(menuName = "Obodets/GameData", fileName = "GameData", order = 0)]
    public sealed class GameData : ScriptableObject
    {
        [ReorderableList(ListStyle.Boxed)] [SerializeField]
        private List<LevelData> levelsData;

        public LevelData GetLevel(int index) => levelsData[index];
    }
}