using UnityEngine;
using UnityEngine.InputSystem;

public class Drop : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    private float dropInput;
    private float gearDropInput;
    private bool Dropped;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();

        //Get the input from the input actions and activate the function
        PlayerInput.Player.Drop.performed += OnDrop;
        PlayerInput.Player.Drop.canceled += OnDropCanceled;
        PlayerInput.Player.GearDrop.performed += OnGearDrop;
        PlayerInput.Player.GearDrop.canceled += OnGearDropCanceled;
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
            Player.Instance.Drop();
            Dropped = true;
        }

        if(gearDropInput > 0 && !Dropped)
        {
            Player.Instance.GearDrop();
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

    private void OnGearDrop(InputAction.CallbackContext context)
    {
        //The value the input gives
        gearDropInput = context.ReadValue<float>();
        Dropped = false;
    }

    private void OnGearDropCanceled(InputAction.CallbackContext context)
    {
        //The value the input gives
        gearDropInput = context.ReadValue<float>();
    }
}
