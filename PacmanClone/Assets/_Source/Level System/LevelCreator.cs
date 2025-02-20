using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelSystem
{
    public class LevelCreator
    {
        private readonly Grid _grid;
        private readonly GameObject _passagePrefab;
        private readonly Transform _passagesRoot;

        private readonly List<GameObject> _passages = new();

        public LevelCreator(Grid grid, GameObject passagePrefab, Transform passagesRoot)
        {
            _grid = grid != null ? grid : throw new ArgumentNullException(nameof(grid));
            _passagePrefab = passagePrefab != null ? passagePrefab : throw new ArgumentNullException(nameof(passagePrefab));
            _passagesRoot = passagesRoot != null ? passagesRoot : throw new ArgumentNullException(nameof(passagesRoot));
        }

        public void CreateLevel(LevelMapSO levelMap)
        {
            DestroyLevel();

            foreach (var position in levelMap.PassagesPositions)
            {
                GameObject passage = UnityEngine.Object.Instantiate(_passagePrefab, _passagesRoot);

                Vector3Int cellPosition = new(position.x, position.y, 0);
                passage.transform.position = _grid.CellToWorld(cellPosition);
            }
        }

        public void DestroyLevel()
        {
            foreach (var wall in _passages)
            {
                if (wall != null)
                {
                    if (wall.gameObject != null)
                    {
                        UnityEngine.Object.Destroy(wall.gameObject);
                    }
                }
            }

            _passages.Clear();
        }
    }
}
