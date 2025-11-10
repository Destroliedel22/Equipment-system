using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUp : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float interactDistance;

    private float PickupInput;
    private GameObject MainCamera;
    private Player playerScript;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        MainCamera = GetComponentInChildren<Camera>().gameObject;
        playerScript = GetComponent<Player>();

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
        if (PickupInput > 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, interactDistance))
            {
                if(hit.transform.CompareTag("Interactable"))
                {
                    playerScript.PickUp(hit.transform.gameObject);
                }
            }
        }
    }

    private void OnPickup(InputAction.CallbackContext context)
    {
        PickupInput = context.ReadValue<float>();
    }

    private void OnPickupCanceled(InputAction.CallbackContext context)
    {
        PickupInput = context.ReadValue<float>();
    }
}
