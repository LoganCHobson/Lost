using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sc;
    
    public bool isHeld;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
      
        isHeld = false;
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {            
            rb.isKinematic = true;
            sc.isTrigger = false;
        }
        if (Input.GetKey(KeyCode.X) && isHeld)
        {
            rb.isKinematic = false;
            sc.isTrigger = true;
            isHeld = false;
        }
        if (Input.GetKey(KeyCode.Z) && isHeld)
        {
            rb.isKinematic = false;
            sc.isTrigger = true;
            isHeld = false;
        }
    }
}
