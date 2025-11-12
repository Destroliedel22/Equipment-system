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
            gunScript.Reload(bulletsInside);
            bulletsInsideText.text = "0";
            this.gameObject.tag = "Untagged";
            Player.Instance.DropWithoutInput(this.gameObject);
        }
        else
        {
            //gun not in other hand
        }
    }


}