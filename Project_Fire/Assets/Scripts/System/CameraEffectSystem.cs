﻿using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

[Serializable]
public struct CameraShake
{
    public CinemachineVirtualCamera camera;
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

[Serializable]
public struct HitPara
{
    public float Duration;
    public AnimationCurve Intensity;
    [HideInInspector]
    public float ratio;
    [HideInInspector]
    public float strength;
    [HideInInspector]
    public float startTime;
    [HideInInspector]
    public float deltaTime;
}

[Serializable]
public struct CameraZoom
{
    public float NormalFOV;
    public float ZoomFOV;
    [HideInInspector]
    public bool fovStage;
}

public class CameraEffectSystem : UnityEngine.MonoBehaviour
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
    [Header("Hit")]
    public HitPara hitEffect;
    [Header("CameraZoom")]
    public CameraZoom cameraZoom;

    private CinemachineVirtualCamera mainCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private bool motionVectorIsOpen;
    private bool radialBlurIsOpen;
    private bool hitEffectIsOpen;

    private PostProcessProfile PPP;
    private MotionBlur motionBlurSetting;
    private RadialBlur RadialBlurSetting;
    private Vignette HitEffectSetting;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //init
        if (cameraShake.camera)
        {
            mainCamera = cameraShake.camera;
        }
        else
        {
            mainCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        }
        noise = mainCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        radialBlurIsOpen = false;
        motionVectorIsOpen = false;

        PPP = GetComponent<PostProcessVolume>().sharedProfile;
        motionBlurSetting = PPP.GetSetting<MotionBlur>();
        RadialBlurSetting = PPP.GetSetting<RadialBlur>();
        HitEffectSetting = PPP.GetSetting<Vignette>();
    }

    private void Update()
    {
        InvokeRadialBlur();
        InvokeMotionVector();
        InvokeHitEffect();
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

    public void FHitEffect()
    {
        hitEffectIsOpen = true;
        HitEffectSetting.active = true;
        hitEffect.startTime = Time.realtimeSinceStartup;
        hitEffect.deltaTime = 0;
    }

    public IEnumerator FCameraShake()
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        float ratio;
        while(deltaTime < cameraShake.Duration)
        {
            ratio = deltaTime / cameraShake.Duration;
            float strength = cameraShake.StrengthCurve.Evaluate(ratio) * cameraShake.Strength;
            noise.m_AmplitudeGain = strength;
            deltaTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
    }
    public IEnumerator FCameraShake(float time,float strength)
    {
        float startTime = Time.realtimeSinceStartup;
        float deltaTime = 0;
        float ratio;
        while (deltaTime < time)
        {
            ratio = deltaTime / cameraShake.Duration;
            noise.m_AmplitudeGain = strength;
            deltaTime = Time.realtimeSinceStartup - startTime;
            yield return null;
        }
        noise.m_AmplitudeGain = 0;
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

    private void InvokeHitEffect()
    {
        if (hitEffectIsOpen)
        {
            hitEffect.ratio = hitEffect.deltaTime / hitEffect.Duration;
            hitEffect.strength = hitEffect.Intensity.Evaluate(hitEffect.ratio);
            hitEffect.deltaTime = Time.realtimeSinceStartup - hitEffect.startTime;

            HitEffectSetting.intensity.Override(hitEffect.strength);

            if(hitEffect.deltaTime > hitEffect.Duration)
            {
                hitEffectIsOpen = false;
                HitEffectSetting.active = false;
            }
        }
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
                RadialBlurSetting.active = false;   
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

    public void ZoomFov()
    {
        if (cameraZoom.fovStage == true)
        {
            mainCamera.m_Lens.FieldOfView = cameraZoom.ZoomFOV;
            cameraZoom.fovStage = false;
        }
        else
        {
            mainCamera.m_Lens.FieldOfView = cameraZoom.NormalFOV;
            cameraZoom.fovStage = true;
        }
    }
}
