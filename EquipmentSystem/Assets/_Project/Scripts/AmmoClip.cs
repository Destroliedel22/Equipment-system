using System.Collections;
using TMPro;
using UnityEngine;

public class AmmoClip : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI bulletsInsideText;

    private int bulletsInside;
    private Player playerScript;
    private bool canInteract;

    private void Awake()
    {
        playerScript = FindAnyObjectByType<Player>();
        bulletsInside = 16;
        canInteract = true;
    }

    //Reloads the gun and unequips the clip and drops it
    public void Interact()
    {
       Gun gunScript = playerScript.gameObject.GetComponentInChildren<Gun>();

        if(gunScript != null && canInteract)
        {
            gunScript.Reload(bulletsInside);
            bulletsInsideText.text = "0";
            canInteract = false;
            this.gameObject.tag = "Untagged";
            playerScript.DropWithoutInput(this.gameObject);
        }
        else
        {
            //gun not in other hand
        }
    }


}