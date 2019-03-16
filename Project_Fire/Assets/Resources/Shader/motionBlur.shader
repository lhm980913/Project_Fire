Shader "Hidden/motionBlur"
{
    Properties
    {
		_MainTex("MainTex",2D)="white"{}
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

            fixed4 frag (v2f i) : SV_Target
            {
				float strength = _Strength * tex2D(_SampleTex, i.uv).r;
				float2 uv = i.uv + float2(strength,0);
                fixed4 sampleCol = tex2D(_MainTex, uv);
                fixed4 originalCol = tex2D(_MainTex, i.uv);
				fixed4 col = lerp(sampleCol, originalCol, _Strength);
                return col;
            }
            ENDCG
        }
    }
}
