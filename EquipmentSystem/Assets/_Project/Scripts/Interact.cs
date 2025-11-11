using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    private Player playerScript;
    private float lInteractInput;
    private float rInteractInput;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        playerScript = GetComponent<Player>();

        //Get the input from the input actions and activate the function
        PlayerInput.Player.LInteract.performed += OnLInteract;
        PlayerInput.Player.LInteract.canceled += OnLInteractCanceled;
        PlayerInput.Player.RInteract.performed += OnRInteract;
        PlayerInput.Player.RInteract.canceled += OnRInteractCanceled;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void Update()
    {
        Interacting();
    }

    //Checking if you can interact with an object in hand and interacting with it
    private void Interacting()
    {
        if (lInteractInput > 0 && playerScript.LHandHasItem)
        {
            var interactable = playerScript.LHandItem.GetComponents<MonoBehaviour>().OfType<IInteractable>().FirstOrDefault();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }

        if (rInteractInput > 0 && playerScript.RHandHasItem)
        {
            var interactable = playerScript.RHandItem.GetComponents<MonoBehaviour>().OfType<IInteractable>().FirstOrDefault();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void OnLInteract(InputAction.CallbackContext context)
    {
        //The value the input gives
        lInteractInput = context.ReadValue<float>();
    }

    private void OnLInteractCanceled(InputAction.CallbackContext context)
    {
        //The value the input gives
        lInteractInput = context.ReadValue<float>();
    }

    private void OnRInteract(InputAction.CallbackContext context)
    {
        //The value the input gives
        rInteractInput = context.ReadValue<float>();
    }

    private void OnRInteractCanceled(InputAction.CallbackContext context)
    {
        //The value the input gives
        rInteractInput = context.ReadValue<float>();
    }
}
