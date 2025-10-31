using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float interactDistance;

    private GameObject Crosshair;
    private float interactInput;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        Crosshair = GameObject.FindWithTag("Crosshair");

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
            if (Physics.Raycast(transform.position, Crosshair.transform.forward, out hit, interactDistance, LayerMask.NameToLayer("Interactable")))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green);
                hit.transform.GetComponent<IInteractable>().PickUp();
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
