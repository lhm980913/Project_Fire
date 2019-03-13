using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectSystem : MonoBehaviour
{
    static public CameraEffectSystem Instance;

    [Header("Camera Shake")]
    public float CameraShakingTime;
    public float shakeAmount;
    public AnimationCurve CameraShakingStrength;
    [Header("Radial Blur")]
    public float BlurTotalTime;
    public float BlurStrength;
    public float BlurDistance;
    public AnimationCurve BlurStrengthCurve;
    public AnimationCurve BlurDistanceCurve;
    [Header("Time Scale Control")]
    public float Duration;
    public AnimationCurve TimeScaleCurve;

    private Camera mainCamera;
    public Material RadialBlur;
    private bool isOpen;
    private int ID_BlurStrength;
    private int ID_BlurDistance;

    float startTime;
    float deltaTime;
    float strength;
    float dist;
    float ratio;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //init
        mainCamera = Camera.main;
        //Object obj = Resources.Load("Material/radialBlur");
        //RadialBlur = Instantiate(obj) as Material;
        isOpen = false;
        ID_BlurDistance = Shader.PropertyToID("_BlurDist");
        ID_BlurStrength = Shader.PropertyToID("_BlurStrength");
    }

    private void Update()
    {

    }

    public void FRaidalBlurShock()
    {
        isOpen = true;
        startTime = Time.realtimeSinceStartup;
        deltaTime = 0;
    }

    public IEnumerator FCameraShake()
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        Vector3 originalPos = mainCamera.transform.position;
        float ratio;
        while(deltaTime < CameraShakingTime)
        {
            ratio = deltaTime / CameraShakingTime;
            float strength = CameraShakingStrength.Evaluate(ratio);
            mainCamera.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            deltaTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }
        
        mainCamera.transform.position = originalPos;
    }

    public IEnumerator FTimeScaleControl()
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        float scale;
        float ratio;
        while(deltaTime < Duration)
        {
            ratio = deltaTime / Duration;
            scale = TimeScaleCurve.Evaluate(ratio);

            Time.timeScale = scale;

            deltaTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }
        Time.timeScale = 1;
    }

    public void FVigenette()
    {

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (isOpen)
        {
            ratio = deltaTime / BlurTotalTime;
            strength = BlurStrengthCurve.Evaluate(ratio);
            dist = BlurDistanceCurve.Evaluate(ratio);

            RadialBlur.SetFloat(ID_BlurStrength, strength * BlurStrength);
            RadialBlur.SetFloat(ID_BlurDistance, dist * BlurDistance);

            Graphics.Blit(source, destination, RadialBlur);
            deltaTime = Time.realtimeSinceStartup - startTime;

            if (deltaTime > Duration)
            {
                isOpen = false;
            }
        }
        else
            Graphics.Blit(source, destination);
    }
}
