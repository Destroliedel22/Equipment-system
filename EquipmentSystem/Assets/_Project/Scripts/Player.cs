using UnityEngine;

public class Player : MonoBehaviour
{
    public bool RHandHasItem;
    public GameObject RHand;
    public GameObject RHandItem;
    public bool LHandHasItem;
    public GameObject LHand;
    public GameObject LHandItem;

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
}