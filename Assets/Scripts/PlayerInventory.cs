using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject grabbedItem;

    public bool inLeftHand;
    public bool inRightHand;

    public GameObject rightHand;
    public GameObject leftHand;



    private void Start()
    {
        inLeftHand = false;
        inRightHand = false;
    }
    public void Pickup()
    {
        grabbedItem = GetComponent<Collection_System>().grabbedObj;
        if (!inRightHand || (!inRightHand && inLeftHand))
        {
            Debug.Log("Right Hand!");
            grabbedItem.transform.position = rightHand.transform.position;
            grabbedItem.transform.parent = rightHand.transform;
            inRightHand = true;
            grabbedItem.GetComponent<Item_Pickup>().isHeld = inRightHand;
        }
        
        else
        {
            Debug.Log("Left Hand!");
            grabbedItem.transform.position = leftHand.transform.position;
            grabbedItem.transform.parent = leftHand.transform;
            inLeftHand = true;
            grabbedItem.GetComponent<Item_Pickup>().isHeld = inLeftHand;
        }
        /*if (!inLeftHand && grabbedItem.transform.parent.name != "Right Hand")
        {
            Debug.Log("Left Hand!");
            grabbedItem.transform.position = leftHand.transform.position;
            grabbedItem.transform.parent = leftHand.transform;
            grabbedItem.GetComponent<Item_Pickup>().isHeld = inLeftHand;
            inLeftHand = true;
        }
        */

    }
    public void Drop()
    {
        if (Input.GetKey(KeyCode.X) && inRightHand)
        {
            rightHand.transform.DetachChildren();
            inRightHand = false;
        }
        if (Input.GetKey(KeyCode.Z) && inLeftHand)
        {
            leftHand.transform.DetachChildren();
            inLeftHand = false;
        }
    }
}
