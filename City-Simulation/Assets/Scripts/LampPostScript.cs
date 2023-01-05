using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LampPostScript : MonoBehaviour
{
    [SerializeField]
    private GameObject spotLight;
    [SerializeField]
    private GameObject pointLight;

    public void setLight(bool value)
    {
        spotLight.SetActive(value);
        pointLight.SetActive(value);
    }
}
