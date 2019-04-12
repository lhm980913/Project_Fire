using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(RadialBlurRenderer), PostProcessEvent.AfterStack, "Custom/RadialBlur", true)]
public sealed class RadialBlur : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Distance")]
    public FloatParameter Distance = new FloatParameter { value = 0.011f };
    [Range(0f, 1f), Tooltip("Strength")]
    public FloatParameter Stength = new FloatParameter { value = 0.2f };
}

public sealed class RadialBlurRenderer : PostProcessEffectRenderer<RadialBlur>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/radialBlur"));
        sheet.properties.SetFloat("_BlurDist", settings.Distance);
        sheet.properties.SetFloat("_BlurStrength", settings.Stength);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
