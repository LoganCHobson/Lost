using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject grabbedItem;

    public bool inLeftHand { get; private set; }
    public bool inRightHand { get; private set; }

    public GameObject rightHand;
    public GameObject leftHand;



    private void Start()
    {
        inLeftHand = false;
        inRightHand = false;
    }
    public void pickup()
    {
        grabbedItem = GetComponent<Collection_System>().grabbedObj;
        if (!inRightHand)
        {
            Debug.Log("Right Hand!");
            grabbedItem.transform.parent = rightHand.transform;
            inRightHand = true;
            
        }

       /*if (inRightHand)
        {
            Debug.Log("Left Hand!");
            grabbedItem.transform.parent = leftHand.transform;
            inLeftHand = true;
        }*/
    }
    public void RightHandDrop()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRightHand)
        {
            
            inRightHand = false;
        }
       
    }
}
