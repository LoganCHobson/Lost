using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sc;
    
    public bool isHeldRight;
    public bool isHeldLeft;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
      
        isHeldRight = false;
        isHeldLeft = false;

    }

    private void FixedUpdate()
    {
        if (isHeldRight || isHeldLeft)
        {            
            rb.isKinematic = true;
            sc.isTrigger = false;
        }
        if (Input.GetKey(KeyCode.X) && isHeldRight)
        {
            rb.isKinematic = false;
            sc.isTrigger = true;
            isHeldRight = false;
        }
        if (Input.GetKey(KeyCode.Z) && isHeldLeft)
        {
            rb.isKinematic = false;
            sc.isTrigger = true;
            isHeldLeft = false;
        }
    }
}
