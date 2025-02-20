using MovementSystem;
using System;
using System.Numerics;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputListener
    {
        private readonly PlayerControls _playerControls;

        private readonly Movement _movement;

        private readonly Vector2 up = new Vector2(0, 1);
        private readonly Vector2 down = new Vector2(0, -1);
        private readonly Vector2 right = new Vector2(1, 0);
        private readonly Vector2 left = new Vector2(-1, 0);

        public InputListener(Movement movement)
        {
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));

            _playerControls = new();

            _playerControls.MainActionMap.Move.started += OnMoveInput;
            _playerControls.MainActionMap.Move.performed += OnMoveInput;
            _playerControls.MainActionMap.Move.canceled += OnMoveInput;

            _playerControls.MainActionMap.Enable();
        }

        private void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();

            if (movementInput != null)
            {
                if (movementInput == up)
                {
                    _movement.SetDirection(Movement.Direction.Up);
                }
                else if (movementInput == down)
                {
                    _movement.SetDirection(Movement.Direction.Down);
                }
                else if (movementInput == right)
                {
                    _movement.SetDirection(Movement.Direction.Right);
                }
                else if (movementInput == left)
                {
                    _movement.SetDirection(Movement.Direction.Left);
                }
                else
                {
                    _movement.SetDirection(Movement.Direction.None);
                }
            }
        }
    }
}