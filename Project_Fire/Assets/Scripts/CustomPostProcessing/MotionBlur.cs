using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(MotionBlurRenderer),PostProcessEvent.AfterStack,"Custom/MotionVector",true)]
public sealed class MotionBlur : PostProcessEffectSettings
{
    [Range(0f, 0.012f), Tooltip("Distance")]
    public FloatParameter Distance = new FloatParameter { value = 0.27f };
}

public sealed class MotionBlurRenderer : PostProcessEffectRenderer<MotionBlur>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/motionBlur"));
        sheet.properties.SetFloat("_Dis", settings.Distance);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
