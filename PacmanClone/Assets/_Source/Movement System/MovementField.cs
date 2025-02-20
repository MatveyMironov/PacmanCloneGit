using System;
using System.Collections.Generic;
using UnityEngine;

namespace MovementSystem
{
    public class MovementField
    {
        private HashSet<Vector2Int> _movementCells = new();

        public MovementField(HashSet<Vector2Int> movementCells)
        {
            _movementCells = movementCells ?? throw new ArgumentNullException(nameof(movementCells));
        }

        public HashSet<Vector2Int> MovementCells { get { return new(_movementCells); } }
    }
}