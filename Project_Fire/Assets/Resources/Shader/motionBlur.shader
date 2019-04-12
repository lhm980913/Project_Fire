Shader "Hidden/motionBlur"
{
    HLSLINCLUDE
		#include"Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex,sampler_MainTex);
		TEXTURE2D(_SampleTex);
		float _Dis;

		float4 frag (VaryingsDefault i) : SV_Target
        {
            float4 originalCol = _MainTex.Sample(sampler_MainTex,i.texcoord);
			float2 uv;
			float4 sampleCol = float4(0,0,0,1);
			uv = i.texcoord + float2(_Dis/5.0f * 1,0);
			sampleCol += _MainTex.Sample(sampler_MainTex,uv);
			uv = i.texcoord + float2(_Dis/5.0f * 2,0);
			sampleCol += _MainTex.Sample(sampler_MainTex,uv);
			uv = i.texcoord + float2(_Dis/5.0f * 3,0);
			sampleCol += _MainTex.Sample(sampler_MainTex,uv);
			uv = i.texcoord + float2(_Dis/5.0f * 4,0);
			sampleCol += _MainTex.Sample(sampler_MainTex,uv);
			uv = i.texcoord + float2(_Dis/5.0f * 5,0);
			sampleCol += _MainTex.Sample(sampler_MainTex,uv);
			float4 col = (sampleCol + originalCol)/6.0f;
            return col;
        }

	ENDHLSL
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex VertDefault
            #pragma fragment frag
            ENDHLSL
        }
    }
}
