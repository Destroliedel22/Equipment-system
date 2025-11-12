using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private GameObject head;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject arms;
    [SerializeField] private GameObject legs;

    public bool RHandHasItem;
    public GameObject RHand;
    public GameObject RHandItem;
    public bool LHandHasItem;
    public GameObject LHand;
    public GameObject LHandItem;

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
    }

    //Picks up an object to the right hand first and the to the left hand
    public void PickUp(GameObject item)
    {
        if (!RHandHasItem)
        {
            RHandHasItem = true;
            RHandItem = item;
            item.transform.position = RHand.transform.position;
            item.transform.rotation = RHand.transform.rotation;
            item.transform.parent = RHand.transform;
        }
        else if (!LHandHasItem)
        {
            LHandHasItem = true;
            LHandItem = item;
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
            LHandItem.GetComponent<Rigidbody>().isKinematic = false;
            LHandItem.transform.parent = null;
        }
        else if(RHandHasItem)
        {
            RHandHasItem = false;
            RHandItem.GetComponent<Rigidbody>().isKinematic = false;
            RHandItem.transform.parent = null;
        }
        else
        {
            //nothing equipped to be dropped
        }
    }

    //Drops the item when no input is clicked
    public void DropWithoutInput(GameObject item)
    {
        if(item == LHandItem)
        {
            LHandHasItem = false;
            LHandItem.GetComponent<Rigidbody>().isKinematic = false;
            LHandItem.transform.parent = null;
        }
        else if(item == RHandItem)
        {
            RHandHasItem = false;
            RHandItem.GetComponent<Rigidbody>().isKinematic = false;
            RHandItem.transform.parent = null;
        }
    }

    //Equips gear on the right part of the body
    public void EquipGear(GameObject gear, GearSlot slot)
    {
        switch(slot)
        {
            case GearSlot.Head:
                GearPosition(gear, head);
                break;
            case GearSlot.Body:
                GearPosition(gear, body);
                break;
            case GearSlot.Arms:
                GearPosition(gear, arms);
                break;
            case GearSlot.Legs:
                GearPosition(gear, legs);
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
    }
}