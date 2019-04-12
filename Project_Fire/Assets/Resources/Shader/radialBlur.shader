Shader "Hidden/radialBlur"
{
	HLSLINCLUDE
	#include"Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
	TEXTURE2D_SAMPLER2D(_MainTex,sampler_MainTex);
	
	float _BlurStrength;
	float _BlurDist;

	#define cycles 4
	float4 frag(VaryingsDefault i): SV_Target
	{
		float2 uv = i.texcoord;
		float2 dir = float2(0.5,0.5) - uv;
		float dist = length(dir);
		float4 color = _MainTex.Sample(sampler_MainTex,uv);
		float4 sampleColor = color;
				
		for(int i = 0; i < cycles; i++)
		{
			sampleColor += _MainTex.Sample(sampler_MainTex, uv+dir * 0.01 * i * _BlurDist);
		}
		sampleColor /= (cycles+1);
		float t = saturate(dist * _BlurStrength);
		return lerp(color,sampleColor,t);
	}

	ENDHLSL
    SubShader
    {
       pass{
			Cull Off ZWrite Off ZTest Always

			HLSLPROGRAM
			#pragma vertex VertDefault 
			#pragma fragment frag
			ENDHLSL
	   }
    }
}
