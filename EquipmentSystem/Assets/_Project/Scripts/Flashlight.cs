using UnityEngine;

public class Flashlight : MonoBehaviour, IInteractable
{
    [SerializeField] private Light pointLight;
    [SerializeField] private Light spotLight;

    public void Interact()
    {
        ActivateLight(pointLight);
        ActivateLight(spotLight);
    }

    //Activates the light if disabled and disables the light when enabled
    public void ActivateLight(Light light)
    {
        if (light.enabled)
            light.enabled = false;
        else
            light.enabled = true;
    }
}
