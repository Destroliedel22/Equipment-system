using System.Collections;
using UnityEngine;

public class AmmoClip : MonoBehaviour, IInteractable
{
    private int bulletsInside;
    private Player playerScript;
    private bool canInteract;

    private void Awake()
    {
        playerScript = FindAnyObjectByType<Player>();
        bulletsInside = 16;
        canInteract = true;
    }

    public void Interact()
    {
       Gun gunScript = playerScript.gameObject.GetComponentInChildren<Gun>();

        if(gunScript != null && canInteract)
        {
            ReloadGun(gunScript);
        }
        else
        {
            //gun not in other hand
        }
    }

    private void ReloadGun(Gun gun)
    {
        if(gun.bullets < 17)
        {
            canInteract = false;
            gun.bullets += bulletsInside;
            if(gun.bullets > 17)
                gun.bullets = 17;
            StartCoroutine(DestroyClip());
        }
        else
        {
            //Gun is full
        }
    }

    public IEnumerator DestroyClip()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}