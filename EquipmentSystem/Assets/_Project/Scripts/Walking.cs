using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walking : MonoBehaviour
{
    public InputSystem_Actions PlayerInput;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float drag;

    private Rigidbody m_Rigidbody;
    private Vector3 movement;

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
        m_Rigidbody.AddForce(movement * walkSpeed);
    }

    private void OnWalk(InputAction.CallbackContext context)
    {
        m_Rigidbody.linearDamping = 0;
        Vector2 input = context.ReadValue<Vector2>();
        movement = new Vector3(input.x, 0, input.y);
    }
    private void OnWalkCanceled(InputAction.CallbackContext context)
    {
        movement = Vector2.zero;
        m_Rigidbody.linearDamping = drag;
    }
}
