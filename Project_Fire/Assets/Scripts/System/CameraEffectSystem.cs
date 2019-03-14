using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CameraShake
{
    public float Duration;
    public int Strength;
    public AnimationCurve StrengthCurve;
}

[Serializable]
public struct RadialBlur
{
    public float Duration;
    public float Strength;
    public float Distance;
    public AnimationCurve StrengthCurve;
    public AnimationCurve DistanceCurve;
    [HideInInspector]
    public float startTime;
    [HideInInspector]
    public float deltaTime;
    [HideInInspector]
    public float strength;
    [HideInInspector]
    public float dist;
    [HideInInspector]
    public float ratio;
    [HideInInspector]
    public int ID_BlurStrength;
    [HideInInspector]
    public int ID_BlurDistance;
}

[Serializable]
public struct TimeScale
{
    public float Duration;
    public AnimationCurve TimeScaleCurve;
}

[Serializable]
public struct MotionVector
{
    public float Duration;
    [Range(0,0.1f)]
    public float Strength;
    public AnimationCurve StrengthCurve;
    [HideInInspector]
    public float startTime;
    [HideInInspector]
    public float deltaTime;
    [HideInInspector]
    public float strength;
    [HideInInspector]
    public float ratio;
    [HideInInspector]
    public int ID_Strength;
}

public class CameraEffectSystem : MonoBehaviour
{
    static public CameraEffectSystem Instance;

    [Header("Camera Shake")]
    public CameraShake cameraShake;
    [Header("Radial Blur")]
    public RadialBlur radialBlur;
    [Header("Time Scale Control")]
    public TimeScale timeScale;
    [Header("Motion Vector")]
    public MotionVector motionVector;

    private Camera mainCamera;
    private Material RadialBlur_Mat;
    private Material MotionVector_Mat;
    private bool motionVectorIsOpen;
    private bool radialBlurIsOpen;
    RenderTexture rt;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //init
        mainCamera = Camera.main;

        UnityEngine.Object obj = Resources.Load("Material/radialBlur");
        RadialBlur_Mat = Instantiate(obj) as Material;

        obj = Resources.Load("Material/motionVector");
        MotionVector_Mat = Instantiate(obj) as Material;

        radialBlurIsOpen = false;
        motionVectorIsOpen = false;

        radialBlur.ID_BlurDistance = Shader.PropertyToID("_BlurDist");
        radialBlur.ID_BlurStrength = Shader.PropertyToID("_BlurStrength");
        motionVector.ID_Strength = Shader.PropertyToID("_Strength");

        rt = new RenderTexture(Screen.width, Screen.height, 0);
    }

    public void FRaidalBlurShock()
    {
        radialBlurIsOpen = true;
        radialBlur.startTime = Time.realtimeSinceStartup;
        radialBlur.deltaTime = 0;
    }

    public void FMotionVector()
    {
        motionVectorIsOpen = true;
        motionVector.startTime = Time.realtimeSinceStartup;
        motionVector.deltaTime = 0;
    }

    public IEnumerator FCameraShake()
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        Vector3 originalPos = mainCamera.transform.position;
        float ratio;
        while(deltaTime < cameraShake.Duration)
        {
            ratio = deltaTime / cameraShake.Duration;
            float strength = cameraShake.StrengthCurve.Evaluate(ratio);
            mainCamera.transform.position = originalPos + UnityEngine.Random.insideUnitSphere * cameraShake.Strength;
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
        while(deltaTime < timeScale.Duration)
        {
            ratio = deltaTime / timeScale.Duration;
            scale = timeScale.TimeScaleCurve.Evaluate(ratio);

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
        
        if((!radialBlurIsOpen) && (!motionVectorIsOpen))
            Graphics.Blit(source, destination);
        else
        {
            InvokeRadialBlur(source, rt);
            InvokeMotionVector(rt, destination);
        }
    }

    private void InvokeRadialBlur(RenderTexture source, RenderTexture destination)
    {
        if (radialBlurIsOpen)
        {
            radialBlur.ratio = radialBlur.deltaTime / radialBlur.Duration;
            radialBlur.strength = radialBlur.StrengthCurve.Evaluate(radialBlur.ratio);
            radialBlur.dist = radialBlur.DistanceCurve.Evaluate(radialBlur.ratio);

            RadialBlur_Mat.SetFloat(radialBlur.ID_BlurStrength, radialBlur.strength * radialBlur.Strength);
            RadialBlur_Mat.SetFloat(radialBlur.ID_BlurDistance, radialBlur.dist * radialBlur.Distance);

            Graphics.Blit(source, destination, RadialBlur_Mat);
            radialBlur.deltaTime = Time.realtimeSinceStartup - radialBlur.startTime;

            if (radialBlur.deltaTime > radialBlur.Duration)
            {
                radialBlurIsOpen = false;
            }
        }
        else
            Graphics.Blit(source, destination);
    }

    private void InvokeMotionVector(RenderTexture source, RenderTexture destination)
    {
        if(motionVectorIsOpen)
        {
            motionVector.ratio = motionVector.deltaTime / motionVector.Duration;
            motionVector.strength = motionVector.StrengthCurve.Evaluate(motionVector.ratio);

            MotionVector_Mat.SetFloat(motionVector.ID_Strength, motionVector.strength * motionVector.Strength);

            Graphics.Blit(source, destination, MotionVector_Mat);
            motionVector.deltaTime = Time.realtimeSinceStartup - motionVector.startTime;

            if (motionVector.deltaTime > motionVector.Duration)
            {
                motionVectorIsOpen = false;
            }
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
