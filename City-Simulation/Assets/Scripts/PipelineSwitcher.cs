using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipelineSwitcher : MonoBehaviour
{
    [SerializeField]
    private RenderPipelineAsset vertexAsset;

    [SerializeField]
    private RenderPipelineAsset pixelAsset;

    [SerializeField]
    private GameObject sphere;

    [SerializeField]
    private GameObject sphereFlat;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sphere.SetActive(false);
            sphereFlat.SetActive(true);
            Debug.Log("Using flat shading");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sphere.SetActive(true);
            sphereFlat.SetActive(false);
            QualitySettings.renderPipeline = vertexAsset;
            Debug.Log("Using vertex shading");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sphere.SetActive(true);
            sphereFlat.SetActive(false);
            QualitySettings.renderPipeline = pixelAsset;
            Debug.Log("Using pixel shading");
        }
    }
}
