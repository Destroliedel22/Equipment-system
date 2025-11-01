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
        movement = transform.right * walkInput.x + transform.forward * walkInput.y;
        m_Rigidbody.AddForce(movement * walkSpeed);
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        m_Rigidbody.linearDamping = 0;
        walkInput = context.ReadValue<Vector2>();
    }
    private void OnWalkCanceled(InputAction.CallbackContext context)
    {
        m_Rigidbody.linearDamping = drag;
        walkInput = context.ReadValue<Vector2>();
    }
}
