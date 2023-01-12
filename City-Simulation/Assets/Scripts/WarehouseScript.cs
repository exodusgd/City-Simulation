using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cat;

    private bool isTriggered = false;

    private Vector3 initialCatPosition;

    void Start()
    {
        initialCatPosition = cat.transform.position;
    }

    IEnumerator CatMoveDelay(bool value, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        cat.GetComponent<CatScript>().SetCanMove(value);

    }

    IEnumerator CatResetDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        cat.transform.position = initialCatPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            isTriggered = true;
            cat.GetComponent<CatScript>().SetCanMove(true);
            StartCoroutine(CatResetDelay(4.0f));
            StartCoroutine(CatMoveDelay(false, 8.0f));
        }
    }

}
