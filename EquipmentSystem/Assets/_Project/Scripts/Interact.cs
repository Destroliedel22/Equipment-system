using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;



    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();

        PlayerInput.Player.Interact.performed += OnInteract;
        PlayerInput.Player.Interact.canceled += OnInteractCanceled;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {

    }

    private void OnInteractCanceled(InputAction.CallbackContext context)
    {

    }
}
