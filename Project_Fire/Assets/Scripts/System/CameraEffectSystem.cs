using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
public struct CameraShake
{
    public float Duration;
    public float Strength;
    public AnimationCurve StrengthCurve;
}

[Serializable]
public struct RadialBlurPara
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
}

[Serializable]
public struct TimeScale
{
    public float Duration;
    public AnimationCurve TimeScaleCurve;
}

[Serializable]
public struct MotionVectorPara
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
}

public class CameraEffectSystem : MonoBehaviour
{
    static public CameraEffectSystem Instance;

    [Header("Camera Shake")]
    public CameraShake cameraShake;
    [Header("Radial Blur")]
    public RadialBlurPara radialBlur;
    [Header("Time Scale Control")]
    public TimeScale timeScale;
    [Header("Motion Vector")]
    public MotionVectorPara motionVector;

    private Camera mainCamera;
    private bool motionVectorIsOpen;
    private bool radialBlurIsOpen;

    private PostProcessProfile PPP;
    private MotionBlur motionBlurSetting;
    private RadialBlur RadialBlurSetting;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //init
        mainCamera = Camera.main;

        radialBlurIsOpen = false;
        motionVectorIsOpen = false;

        PPP = GetComponent<PostProcessVolume>().sharedProfile;
        motionBlurSetting = PPP.GetSetting<MotionBlur>();
        RadialBlurSetting = PPP.GetSetting<RadialBlur>();
    }

    private void Update()
    {
        InvokeRadialBlur();
        InvokeMotionVector();
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
        motionBlurSetting.active = true;
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
    public IEnumerator FCameraShake(float time,float sterength)
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        Vector3 originalPos = mainCamera.transform.position;
        float ratio;
        while (deltaTime < time)
        {
            ratio = deltaTime / time;
            
            mainCamera.transform.position = originalPos + UnityEngine.Random.insideUnitSphere * sterength;
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
    public IEnumerator FTimeScaleControl(float time,float scale)
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
       
        while (deltaTime < time)
        {
            

            Time.timeScale = scale;

            deltaTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }
        Time.timeScale = 1;
    }

    public void FVigenette()
    {

    }

    private void InvokeRadialBlur()
    {
        if (radialBlurIsOpen)
        {
            radialBlur.ratio = radialBlur.deltaTime / radialBlur.Duration;
            radialBlur.strength = radialBlur.StrengthCurve.Evaluate(radialBlur.ratio);
            radialBlur.dist = radialBlur.DistanceCurve.Evaluate(radialBlur.ratio);
            
            radialBlur.deltaTime = Time.realtimeSinceStartup - radialBlur.startTime;

            RadialBlurSetting.Distance.Override(radialBlur.dist);
            RadialBlurSetting.Stength.Override(radialBlur.strength);

            if (radialBlur.deltaTime > radialBlur.Duration)
            {
                radialBlurIsOpen = false;
            }
        }
    }

    private void InvokeMotionVector()
    {
        if(motionVectorIsOpen)
        {
            motionVector.ratio = motionVector.deltaTime / motionVector.Duration;
            motionVector.strength = motionVector.StrengthCurve.Evaluate(motionVector.ratio);
            
            motionVector.deltaTime = Time.realtimeSinceStartup - motionVector.startTime;

            motionBlurSetting.Distance.Override(motionVector.strength * motionVector.Strength);

            if (motionVector.deltaTime > motionVector.Duration)
            {
                motionVectorIsOpen = false;
                motionBlurSetting.active = false;
            }
        }
    }
}
