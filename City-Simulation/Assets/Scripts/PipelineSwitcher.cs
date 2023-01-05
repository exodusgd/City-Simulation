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
            SetFlatShading();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetVertexShading();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetPixelShading();
        }
    }

    // Method that switches visibility between flat and smooth objects
    private void UseFlatObjects(bool value)
    {
        foreach (SwapableAssetScript swap in swapables)
        {
            swap.SetFlatMesh(value);
        }
    }

    public void SetFlatShading()
    {
        UseFlatObjects(true);
        QualitySettings.renderPipeline = vertexPipeline;
        Debug.Log("Using flat shading");
    }

    public void SetVertexShading()
    {
        UseFlatObjects(false);
        QualitySettings.renderPipeline = vertexPipeline;
        Debug.Log("Using vertex shading");
    }

    public void SetPixelShading()
    {
        UseFlatObjects(false);
        QualitySettings.renderPipeline = pixelPipeline;
        Debug.Log("Using pixel shading");
    }
}
