﻿Shader "VFX/JAttack_Light"
{
    Properties
    {
        [HDR]Color_F7B61C2A("Color", Color) = (1,1,1,0)
[NoScaleOffset] Texture2D_E869B265("maintex", 2D) = "white" {}
Vector1_46C14E4F("offset", Range(-0.1, 0.3)) = -0.1
Vector1_53DB4A3F("alpha_offset", Range(-0.3, 1.2)) = 0

    }
    SubShader
    {
        Tags
        {
            "RenderPipeline"="LightweightPipeline"
            "RenderType"="Transparent"
            "Queue"="Transparent+0"
        }
        Pass
        {
            Name "StandardUnlit"
            Tags{"LightMode" = "LightweightForward"}

            // Material options generated by graph

            Blend SrcAlpha OneMinusSrcAlpha

            Cull Off

            ZTest Always

            ZWrite Off

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0

            // -------------------------------------
            // Lightweight Pipeline keywords
            #pragma shader_feature _SAMPLE_GI

            // -------------------------------------
            // Unity defined keywords
            #pragma multi_compile _ DIRLIGHTMAP_COMBINED
            #pragma multi_compile _ LIGHTMAP_ON
            #pragma multi_compile_fog

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing
            
            #pragma vertex vert
            #pragma fragment frag

            // Defines generated by graph

            // Lighting include is needed because of GI
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/Shaders/UnlitInput.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float4 Color_F7B61C2A;
            float Vector1_46C14E4F;
            float Vector1_53DB4A3F;
            CBUFFER_END

            TEXTURE2D(Texture2D_E869B265); SAMPLER(samplerTexture2D_E869B265); float4 Texture2D_E869B265_TexelSize;

            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
                float4 VertexColor;
                half4 uv0;
            };


            void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
            {
                Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }

            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }

            void Unity_Multiply_float (float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
            }

            void Unity_Multiply_float (float A, float B, out float Out)
            {
                Out = A * B;
            }

            void Unity_Distance_float2(float2 A, float2 B, out float Out)
            {
                Out = distance(A, B);
            }

            void Unity_Clamp_float(float In, float Min, float Max, out float Out)
            {
                Out = clamp(In, Min, Max);
            }

            struct VertexDescription
            {
                float3 Position;
            };

            VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
            {
                VertexDescription description = (VertexDescription)0;
                description.Position = IN.ObjectSpacePosition;
                return description;
            }

            struct SurfaceDescription
            {
                float3 Color;
                float Alpha;
                float AlphaClipThreshold;
            };

            SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                float4 _Property_118C9AB1_Out = Color_F7B61C2A;
                float4 _UV_371E79A1_Out = IN.uv0;
                float _Split_E077389D_R = _UV_371E79A1_Out[0];
                float _Split_E077389D_G = _UV_371E79A1_Out[1];
                float _Split_E077389D_B = _UV_371E79A1_Out[2];
                float _Split_E077389D_A = _UV_371E79A1_Out[3];
                float _Remap_1E3428E6_Out;
                Unity_Remap_float(_Split_E077389D_B, float2 (0,1), float2 (-0.1,0.3), _Remap_1E3428E6_Out);
                float2 _Vector2_31E5E85A_Out = float2(0,_Remap_1E3428E6_Out);
                float2 _TilingAndOffset_21E06EE5_Out;
                Unity_TilingAndOffset_float(IN.uv0.xy, float2 (1,1), _Vector2_31E5E85A_Out, _TilingAndOffset_21E06EE5_Out);
                float4 _SampleTexture2D_FE626E1B_RGBA = SAMPLE_TEXTURE2D(Texture2D_E869B265, samplerTexture2D_E869B265, _TilingAndOffset_21E06EE5_Out);
                float _SampleTexture2D_FE626E1B_R = _SampleTexture2D_FE626E1B_RGBA.r;
                float _SampleTexture2D_FE626E1B_G = _SampleTexture2D_FE626E1B_RGBA.g;
                float _SampleTexture2D_FE626E1B_B = _SampleTexture2D_FE626E1B_RGBA.b;
                float _SampleTexture2D_FE626E1B_A = _SampleTexture2D_FE626E1B_RGBA.a;
                float4 _Multiply_6CB08D6C_Out;
                Unity_Multiply_float(_Property_118C9AB1_Out, _SampleTexture2D_FE626E1B_RGBA, _Multiply_6CB08D6C_Out);

                float4 _Multiply_1DAD26C8_Out;
                Unity_Multiply_float(_Multiply_6CB08D6C_Out, IN.VertexColor, _Multiply_1DAD26C8_Out);

                float _Multiply_5808EC11_Out;
                Unity_Multiply_float(_Split_E077389D_B, 1.2, _Multiply_5808EC11_Out);

                float _Remap_6ED46067_Out;
                Unity_Remap_float(_Multiply_5808EC11_Out, float2 (0,1), float2 (1.2,-0.3), _Remap_6ED46067_Out);
                float2 _Vector2_B944398C_Out = float2(0.5,_Remap_6ED46067_Out);
                float4 _UV_130DA522_Out = IN.uv0;
                float _Distance_461F8E03_Out;
                Unity_Distance_float2(_Vector2_B944398C_Out, (_UV_130DA522_Out.xy), _Distance_461F8E03_Out);
                float _Remap_AD01856A_Out;
                Unity_Remap_float(_Distance_461F8E03_Out, float2 (0,1), float2 (3.5,-3.96), _Remap_AD01856A_Out);
                float _Clamp_31D390E2_Out;
                Unity_Clamp_float(_Remap_AD01856A_Out, 0, 1, _Clamp_31D390E2_Out);
                float _Multiply_1194F055_Out;
                Unity_Multiply_float(_SampleTexture2D_FE626E1B_A, _Clamp_31D390E2_Out, _Multiply_1194F055_Out);

                float _Split_F80A1C40_R = IN.VertexColor[0];
                float _Split_F80A1C40_G = IN.VertexColor[1];
                float _Split_F80A1C40_B = IN.VertexColor[2];
                float _Split_F80A1C40_A = IN.VertexColor[3];
                float _Multiply_E3F5C6A0_Out;
                Unity_Multiply_float(_Multiply_1194F055_Out, _Split_F80A1C40_A, _Multiply_E3F5C6A0_Out);

                surface.Color = (_Multiply_1DAD26C8_Out.xyz);
                surface.Alpha = _Multiply_E3F5C6A0_Out;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 color : COLOR;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };


            struct GraphVertexOutput
            {
                float4 position : POSITION;

                // Interpolators defined by graph
                float3 WorldSpacePosition : TEXCOORD3;
                float3 WorldSpaceNormal : TEXCOORD4;
                float3 WorldSpaceTangent : TEXCOORD5;
                float3 WorldSpaceBiTangent : TEXCOORD6;
                float3 WorldSpaceViewDirection : TEXCOORD7;
                float4 VertexColor : COLOR;
                half4 uv0 : TEXCOORD8;
                half4 uv1 : TEXCOORD9;

                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            GraphVertexOutput vert (GraphVertexInput v)
            {
                GraphVertexOutput o = (GraphVertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                // Vertex transformations performed by graph
                float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex).xyz;
                float3 WorldSpaceNormal = normalize(mul(v.normal,(float3x3)UNITY_MATRIX_I_M));
                float3 WorldSpaceTangent = normalize(mul((float3x3)UNITY_MATRIX_M,v.tangent.xyz));
                float3 WorldSpaceBiTangent = cross(WorldSpaceNormal, WorldSpaceTangent.xyz) * v.tangent.w;
                float3 WorldSpaceViewDirection = _WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz;
                float4 VertexColor = v.color;
                float4 uv0 = v.texcoord0;
                float4 uv1 = v.texcoord1;
                float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0)).xyz;

                VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

                // Vertex description inputs defined by graph
                vdi.ObjectSpacePosition = ObjectSpacePosition;

                VertexDescription vd = PopulateVertexData(vdi);
                v.vertex.xyz = vd.Position;

                o.position = TransformObjectToHClip(v.vertex.xyz);
                // Vertex shader outputs defined by graph
                o.WorldSpacePosition = WorldSpacePosition;
                o.WorldSpaceNormal = WorldSpaceNormal;
                o.WorldSpaceTangent = WorldSpaceTangent;
                o.WorldSpaceBiTangent = WorldSpaceBiTangent;
                o.WorldSpaceViewDirection = WorldSpaceViewDirection;
                o.VertexColor = VertexColor;
                o.uv0 = uv0;
                o.uv1 = uv1;

                return o;
            }

            half4 frag (GraphVertexOutput IN ) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);

                // Pixel transformations performed by graph
                float3 WorldSpacePosition = IN.WorldSpacePosition;
                float3 WorldSpaceNormal = IN.WorldSpaceNormal;
                float3 WorldSpaceTangent = IN.WorldSpaceTangent;
                float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
                float3 WorldSpaceViewDirection = IN.WorldSpaceViewDirection;
                float4 VertexColor = IN.VertexColor;
                float4 uv0 = IN.uv0;
                float4 uv1 = IN.uv1;

                
                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;
                // Surface description inputs defined by graph
                surfaceInput.VertexColor = VertexColor;
                surfaceInput.uv0 = uv0;


                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
                float3 Color = float3(0.5, 0.5, 0.5);
                float Alpha = 1;
                float AlphaClipThreshold = 0;
                // Surface description remap performed by graph
                Color = surf.Color;
                Alpha = surf.Alpha;
                AlphaClipThreshold = surf.AlphaClipThreshold;

                
         #if _AlphaClip
                clip(Alpha - AlphaClipThreshold);
        #endif
        #ifdef _ALPHAPREMULTIPLY_ON
                
                Color *= Alpha;
        #endif
                return half4(Color, Alpha);
            }
            ENDHLSL
        }
        Pass
        {
            Name "ShadowCaster"
            Tags{"LightMode" = "ShadowCaster"}

            ZWrite On ZTest LEqual

            // Material options generated by graph
            Cull Off

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex ShadowPassVertex
            #pragma fragment ShadowPassFragment

            // Defines generated by graph

            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float4 Color_F7B61C2A;
            float Vector1_46C14E4F;
            float Vector1_53DB4A3F;
            CBUFFER_END

            TEXTURE2D(Texture2D_E869B265); SAMPLER(samplerTexture2D_E869B265); float4 Texture2D_E869B265_TexelSize;

            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
                float4 VertexColor;
                half4 uv0;
            };


            void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
            {
                Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }

            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }

            void Unity_Multiply_float (float A, float B, out float Out)
            {
                Out = A * B;
            }

            void Unity_Distance_float2(float2 A, float2 B, out float Out)
            {
                Out = distance(A, B);
            }

            void Unity_Clamp_float(float In, float Min, float Max, out float Out)
            {
                Out = clamp(In, Min, Max);
            }

            struct VertexDescription
            {
                float3 Position;
            };

            VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
            {
                VertexDescription description = (VertexDescription)0;
                description.Position = IN.ObjectSpacePosition;
                return description;
            }

            struct SurfaceDescription
            {
                float Alpha;
                float AlphaClipThreshold;
            };

            SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                float4 _UV_371E79A1_Out = IN.uv0;
                float _Split_E077389D_R = _UV_371E79A1_Out[0];
                float _Split_E077389D_G = _UV_371E79A1_Out[1];
                float _Split_E077389D_B = _UV_371E79A1_Out[2];
                float _Split_E077389D_A = _UV_371E79A1_Out[3];
                float _Remap_1E3428E6_Out;
                Unity_Remap_float(_Split_E077389D_B, float2 (0,1), float2 (-0.1,0.3), _Remap_1E3428E6_Out);
                float2 _Vector2_31E5E85A_Out = float2(0,_Remap_1E3428E6_Out);
                float2 _TilingAndOffset_21E06EE5_Out;
                Unity_TilingAndOffset_float(IN.uv0.xy, float2 (1,1), _Vector2_31E5E85A_Out, _TilingAndOffset_21E06EE5_Out);
                float4 _SampleTexture2D_FE626E1B_RGBA = SAMPLE_TEXTURE2D(Texture2D_E869B265, samplerTexture2D_E869B265, _TilingAndOffset_21E06EE5_Out);
                float _SampleTexture2D_FE626E1B_R = _SampleTexture2D_FE626E1B_RGBA.r;
                float _SampleTexture2D_FE626E1B_G = _SampleTexture2D_FE626E1B_RGBA.g;
                float _SampleTexture2D_FE626E1B_B = _SampleTexture2D_FE626E1B_RGBA.b;
                float _SampleTexture2D_FE626E1B_A = _SampleTexture2D_FE626E1B_RGBA.a;
                float _Multiply_5808EC11_Out;
                Unity_Multiply_float(_Split_E077389D_B, 1.2, _Multiply_5808EC11_Out);

                float _Remap_6ED46067_Out;
                Unity_Remap_float(_Multiply_5808EC11_Out, float2 (0,1), float2 (1.2,-0.3), _Remap_6ED46067_Out);
                float2 _Vector2_B944398C_Out = float2(0.5,_Remap_6ED46067_Out);
                float4 _UV_130DA522_Out = IN.uv0;
                float _Distance_461F8E03_Out;
                Unity_Distance_float2(_Vector2_B944398C_Out, (_UV_130DA522_Out.xy), _Distance_461F8E03_Out);
                float _Remap_AD01856A_Out;
                Unity_Remap_float(_Distance_461F8E03_Out, float2 (0,1), float2 (3.5,-3.96), _Remap_AD01856A_Out);
                float _Clamp_31D390E2_Out;
                Unity_Clamp_float(_Remap_AD01856A_Out, 0, 1, _Clamp_31D390E2_Out);
                float _Multiply_1194F055_Out;
                Unity_Multiply_float(_SampleTexture2D_FE626E1B_A, _Clamp_31D390E2_Out, _Multiply_1194F055_Out);

                float _Split_F80A1C40_R = IN.VertexColor[0];
                float _Split_F80A1C40_G = IN.VertexColor[1];
                float _Split_F80A1C40_B = IN.VertexColor[2];
                float _Split_F80A1C40_A = IN.VertexColor[3];
                float _Multiply_E3F5C6A0_Out;
                Unity_Multiply_float(_Multiply_1194F055_Out, _Split_F80A1C40_A, _Multiply_E3F5C6A0_Out);

                surface.Alpha = _Multiply_E3F5C6A0_Out;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 color : COLOR;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };


            struct VertexOutput
            {
                float2 uv           : TEXCOORD0;
                float4 clipPos      : SV_POSITION;
                // Interpolators defined by graph
                float3 WorldSpacePosition : TEXCOORD3;
                float3 WorldSpaceNormal : TEXCOORD4;
                float3 WorldSpaceTangent : TEXCOORD5;
                float3 WorldSpaceBiTangent : TEXCOORD6;
                float3 WorldSpaceViewDirection : TEXCOORD7;
                float4 VertexColor : COLOR;
                half4 uv0 : TEXCOORD8;
                half4 uv1 : TEXCOORD9;

                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            // x: global clip space bias, y: normal world space bias
            float4 _ShadowBias;
            float3 _LightDirection;

            VertexOutput ShadowPassVertex(GraphVertexInput v)
            {
                VertexOutput o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                // Vertex transformations performed by graph
                float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex).xyz;
                float3 WorldSpaceNormal = normalize(mul(v.normal,(float3x3)UNITY_MATRIX_I_M));
                float3 WorldSpaceTangent = normalize(mul((float3x3)UNITY_MATRIX_M,v.tangent.xyz));
                float3 WorldSpaceBiTangent = cross(WorldSpaceNormal, WorldSpaceTangent.xyz) * v.tangent.w;
                float3 WorldSpaceViewDirection = _WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz;
                float4 VertexColor = v.color;
                float4 uv0 = v.texcoord0;
                float4 uv1 = v.texcoord1;
                float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0)).xyz;

                VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

                // Vertex description inputs defined by graph
                vdi.ObjectSpacePosition = ObjectSpacePosition;

                VertexDescription vd = PopulateVertexData(vdi);
                v.vertex.xyz = vd.Position;

                // Vertex shader outputs defined by graph
                o.WorldSpacePosition = WorldSpacePosition;
                o.WorldSpaceNormal = WorldSpaceNormal;
                o.WorldSpaceTangent = WorldSpaceTangent;
                o.WorldSpaceBiTangent = WorldSpaceBiTangent;
                o.WorldSpaceViewDirection = WorldSpaceViewDirection;
                o.VertexColor = VertexColor;
                o.uv0 = uv0;
                o.uv1 = uv1;

                
                float3 positionWS = TransformObjectToWorld(v.vertex.xyz);
                float3 normalWS = TransformObjectToWorldNormal(v.normal);

                float invNdotL = 1.0 - saturate(dot(_LightDirection, normalWS));
                float scale = invNdotL * _ShadowBias.y;

                // normal bias is negative since we want to apply an inset normal offset
                positionWS = normalWS * scale.xxx + positionWS;
                float4 clipPos = TransformWorldToHClip(positionWS);

                // _ShadowBias.x sign depens on if platform has reversed z buffer
                clipPos.z += _ShadowBias.x;

            #if UNITY_REVERSED_Z
                clipPos.z = min(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
            #else
                clipPos.z = max(clipPos.z, clipPos.w * UNITY_NEAR_CLIP_VALUE);
            #endif
                o.clipPos = clipPos;

                return o;
            }

            half4 ShadowPassFragment(VertexOutput IN ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);

                // Pixel transformations performed by graph
                float3 WorldSpacePosition = IN.WorldSpacePosition;
                float3 WorldSpaceNormal = IN.WorldSpaceNormal;
                float3 WorldSpaceTangent = IN.WorldSpaceTangent;
                float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
                float3 WorldSpaceViewDirection = IN.WorldSpaceViewDirection;
                float4 VertexColor = IN.VertexColor;
                float4 uv0 = IN.uv0;
                float4 uv1 = IN.uv1;

                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;

        		// Surface description inputs defined by graph
                surfaceInput.VertexColor = VertexColor;
                surfaceInput.uv0 = uv0;

                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);

        		float Alpha = 1;
        		float AlphaClipThreshold = 0;

        		// Surface description remap performed by graph
                Alpha = surf.Alpha;
                AlphaClipThreshold = surf.AlphaClipThreshold;

         #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
        #endif
                return 0;
            }

            ENDHLSL
        }

        Pass
        {
            Name "DepthOnly"
            Tags{"LightMode" = "DepthOnly"}

            ZWrite On
            ColorMask 0

            // Material options generated by graph
            Cull Off

            HLSLPROGRAM
            // Required to compile gles 2.0 with standard srp library
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 2.0

            //--------------------------------------
            // GPU Instancing
            #pragma multi_compile_instancing

            #pragma vertex vert
            #pragma fragment frag

            // Defines generated by graph

            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.lightweight/ShaderLibrary/ShaderGraphFunctions.hlsl"
            #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"

            CBUFFER_START(UnityPerMaterial)
            float4 Color_F7B61C2A;
            float Vector1_46C14E4F;
            float Vector1_53DB4A3F;
            CBUFFER_END

            TEXTURE2D(Texture2D_E869B265); SAMPLER(samplerTexture2D_E869B265); float4 Texture2D_E869B265_TexelSize;

            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
                float4 VertexColor;
                half4 uv0;
            };


            void Unity_Remap_float(float In, float2 InMinMax, float2 OutMinMax, out float Out)
            {
                Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
            }

            void Unity_TilingAndOffset_float(float2 UV, float2 Tiling, float2 Offset, out float2 Out)
            {
                Out = UV * Tiling + Offset;
            }

            void Unity_Multiply_float (float A, float B, out float Out)
            {
                Out = A * B;
            }

            void Unity_Distance_float2(float2 A, float2 B, out float Out)
            {
                Out = distance(A, B);
            }

            void Unity_Clamp_float(float In, float Min, float Max, out float Out)
            {
                Out = clamp(In, Min, Max);
            }

            struct VertexDescription
            {
                float3 Position;
            };

            VertexDescription PopulateVertexData(VertexDescriptionInputs IN)
            {
                VertexDescription description = (VertexDescription)0;
                description.Position = IN.ObjectSpacePosition;
                return description;
            }

            struct SurfaceDescription
            {
                float Alpha;
                float AlphaClipThreshold;
            };

            SurfaceDescription PopulateSurfaceData(SurfaceDescriptionInputs IN)
            {
                SurfaceDescription surface = (SurfaceDescription)0;
                float4 _UV_371E79A1_Out = IN.uv0;
                float _Split_E077389D_R = _UV_371E79A1_Out[0];
                float _Split_E077389D_G = _UV_371E79A1_Out[1];
                float _Split_E077389D_B = _UV_371E79A1_Out[2];
                float _Split_E077389D_A = _UV_371E79A1_Out[3];
                float _Remap_1E3428E6_Out;
                Unity_Remap_float(_Split_E077389D_B, float2 (0,1), float2 (-0.1,0.3), _Remap_1E3428E6_Out);
                float2 _Vector2_31E5E85A_Out = float2(0,_Remap_1E3428E6_Out);
                float2 _TilingAndOffset_21E06EE5_Out;
                Unity_TilingAndOffset_float(IN.uv0.xy, float2 (1,1), _Vector2_31E5E85A_Out, _TilingAndOffset_21E06EE5_Out);
                float4 _SampleTexture2D_FE626E1B_RGBA = SAMPLE_TEXTURE2D(Texture2D_E869B265, samplerTexture2D_E869B265, _TilingAndOffset_21E06EE5_Out);
                float _SampleTexture2D_FE626E1B_R = _SampleTexture2D_FE626E1B_RGBA.r;
                float _SampleTexture2D_FE626E1B_G = _SampleTexture2D_FE626E1B_RGBA.g;
                float _SampleTexture2D_FE626E1B_B = _SampleTexture2D_FE626E1B_RGBA.b;
                float _SampleTexture2D_FE626E1B_A = _SampleTexture2D_FE626E1B_RGBA.a;
                float _Multiply_5808EC11_Out;
                Unity_Multiply_float(_Split_E077389D_B, 1.2, _Multiply_5808EC11_Out);

                float _Remap_6ED46067_Out;
                Unity_Remap_float(_Multiply_5808EC11_Out, float2 (0,1), float2 (1.2,-0.3), _Remap_6ED46067_Out);
                float2 _Vector2_B944398C_Out = float2(0.5,_Remap_6ED46067_Out);
                float4 _UV_130DA522_Out = IN.uv0;
                float _Distance_461F8E03_Out;
                Unity_Distance_float2(_Vector2_B944398C_Out, (_UV_130DA522_Out.xy), _Distance_461F8E03_Out);
                float _Remap_AD01856A_Out;
                Unity_Remap_float(_Distance_461F8E03_Out, float2 (0,1), float2 (3.5,-3.96), _Remap_AD01856A_Out);
                float _Clamp_31D390E2_Out;
                Unity_Clamp_float(_Remap_AD01856A_Out, 0, 1, _Clamp_31D390E2_Out);
                float _Multiply_1194F055_Out;
                Unity_Multiply_float(_SampleTexture2D_FE626E1B_A, _Clamp_31D390E2_Out, _Multiply_1194F055_Out);

                float _Split_F80A1C40_R = IN.VertexColor[0];
                float _Split_F80A1C40_G = IN.VertexColor[1];
                float _Split_F80A1C40_B = IN.VertexColor[2];
                float _Split_F80A1C40_A = IN.VertexColor[3];
                float _Multiply_E3F5C6A0_Out;
                Unity_Multiply_float(_Multiply_1194F055_Out, _Split_F80A1C40_A, _Multiply_E3F5C6A0_Out);

                surface.Alpha = _Multiply_E3F5C6A0_Out;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 color : COLOR;
                float4 texcoord0 : TEXCOORD0;
                float4 texcoord1 : TEXCOORD1;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };


            struct VertexOutput
            {
                float2 uv           : TEXCOORD0;
                float4 clipPos      : SV_POSITION;
                // Interpolators defined by graph
                float3 WorldSpacePosition : TEXCOORD3;
                float3 WorldSpaceNormal : TEXCOORD4;
                float3 WorldSpaceTangent : TEXCOORD5;
                float3 WorldSpaceBiTangent : TEXCOORD6;
                float3 WorldSpaceViewDirection : TEXCOORD7;
                float4 VertexColor : COLOR;
                half4 uv0 : TEXCOORD8;
                half4 uv1 : TEXCOORD9;

                UNITY_VERTEX_INPUT_INSTANCE_ID
                UNITY_VERTEX_OUTPUT_STEREO
            };

            VertexOutput vert(GraphVertexInput v)
            {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_TRANSFER_INSTANCE_ID(v, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                // Vertex transformations performed by graph
                float3 WorldSpacePosition = mul(UNITY_MATRIX_M,v.vertex).xyz;
                float3 WorldSpaceNormal = normalize(mul(v.normal,(float3x3)UNITY_MATRIX_I_M));
                float3 WorldSpaceTangent = normalize(mul((float3x3)UNITY_MATRIX_M,v.tangent.xyz));
                float3 WorldSpaceBiTangent = cross(WorldSpaceNormal, WorldSpaceTangent.xyz) * v.tangent.w;
                float3 WorldSpaceViewDirection = _WorldSpaceCameraPos.xyz - mul(GetObjectToWorldMatrix(), float4(v.vertex.xyz, 1.0)).xyz;
                float4 VertexColor = v.color;
                float4 uv0 = v.texcoord0;
                float4 uv1 = v.texcoord1;
                float3 ObjectSpacePosition = mul(UNITY_MATRIX_I_M,float4(WorldSpacePosition,1.0)).xyz;

                VertexDescriptionInputs vdi = (VertexDescriptionInputs)0;

                // Vertex description inputs defined by graph
                vdi.ObjectSpacePosition = ObjectSpacePosition;

                VertexDescription vd = PopulateVertexData(vdi);
                v.vertex.xyz = vd.Position;

                // Vertex shader outputs defined by graph
                o.WorldSpacePosition = WorldSpacePosition;
                o.WorldSpaceNormal = WorldSpaceNormal;
                o.WorldSpaceTangent = WorldSpaceTangent;
                o.WorldSpaceBiTangent = WorldSpaceBiTangent;
                o.WorldSpaceViewDirection = WorldSpaceViewDirection;
                o.VertexColor = VertexColor;
                o.uv0 = uv0;
                o.uv1 = uv1;

                o.clipPos = TransformObjectToHClip(v.vertex.xyz);
                return o;
            }

            half4 frag(VertexOutput IN ) : SV_TARGET
            {
                UNITY_SETUP_INSTANCE_ID(IN);

                // Pixel transformations performed by graph
                float3 WorldSpacePosition = IN.WorldSpacePosition;
                float3 WorldSpaceNormal = IN.WorldSpaceNormal;
                float3 WorldSpaceTangent = IN.WorldSpaceTangent;
                float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
                float3 WorldSpaceViewDirection = IN.WorldSpaceViewDirection;
                float4 VertexColor = IN.VertexColor;
                float4 uv0 = IN.uv0;
                float4 uv1 = IN.uv1;

                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;

        		// Surface description inputs defined by graph
                surfaceInput.VertexColor = VertexColor;
                surfaceInput.uv0 = uv0;

                SurfaceDescription surf = PopulateSurfaceData(surfaceInput);

        		float Alpha = 1;
        		float AlphaClipThreshold = 0;

        		// Surface description remap performed by graph
                Alpha = surf.Alpha;
                AlphaClipThreshold = surf.AlphaClipThreshold;

         #if _AlphaClip
        		clip(Alpha - AlphaClipThreshold);
        #endif
                return 0;
            }
            ENDHLSL
        }
    }
    FallBack "Hidden/InternalErrorShader"
}
