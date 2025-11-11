using UnityEngine;
using UnityEngine.InputSystem;

public class Look : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;
    [Range(0, 200)] public float mouseSensitivity = 100f;

    private GameObject Camera;
    private float xRotation = 0f;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();
        Camera = GetComponentInChildren<Camera>().gameObject;

        //Get the input from the input actions and activate the function
        PlayerInput.Player.Look.performed += LookAround;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    //Moves the camera to where the mouse input is going
    private void LookAround(InputAction.CallbackContext context)
    {
        //The value the input gives
        Vector2 input = context.ReadValue<Vector2>();

        float mouseX = input.x * mouseSensitivity * Time.deltaTime;
        float mouseY = input.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);
        Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
