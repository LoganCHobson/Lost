using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    private Rigidbody rb;
    private Collider col;
    
    public bool isHeldRight;
    public bool isHeldLeft;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
      
        isHeldRight = false;
        isHeldLeft = false;

    }

    private void FixedUpdate()
    {
        if (isHeldRight || isHeldLeft)
        {            
            rb.isKinematic = true;
            col.isTrigger = false;
        }
        if (Input.GetKey(KeyCode.X) && isHeldRight)
        {
            rb.isKinematic = false;
            col.isTrigger = true;
            isHeldRight = false;
        }
        if (Input.GetKey(KeyCode.Z) && isHeldLeft)
        {
            rb.isKinematic = false;
            col.isTrigger = true;
            isHeldLeft = false;
        }
    }
}
