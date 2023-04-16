using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sanity_Refill : MonoBehaviour
{
    [Header("Sanity Variables")]
    public float maxSanity;
    public float currentSanity;
    public float refillAmount;
    public PlayerInfo playerInfo;
    public PlayerInventory playerInventory;
    public Item_Pickup isHeld;


    private void Start()
    {
        playerInventory = gameObject.GetComponent<PlayerInventory>();
        playerInfo = FindObjectOfType<PlayerInfo>();
        maxSanity = GetComponent<PlayerInfo>().slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentSanity = GetComponent<PlayerInfo>().slider.value;
        //float x = playerInfo.slider.value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Consumable")
        {
            Debug.Log("Found Pills!");
            if (playerInventory.inLeftHand || playerInventory.inRightHand == false)
            {
                playerInventory.Pickup();

                if (Input.GetKey(KeyCode.E) && playerInventory.inLeftHand || playerInventory.inRightHand)
                {
                    RefillSanity();
                }
            }
            
        }

        else
        {
            return;
        }
    }

    public void RefillSanity()
    {
        currentSanity = currentSanity += refillAmount;
    }
}
