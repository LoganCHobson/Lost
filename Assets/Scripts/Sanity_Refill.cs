using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sanity_Refill : MonoBehaviour
{
    public int maxSanity;
    public int currentSanity;
    public int refillAmount;
    public PlayerInfo playerInfo;
    public PlayerInventory playerInventory;
    public Item_Pickup isHeld;


    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = playerInfo.slider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Consumable" && playerInventory.inLeftHand || playerInventory.inRightHand )
        {
            Debug.Log("Found Pills!");
        }
    }

    public void RefillSanity()
    {
        playerInfo.slider.value = refillAmount;
    }
}
