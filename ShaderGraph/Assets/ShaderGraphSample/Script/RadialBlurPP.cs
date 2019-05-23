using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;

[Serializable]
[PostProcess(typeof(RadialBlurPPRenderer), PostProcessEvent.BeforeStack, "Custom/RadialBlur")]
public class RadialBlurPP : PostProcessEffectSettings
{
    public Vector2Parameter m_Center = new Vector2Parameter { value = new Vector2(0.5f, 0.5f) };

    [Range(0.0f, 2.0f), Tooltip("Sample Dist")]
    public FloatParameter m_Dist = new FloatParameter { value = 1.0f };

    [Range(0.0f, 10.0f), Tooltip("Sample Strength")]
    public FloatParameter m_Strength = new FloatParameter { value = 2.2f };
}

public sealed class RadialBlurPPRenderer : PostProcessEffectRenderer<RadialBlurPP>
{
    Shader m_MyShader = Shader.Find("Chris/RadialBlur");

    public override void Render(PostProcessRenderContext iContext)
    {
        if (m_MyShader == null)
            return;

        var _Sheet = iContext.propertySheets.Get(m_MyShader);//Shader.Find("Chris/RadialBlur"));
        _Sheet.properties.SetVector("_Center", new Vector4(settings.m_Center.value.x, settings.m_Center.value.y, 0.0f, 0.0f));
        _Sheet.properties.SetFloat("_SampleDist", settings.m_Dist);
        _Sheet.properties.SetFloat("_SampleStrength", settings.m_Strength);
        iContext.command.BlitFullscreenTriangle(iContext.source, iContext.destination, _Sheet, 0);
    }
}