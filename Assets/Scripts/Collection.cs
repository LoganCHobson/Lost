using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public int completion;
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Gascan" || other.gameObject.name == "Tire" || other.gameObject.name == "Battery")
        {
            completion++;
        }
    }

    private void Update()
    {
        if(completion == 3)
        {
            door.SetActive(false);
        }
    }
}
