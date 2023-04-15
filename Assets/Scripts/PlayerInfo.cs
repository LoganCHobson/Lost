using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FearState { TIER1, TIER2, TIER3, TIER4 }

public class PlayerInfo : MonoBehaviour
{
    public Slider slider;

    public FearState state;


    // Update is called once per frame
    void Update()
    {
        slider.value -= Time.deltaTime;

        switch (slider.value)
        {
            case 75:
                state = FearState.TIER1;
                break;

            case 50:
                state = FearState.TIER2;
                break;

            case 25:
                state = FearState.TIER3;
                break;

            case 0:
                state = FearState.TIER4;
                break;
        }
    }
}
