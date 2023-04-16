using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection_System : MonoBehaviour
{
    public List<string> itemTags;
    public bool pickedUp = false;
    [HideInInspector]
    public GameObject grabbedObj;
    PlayerInventory playerInventory;
    private void Start()
    {
         playerInventory = GetComponent<PlayerInventory>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
      
        if (itemTags.Contains(other.gameObject.tag) && !pickedUp)
        {
            grabbedObj = other.gameObject;
            
            Debug.Log("Picked Up " + grabbedObj);
            playerInventory.Pickup();           
        }
        else
            return;
    }

    void FixedUpdate()
    {
        playerInventory.Drop();
    }

   
}
