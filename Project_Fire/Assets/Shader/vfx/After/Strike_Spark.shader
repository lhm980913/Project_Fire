﻿Shader "VFX/Strike_Spark"
{
    Properties
    {
        [HDR]Color_10B56FFB("Color", Color) = (1,1,1,0)

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
            float4 Color_10B56FFB;
            CBUFFER_END


            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
                float4 VertexColor;
            };


            void Unity_Multiply_float (float4 A, float4 B, out float4 Out)
            {
                Out = A * B;
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
                float4 _Property_B421B79F_Out = Color_10B56FFB;
                float4 _Multiply_5565FD93_Out;
                Unity_Multiply_float(_Property_B421B79F_Out, IN.VertexColor, _Multiply_5565FD93_Out);

                surface.Color = (_Multiply_5565FD93_Out.xyz);
                surface.Alpha = 1;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float4 color : COLOR;
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
                half4 uv1 : TEXCOORD8;

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
                float4 uv1 = IN.uv1;

                
                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;
                // Surface description inputs defined by graph
                surfaceInput.VertexColor = VertexColor;


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
            float4 Color_10B56FFB;
            CBUFFER_END


            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
            };


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
                surface.Alpha = 1;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
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
                half4 uv1 : TEXCOORD8;

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
                float4 uv1 = IN.uv1;

                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;

        		// Surface description inputs defined by graph

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
            float4 Color_10B56FFB;
            CBUFFER_END


            struct VertexDescriptionInputs
            {
                float3 ObjectSpacePosition;
            };

            struct SurfaceDescriptionInputs
            {
            };


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
                surface.Alpha = 1;
                surface.AlphaClipThreshold = 0;
                return surface;
            }

            struct GraphVertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
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
                half4 uv1 : TEXCOORD8;

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
                float4 uv1 = IN.uv1;

                SurfaceDescriptionInputs surfaceInput = (SurfaceDescriptionInputs)0;

        		// Surface description inputs defined by graph

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
