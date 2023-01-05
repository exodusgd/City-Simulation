using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipelineSwitcher : MonoBehaviour
{
    [SerializeField]
    private RenderPipelineAsset vertexPipeline;
    [SerializeField]
    private RenderPipelineAsset pixelPipeline;

    private SwapableAssetScript[] swapables;

    private void Start()
    {
        swapables = FindObjectsOfType<SwapableAssetScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            useFlatObjects(true);
            QualitySettings.renderPipeline = vertexPipeline;
            Debug.Log("Using flat shading");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            useFlatObjects(false);
            QualitySettings.renderPipeline = vertexPipeline;
            Debug.Log("Using vertex shading");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            useFlatObjects(false);
            QualitySettings.renderPipeline = pixelPipeline;
            Debug.Log("Using pixel shading");
        }
    }

    // Method that switches visibility between flat and smooth objects
    private void useFlatObjects(bool value)
    {
        foreach (SwapableAssetScript swap in swapables)
        {
            swap.setFlatMesh(value);
        }
    }
}
