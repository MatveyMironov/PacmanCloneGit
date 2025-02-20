using System;
using System.Collections.Generic;
using UnityEngine;

namespace MovementSystem
{
    public class Movement
    {
        private readonly Transform _movingTransform;
        private readonly Grid _grid;
        private readonly HashSet<Vector2Int> _passages;
        private readonly MovementParameters _parameters;

        private Vector2Int _currentPassage;
        private Direction _movementDirection = Direction.None;

        public Movement(Transform movingTransform, Grid grid, HashSet<Vector2Int> passages, MovementParameters parameters)
        {
            _movingTransform = movingTransform ?? throw new ArgumentNullException(nameof(movingTransform));
            _grid = grid ?? throw new ArgumentNullException(nameof(grid));
            _passages = passages ?? throw new ArgumentNullException(nameof(passages));
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }

        public void SetDirection(Direction direction)
        {
            _movementDirection = direction;
        }

        public void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_movementDirection != Direction.None)
            {
                Vector2Int targetPassage = GetTargetPassage(_movementDirection);
                Vector3Int targetPassageCellPosition = new(targetPassage.x, targetPassage.y, 0);
                Vector3 targetPassageWorldPosition = _grid.CellToWorld(targetPassageCellPosition);

                _movingTransform.position = Vector3.MoveTowards(_movingTransform.position, targetPassageWorldPosition, _parameters.MovementSpeed * Time.deltaTime);

                if (_movingTransform.position == targetPassageWorldPosition)
                {
                    _currentPassage = targetPassage;
                }
            }
        }

        private Vector2Int GetTargetPassage(Direction direction)
        {
            if (_passages.Contains(_currentPassage + GetOffset(direction)))
            {
                return _currentPassage + GetOffset(direction);
            }

            return _currentPassage;
        }

        private Vector2Int GetOffset(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return Vector2Int.up;

                case Direction.Down:
                    return Vector2Int.down;

                case Direction.Left:
                    return Vector2Int.left;

                case Direction.Right:
                    return Vector2Int.right;

                case Direction.None:
                    return Vector2Int.zero;

                default:
                    return Vector2Int.zero;
            }
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }
    }
}