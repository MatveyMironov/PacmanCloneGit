using LevelSystem;
using MovementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private MovementFieldConfigurationSO movementMap;

        [Header("Level Creator")]
        [SerializeField] private Grid grid;
        [SerializeField] private GameObject passagePrefab;
        [SerializeField] private Transform passagesRoot;

        private void Awake()
        {
            MovementField movementField = movementMap.MovementField;

            LevelCreator levelCreator = new(grid, passagePrefab, passagesRoot);

            levelCreator.CreateLevel(movementField);
        }
    }
}