using UnityEngine;
using UnityEngine.InputSystem;

public class Drop : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    private float dropInput;
    private Player playerScript;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        playerScript = GetComponent<Player>();

        PlayerInput.Player.Drop.performed += OnDrop;
        PlayerInput.Player.Drop.canceled += OnDropCanceled;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void FixedUpdate()
    {
        if(dropInput > 0)
        {
            playerScript.Drop();
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        dropInput = context.ReadValue<float>();
    }

    private void OnDropCanceled(InputAction.CallbackContext context)
    {
        dropInput = context.ReadValue<float>();
    }
}
