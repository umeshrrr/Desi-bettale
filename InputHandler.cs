using UnityEngine;
using UnityEngine.InputSystem; 

namespace DesiShadow.Gameplay
{
    public class InputHandler : MonoBehaviour
    {
        [Header("Input Values")]
        public Vector2 MoveInput;
        public bool IsJumpPressed;
        public bool IsFirePressed;

        // Call these methods from your UI On-Screen Buttons or Input System Events
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            IsJumpPressed = context.performed;
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            IsFirePressed = context.performed;
        }
    }
}
