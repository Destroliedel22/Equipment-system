using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Walking : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float drag;

    private Rigidbody m_Rigidbody;
    private Vector3 movement;
    private Vector2 walkInput;

    private void Awake()
    {
        PlayerInput = new InputSystem_Actions();

        //Get the input from the input actions and activates the function
        PlayerInput.Player.Move.performed += OnWalk;
        PlayerInput.Player.Move.canceled += OnWalkCanceled;
    }

    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    //Moves the player towards the corresponding input direction
    private void Move()
    {
        movement = transform.right * walkInput.x + transform.forward * walkInput.y;
        m_Rigidbody.AddForce(movement * walkSpeed);
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        //Keeps the player walking without force
        m_Rigidbody.linearDamping = 0;
        //The value the input gives
        walkInput = context.ReadValue<Vector2>();
    }
    private void OnWalkCanceled(InputAction.CallbackContext context)
    {
        //Lets the player slowdown
        m_Rigidbody.linearDamping = drag;
        //The value the input gives
        walkInput = context.ReadValue<Vector2>();
    }
}
