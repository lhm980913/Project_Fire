Shader "Custom/radialBlur"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _BlurStrength ("Blur Strength", float) = 0.5
		_BlurDist ("Blur Dist", float) = 0.1
    }
    SubShader
    {
       pass{
			Tags{"RenderType" = "Opaque"}

			CGPROGRAM
			#pragma vertex vert 
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			#define cycles 4
			sampler2D _MainTex;
			float _BlurStrength;
			float _BlurDist;

			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(float4 vert : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(vert);
				o.uv = uv;
				return o;
			}

			fixed4 frag(v2f i): SV_Target
			{
				float2 uv = i.uv;
				float2 dir = float2(0.5,0.5) - uv;
				float dist = length(dir);
				fixed4 color = tex2D(_MainTex,uv);
				fixed4 sampleColor = color;
				
				for(int i = 0; i < cycles; i++)
				{
					sampleColor += tex2D(_MainTex, uv+dir * 0.01 * i * _BlurDist);
				}
				sampleColor /= (cycles+1);
				float t = saturate(dist * _BlurStrength);
				return lerp(color,sampleColor,t);
			}
			
			ENDCG
	   }
    }
    FallBack "Diffuse"
}
