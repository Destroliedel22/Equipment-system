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

    public void Interact()
    {
       Gun gunScript = playerScript.gameObject.GetComponentInChildren<Gun>();

        if(gunScript != null && canInteract)
        {
            gunScript.Reload(bulletsInside);
            bulletsInsideText.text = "0";
            canInteract = false;
            this.gameObject.tag = "Untagged";
            if (playerScript.LHandItem == this.gameObject)
            {
                playerScript.LHandHasItem = false;
            }
            else if (playerScript.RHandItem == this.gameObject)
            {
                playerScript.RHandHasItem = false;
            }
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
        }
        else
        {
            //gun not in other hand
        }
    }


}