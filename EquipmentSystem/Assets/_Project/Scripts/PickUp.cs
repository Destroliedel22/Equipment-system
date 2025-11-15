using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float interactDistance;

    private float PickupInput;
    private GameObject MainCamera;
    private bool objectOnCooldown;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        MainCamera = GetComponentInChildren<Camera>().gameObject;
        objectOnCooldown = false;

        //Get the input from the input actions and activate the function
        PlayerInput.Player.Pickup.performed += OnPickup;
        PlayerInput.Player.Pickup.canceled += OnPickupCanceled;
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
        PickingUp();
    }

    //Shoot a raycast to try and pickup an interactable object
    private void PickingUp()
    {
        if (PickupInput > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, interactDistance))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    PlayerActionsManager.Instance.PickUp(hit.transform.gameObject);
                }
                else if(hit.transform.CompareTag("Gear"))
                {
                    PlayerActionsManager.Instance.EquipGear(hit.transform.gameObject, hit.transform.GetComponent<GearItem>().slot);
                }
            }
        }
    }

    private void OnPickup(InputAction.CallbackContext context)
    {
        //The value the input gives
        PickupInput = context.ReadValue<float>();
    }

    private void OnPickupCanceled(InputAction.CallbackContext context)
    {
        //The value the input gives
        PickupInput = context.ReadValue<float>();
    }
}
