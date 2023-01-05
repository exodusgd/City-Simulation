using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapableAssetScript : MonoBehaviour
{
    [SerializeField]
    private Mesh smoothMesh;
    [SerializeField]
    private Mesh flatMesh;

    public void setFlatMesh(bool value)
    {
          GetComponent<MeshFilter>().mesh = value ? flatMesh: smoothMesh;
    }
}
