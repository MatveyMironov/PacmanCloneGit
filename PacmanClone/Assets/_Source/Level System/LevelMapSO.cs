using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    [CreateAssetMenu(fileName = "NewLevelMapSO", menuName = "Level Map")]
    public class LevelMapSO : ScriptableObject
    {
        [SerializeField] private List<Vector2Int> passagesPositions = new();

        public HashSet<Vector2Int> PassagesPositions { get { return new(passagesPositions); } }
    }
}
