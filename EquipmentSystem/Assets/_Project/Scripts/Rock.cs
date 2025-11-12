using UnityEngine;

public class Rock : MonoBehaviour, IInteractable
{
    [Range(10, 50)]public float ForceStrength;
    [Range(0, 1)]public float InheritFactor;

    private Rigidbody rb;
    private Rigidbody playerRb;
    private Camera camera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        camera = FindAnyObjectByType<Camera>();
    }

    private void Start()
    {
        playerRb = Player.Instance.transform.GetComponent<Rigidbody>();
    }

    //Drops the rock and add force multiplied by the velocity of the player
    public void Interact()
    {
        Player.Instance.DropWithoutInput(this.gameObject);
        Vector3 force = camera.transform.forward * ForceStrength + playerRb.linearVelocity * InheritFactor;
        rb.linearVelocity = force;
    }
}
