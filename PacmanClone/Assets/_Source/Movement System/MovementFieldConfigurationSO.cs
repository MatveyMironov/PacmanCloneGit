using System.Collections.Generic;
using UnityEngine;

namespace MovementSystem
{
    [CreateAssetMenu(fileName = "NewMovementFieldConfigurationSO", menuName = "Movement Field Configuration")]
    public class MovementFieldConfigurationSO : ScriptableObject
    {
        [SerializeField] private List<Vector2Int> movementCells = new();

        public MovementField MovementField { get { return new(new(movementCells)); } }
    }
}
