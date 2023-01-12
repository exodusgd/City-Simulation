using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private Transform catTransform;

    private void Start()
    {
        catTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        catTransform.position -= new Vector3(-15f * Time.deltaTime, 0, 0);
    }
}
