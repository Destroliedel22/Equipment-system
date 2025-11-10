using UnityEngine;

public class Player : MonoBehaviour
{
    public bool RHandHasItem;
    public GameObject RHand;
    public GameObject RHandItem;
    public bool LHandHasItem;
    public GameObject LHand;
    public GameObject LHandItem;

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
}