using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchManager : MonoBehaviour
{
    [SerializeField]
    private int dayGlitchOdds = 10;
    [SerializeField]
    private int nightGlitchOdds = 6;

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private bool debugCanGlitch = true;

    private bool isInDelay = false;
    private bool isGlitching = false;

    private enum ShadingType
    {
        Flat,
        Vertex,
        Pixel
    }

    private DayNightSwitcher dayNightSwitcher;
    private PipelineSwitcher pipelineSwitcher;

    private void Start()
    {
        dayNightSwitcher = GetComponent<DayNightSwitcher>();
        pipelineSwitcher = GetComponent<PipelineSwitcher>();
    }

    void Update()
    {
        if (!isInDelay && !isGlitching && debugCanGlitch) 
        {
            StartCoroutine(GlitchChanceDelay(1f));
        }
    }

    IEnumerator GlitchChanceDelay(float delayTime)
    {
        isInDelay = true;
        yield return new WaitForSeconds(delayTime);
        isInDelay = false;
        GlitchChance();
    }

    IEnumerator GlitchDelay(float delayTime)
    {
        isGlitching = true;
        yield return new WaitForSeconds(delayTime);
        isGlitching = false;
    }

    IEnumerator ChangeShading(ShadingType shadingType, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        switch (shadingType)
        {
            case ShadingType.Flat:
                pipelineSwitcher.SetFlatShading();
                break;
            case ShadingType.Vertex:
                pipelineSwitcher.SetVertexShading();
                break;
            case ShadingType.Pixel:
                pipelineSwitcher.SetPixelShading();
                break;
            default:
                break;
        }
    }

    IEnumerator SetOrthographic(bool value, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        playerCamera.orthographic = value;
    }

    private void GlitchChance()
    {
        if (dayNightSwitcher.IsDay())
        {
            int randomNumber = Random.Range(1, dayGlitchOdds + 1);
            if (randomNumber == 1)
            {
                DayGlitch();
            }
        }
        else
        {
            int randomNumber = Random.Range(1, nightGlitchOdds + 1);
            if (randomNumber == 1)
            {
                NightGlitch();
            }
        }
    }

    private void DayGlitch()
    {
        pipelineSwitcher.SetFlatShading();
        StartCoroutine(ChangeShading(ShadingType.Pixel, 2f));
        StartCoroutine(GlitchDelay(2f));
    }

    private void NightGlitch()
    {
        int randomNumber = Random.Range(1, 3 + 1);
        switch (randomNumber)
        {
            case 1:
            case 2:
                pipelineSwitcher.SetFlatShading();
                StartCoroutine(ChangeShading(ShadingType.Vertex, 2f));
                StartCoroutine(ChangeShading(ShadingType.Pixel, 3f));
                StartCoroutine(GlitchDelay(3f));
                break;
            case 3:
                playerCamera.orthographic = true;
                StartCoroutine(SetOrthographic(false, 2f));
                StartCoroutine(SetOrthographic(true, 3f));
                StartCoroutine(SetOrthographic(false, 3.5f));
                StartCoroutine(GlitchDelay(3.5f));
                break;
            default:
                break;
        }
    }
}
