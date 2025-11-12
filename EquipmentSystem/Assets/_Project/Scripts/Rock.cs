using UnityEngine;

public class Rock : MonoBehaviour, IInteractable
{
    [Range(10, 50)]public float ForceStrength;
    [Range(0, 1)]public float InheritFactor;

    private Rigidbody rb;
    private Camera camera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        camera = FindAnyObjectByType<Camera>();
    }

    public void Interact()
    {
        Player.Instance.DropWithoutInput(this.gameObject);
        Vector3 force = camera.transform.forward * ForceStrength + Player.Instance.GetComponent<Rigidbody>().linearVelocity * InheritFactor;
        rb.linearVelocity = force;
    }
}
