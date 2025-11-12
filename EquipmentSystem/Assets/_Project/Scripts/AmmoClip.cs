using System.Collections;
using TMPro;
using UnityEngine;

public class AmmoClip : MonoBehaviour, IInteractable
{
    [SerializeField] private TextMeshProUGUI bulletsInsideText;

    private int bulletsInside;

    private void Awake()
    {
        bulletsInside = 16;
    }

    //Reloads the gun and unequips the clip and drops it
    public void Interact()
    {
       Gun gunScript = Player.Instance.gameObject.GetComponentInChildren<Gun>();

        if(gunScript != null)
        {
            int bulletsToReload = bulletsInside;
            bulletsInside = gunScript.bullets;
            bulletsInsideText.text = gunScript.bullets.ToString();
            gunScript.Reload(bulletsToReload);
            //If its empty you cannot pick it up again
            if (bulletsInside <= 0)
                this.gameObject.tag = "Untagged";
            //If the bullets exceed 16 it stays at 16
            if (bulletsInside > 16)
            {
                bulletsInside = 16;
                bulletsInsideText.text = "16";
            }
            Player.Instance.DropWithoutInput(this.gameObject);
        }
        else
        {
            //Gun not in other hand
        }
    }


}