using UnityEngine;
using UnityEngine.InputSystem;

public class Drop : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    private float dropInput;
    private Player playerScript;
    private bool Dropped;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        playerScript = GetComponent<Player>();

        //Get the input from the input actions and activate the function
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
        Dropping();
    }

    //Activating the drop function when the input is activated
    private void Dropping()
    {
        if (dropInput > 0 && !Dropped)
        {
            playerScript.Drop();
            Dropped = true;
        }
    }

    private void OnDrop(InputAction.CallbackContext context)
    {
        //The value the input gives
        dropInput = context.ReadValue<float>();
        Dropped = false;
    }

    private void OnDropCanceled(InputAction.CallbackContext context)
    {
        //The value the input gives
        dropInput = context.ReadValue<float>();
    }
}
