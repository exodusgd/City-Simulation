using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionText;
    [SerializeField]
    private GameObject player;

    private bool isPlayerInArea = false;
    private static Vector3 citySpawnPosition = Vector3.zero;
    private DayNightSwitcher dayNightSwitcher;


    private void Start()
    {
        dayNightSwitcher = FindObjectOfType<DayNightSwitcher>();
        if (citySpawnPosition != Vector3.zero && SceneManager.GetActiveScene().name == "CityScene")
        {
            player.transform.position = citySpawnPosition;
        }
    }

    private void Update()
    {
        if (isPlayerInArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().name == "CityScene")
                {
                    citySpawnPosition = player.transform.position;
                }
                SwitchScene();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player")
        {
            return;
        }

        interactionText.SetActive(true);
        isPlayerInArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name != "Player")
        {
            return;
        }

        interactionText.SetActive(false);
        isPlayerInArea = false;
    }

    private void SwitchScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "CityScene":
                SceneManager.LoadScene("WarehouseScene");
                break;

            case "WarehouseScene":
                if (dayNightSwitcher.IsDay())
                {
                    dayNightSwitcher.SetNight();
                }
                else
                {
                    dayNightSwitcher.SetDay();
                }
                SceneManager.LoadScene("CityScene");
                break;
        }
    }

}
