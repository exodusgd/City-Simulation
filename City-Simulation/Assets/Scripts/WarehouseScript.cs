using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseScript : MonoBehaviour
{
    private DayNightSwitcher dayNightSwitcher;

    void Start()
    {
        dayNightSwitcher = FindObjectOfType<DayNightSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dayNightSwitcher.IsDay())
        {
            dayNightSwitcher.SetNight();
        }
        else
        {
            dayNightSwitcher.SetDay();
        }
        
    }

}
