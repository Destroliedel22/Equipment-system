using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();

        PlayerInput.Player.Move.performed += OnWalk;
        PlayerInput.Player.Move.canceled += OnWalkCanceled;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
    }
    private void OnWalkCanceled(InputAction.CallbackContext context)
    {

    }
}
