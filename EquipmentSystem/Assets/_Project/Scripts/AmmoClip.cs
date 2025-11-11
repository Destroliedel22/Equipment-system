using UnityEngine;

public class AmmoClip : MonoBehaviour, IInteractable
{
    private int bulletsInside;
    private Player playerScript;

    private void Awake()
    {
        playerScript = FindAnyObjectByType<Player>();
    }

    public void Interact()
    {
       Gun gunScript = playerScript.gameObject.GetComponent<Gun>();

        if(gunScript != null)
        {
            //gun in other hand
        }
        else
        {
            //gun not in other hand
        }
    }
}
