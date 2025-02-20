using InputSystem;
using LevelSystem;
using MovementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstraper : MonoBehaviour
    {
        [SerializeField] private Grid grid;

        [Header("Level")]
        [SerializeField] private LevelMapSO levelMap;
        [SerializeField] private GameObject passagePrefab;
        [SerializeField] private Transform passagesRoot;

        [Header("Movement")]
        [SerializeField] private Transform movingTransform;
        [SerializeField] private float movementSpeed;

        private Movement movement;

        private void Awake()
        {
            LevelCreator levelCreator = new(grid, passagePrefab, passagesRoot);
            levelCreator.CreateLevel(levelMap);

            MovementParameters movementParameters = new MovementParameters();
            movementParameters.MovementSpeed = movementSpeed;

            movement = new Movement(movingTransform, grid, levelMap.PassagesPositions, movementParameters);

            InputListener inputListener = new(movement);
        }

        private void Update()
        {
            movement.Update();
        }
    }
}