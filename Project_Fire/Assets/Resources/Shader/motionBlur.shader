Shader "Hidden/motionBlur"
{
    Properties
    {
		_MainTex("MainTex",2D)="white"{}
		_Dis ("Distance",Range(0,0.5)) = 0.1
		[NoScaleOffset]_SampleTex ("Sample Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

			sampler2D _SampleTex;
            sampler2D _MainTex;
			float _Strength;
			float _Dis;

            fixed4 frag (v2f i) : SV_Target
            {
				//float strength = _Strength * tex2D(_SampleTex, i.uv).r;
				//float2 uv = i.uv + float2(_Dis,0);
    //            fixed4 sampleCol = tex2D(_MainTex, uv);
                fixed4 originalCol = tex2D(_MainTex, i.uv);
				float2 uv;
				float4 sampleCol = float4(0,0,0,1);
				uv = i.uv + float2(_Dis/5.0f * 1,0);
				sampleCol += tex2D(_MainTex,uv);
				uv = i.uv + float2(_Dis/5.0f * 2,0);
				sampleCol += tex2D(_MainTex,uv);
				uv = i.uv + float2(_Dis/5.0f * 3,0);
				sampleCol += tex2D(_MainTex,uv);
				uv = i.uv + float2(_Dis/5.0f * 4,0);
				sampleCol += tex2D(_MainTex,uv);
				uv = i.uv + float2(_Dis/5.0f * 5,0);
				sampleCol += tex2D(_MainTex,uv);
				fixed4 col = (sampleCol + originalCol)/6.0f;
				//fixed4 col = lerp(sampleCol, originalCol, _Strength);
                return col;
            }
            ENDCG
        }
    }
}
