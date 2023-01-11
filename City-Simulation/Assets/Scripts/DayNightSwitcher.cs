using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material skyBoxDay;
    [SerializeField]
    private Material skyBoxNight;
    [SerializeField]
    private Color ambientColorDay = new Color(0.84f, 0.85f, 0.86f);
    [SerializeField]
    private Color ambientColorNight = new Color(0.04f, 0.04f, 0.1f);


    private static bool isDay = true;

    private LampPostScript[] lampPosts;

    private void Start()
    {
        lampPosts = FindObjectsOfType<LampPostScript>();
        if (isDay)
        {
            SetDay();
        }
        else
        {
            SetNight();
        }
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
        RenderSettings.ambientLight = ambientColorDay;
    }

    public void SetNight()
    {
        isDay = false;
        foreach (LampPostScript lampPost in lampPosts)
        {
            lampPost.SetLight(true);
        }
        RenderSettings.skybox = skyBoxNight;
        RenderSettings.ambientLight = ambientColorNight;
    }

    public bool IsDay()
    {
        return isDay;
    }
}
