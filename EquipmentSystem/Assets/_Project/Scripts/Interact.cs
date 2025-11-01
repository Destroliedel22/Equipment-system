using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float interactDistance;

    private float interactInput;
    private GameObject MainCamera;
    private Player playerScript;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        MainCamera = GetComponentInChildren<Camera>().gameObject;
        playerScript = GetComponent<Player>();

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

    private void FixedUpdate()
    {
        if (interactInput > 0)
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

    private void OnInteract(InputAction.CallbackContext context)
    {
        interactInput = context.ReadValue<float>();
    }

    private void OnInteractCanceled(InputAction.CallbackContext context)
    {
        interactInput = context.ReadValue<float>();
    }
}
