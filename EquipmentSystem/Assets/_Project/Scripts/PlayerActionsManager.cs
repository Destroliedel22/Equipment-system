using Unity.VisualScripting;
using UnityEngine;

public class PlayerActionsManager : MonoBehaviour
{
    public static PlayerActionsManager Instance;

    public bool LHandHasItem;
    public bool RHandHasItem;
    public GameObject RHand;
    public GameObject LHand;
    public Player playerScript;

    //Singleton so you can call this script easily
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        playerScript = GameObject.FindAnyObjectByType<Player>();
    }

    private void Start()
    {
        RHand = playerScript.RHand;
        LHand = playerScript.LHand;
    }

    //Picks up an object to the right hand first and the to the left hand
    public void PickUp(GameObject item)
    {
        if (!RHandHasItem)
        {
            RHandHasItem = true;
            playerScript.RHandItem = item;
            item.transform.position = RHand.transform.position;
            item.transform.rotation = RHand.transform.rotation;
            item.transform.parent = RHand.transform;
        }
        else if (!LHandHasItem)
        {
            LHandHasItem = true;
            playerScript.LHandItem = item;
            item.transform.position = LHand.transform.position;
            item.transform.rotation = LHand.transform.rotation;
            item.transform.parent = LHand.transform;
        }
        else
        {
            //hands full
        }

        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    //Drops the item in the left hand first and then the right hand when the button is clicked
    public void Drop()
    {
        if (LHandHasItem)
        {
            LHandHasItem = false;
            playerScript.LHandItem.GetComponent<Rigidbody>().isKinematic = false;
            playerScript.LHandItem.transform.parent = null;
        }
        else if (RHandHasItem)
        {
            RHandHasItem = false;
            playerScript.RHandItem.GetComponent<Rigidbody>().isKinematic = false;
            playerScript.RHandItem.transform.parent = null;
        }
        else
        {
            //nothing equipped to be dropped
        }
    }

    //Drops the item when no input is clicked
    public void DropWithoutInput(GameObject item)
    {
        if (item == playerScript.LHandItem)
        {
            LHandHasItem = false;
            playerScript.LHandItem.GetComponent<Rigidbody>().isKinematic = false;
            playerScript.LHandItem.transform.parent = null;
        }
        else if (item == playerScript.RHandItem)
        {
            RHandHasItem = false;
            playerScript.RHandItem.GetComponent<Rigidbody>().isKinematic = false;
            playerScript.RHandItem.transform.parent = null;
        }
    }

    //Equips gear on the right part of the body
    public void EquipGear(GameObject gear, GearSlot slot)
    {
        switch (slot)
        {
            case GearSlot.Head:
                GearPosition(gear, playerScript.head);
                break;
            case GearSlot.Body:
                GearPosition(gear, playerScript.body);
                break;
            case GearSlot.Arms:
                GearPosition(gear, playerScript.arms);
                break;
            case GearSlot.Legs:
                GearPosition(gear, playerScript.legs);
                break;
        }
    }

    //Gets the position for where the gear should be equipped
    public void GearPosition(GameObject gear, GameObject gearSlot)
    {
        gear.transform.position = gearSlot.transform.position;
        gear.transform.rotation = gearSlot.transform.rotation;
        gear.transform.parent = gearSlot.transform;
        gear.GetComponent<Collider>().isTrigger = true;
        gear.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void StaticObjectInteract(GameObject staticObject)
    {
        StaticInteractable staticObjectScript = staticObject.GetComponentInParent<StaticInteractable>();
        staticObjectScript.Interact();
    }
}
