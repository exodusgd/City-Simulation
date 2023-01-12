using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{

    private bool canMove = false;

    private Transform catTransform;

    private void Start()
    {
        catTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            catTransform.position -= new Vector3(-15f * Time.deltaTime, 0, 0);
        }
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
