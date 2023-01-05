using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material skyBoxDay;
    [SerializeField]
    private Material skyBoxNight;

    private bool isDay;

    private LampPostScript[] lampPosts;

    private void Start()
    {
        lampPosts = FindObjectsOfType<LampPostScript>();
        SetDay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetDay();
            Debug.Log("Set time to Day");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetNight();
            Debug.Log("Set time to Night");
        }
    }

    public void SetDay()
    {
        isDay = true;
        foreach (LampPostScript lampPost in lampPosts)
        {
            lampPost.SetLight(false);
        }
        RenderSettings.skybox = skyBoxDay;
        RenderSettings.ambientLight = new Color(0.84f, 0.85f, 0.86f);
    }

    public void SetNight()
    {
        isDay = false;
        foreach (LampPostScript lampPost in lampPosts)
        {
            lampPost.SetLight(true);
        }
        RenderSettings.skybox = skyBoxNight;
        RenderSettings.ambientLight = new Color(0.04f, 0.04f, 0.1f);
    }

    public bool IsDay()
    {
        return isDay;
    }
}
