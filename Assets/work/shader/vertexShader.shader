Shader "Custom/vertexShader"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (0.65, 0.63, 1.0)
        _MiddleColor("Middle Color", Color) = (1.0, 0.8, 0.1)
        _TipColor("Tip Color", Color) = (1.0, 0.3, 0.05)
        _DistortionSize("Distortion Size", Float) = 0.23
        _FlickerSpeed("Ficker Speed", Float) = 2.9
        _EmissionColor("Emission Color", Color) = (1,0.5,0.1,1)
        _Alpha("Alpha", Float) = 0.2
    }
    SubShader
    {
        Tags {
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
            "RenderPipeline" = "UniversalPipeline"
            "LightMode" = "UniversalForward"
        }

        //BlendOp RevSub
        //Blend SrcAlpha One
        //Blend OneMinusDstColor One
        //Blend DstColor Zero
        //Blend DstColor SrcColor
        //Blend One OneMinusSrcAlpha
        //Blend SrcAlpha OneMinusSrcAlpha

        BlendOp Sub
        Blend One One

        ZWrite Off
        Cull Off
        
        Pass
        {
            Cull Off
            HLSLPROGRAM

            #pragma vertex vertex
            #pragma fragment fragment

            #pragma shader_feature _CLUSTER_LIGHT_LOOP
            #pragma shader_feature _CASTING_PUNCTUAL_LIGHT_SHADOW
            #pragma shader_feature _MAIN_LIGHT_SHADOWS _MAIN_LIGHT_SHADOWS_CASCADE _MAIN_LIGHT_SHADOWS_SCREEN
            #pragma shader_feature _ADDITIONAL_LIGHT_SHADOWS
            #pragma shader_feature _SHADOWS_SOFT

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareOpaqueTexture.hlsl"

            float4 _BaseColor;
            float4 _MiddleColor;
            float4 _TipColor;
            float _DistortionSize;
            float _FlickerSpeed;
            float4 _EmissionColor;
            float _Alpha;
            
            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
                float3 positionOS : TEXCOORD3;
            };

            float hash21(float2 v){
                return frac(23425.32 * sin(v.x*542.02 + v.y * 456.834));
            }

            float noise21(float2 uv){
            
                float2 scaleUV = floor(uv);
                float2 unitUV = frac(uv);
            
                float2 noiseUV = scaleUV;
            
                float value1 = hash21(noiseUV);
                float value2 = hash21(noiseUV + float2(1.,0.));
                float value3 = hash21(noiseUV + float2(0.,1.));
                float value4 = hash21(noiseUV + float2(1.,1.));
            
                unitUV = smoothstep(float2(0,0),float2(1,1),unitUV);
            
                float bresult = lerp(value1,value2,unitUV.x);
                float tresult = lerp(value3,value4,unitUV.x);
            
                return lerp(bresult,tresult,unitUV.y);
            }

            float fBM(float2 uv){
                float result = 0.;
                for(int i = 0; i <  8; i++){
                    result = result + (noise21(uv * pow(2.,float(i))) / pow(2.,float(i)+1.));
                }
            
                return result;
            }


            float3 ApplyFlameDistortion(float3 positionOS, float t, float2 uv)
            {
                float vertexDistance = abs(positionOS.y);

                float n = noise21(uv * 4 + float2(0, t * _FlickerSpeed)); //scrolling noise
                float xOffset = (n - 0.5) * vertexDistance * _DistortionSize; //horizontal swaying
                float yOffset = sin(t * _FlickerSpeed + n*6) * vertexDistance * 0.25; //vertical flicker

                return positionOS + float3(xOffset, yOffset, 0);
            }
            
            Varyings vertex(Attributes IN)
            {
                Varyings OUT = (Varyings)0;
                IN.positionOS.xyz = ApplyFlameDistortion(IN.positionOS.xyz, _Time.y, IN.uv);
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.worldPos = TransformObjectToWorld(IN.positionOS.xyz);
                OUT.worldNormal = TransformObjectToWorldNormal(IN.normalOS);
                OUT.positionOS = IN.positionOS;
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 fragment(Varyings IN) : SV_Target
            {

                // float h = saturate(IN.positionOS.y);
    
                // float3 flameColor = lerp(lerp(_BaseColor.rgb, _MiddleColor.rgb, h * 0.9), _TipColor.rgb, h);

                // float3 emissionColor = _EmissionColor.rgb * h * 60.0;
                // float3 finalColor = flameColor + emissionColor;


                // return half4(finalColor, _Alpha);

                // float h = saturate(IN.positionOS.y);

                // float transition1 = smoothstep(0.0, 0.5, h);
                // float transition2 = smoothstep(0.3, 1.0, h);

                // float3 col = lerp(_BaseColor.rgb, _MiddleColor.rgb, transition1);
                // col = lerp(col, _TipColor.rgb, transition2);

                // float3 emissionColor = _EmissionColor.rgb * pow(h, 5.0) * 40.0;
                // float3 finalColor = col + emissionColor;

                // return half4(finalColor, _Alpha);

                

                // float h = saturate(IN.positionOS.y);

                // float transition1 = smoothstep(0.0, 0.5, h);
                // float transition2 = smoothstep(0.3, 1.0, h);
                // float3 col = lerp(_BaseColor.rgb, _MiddleColor.rgb, transition1);
                // col = lerp(col, _TipColor.rgb, transition2);

                // float3 emissionColor = _EmissionColor.rgb * pow(h, 5.0) * 40.0;
                // float3 finalColor = col + emissionColor;

                // float3 result = finalColor * -0.09; 

                // return half4(result, 0.0);

                float h = saturate(IN.positionOS.y);

                float transition1 = smoothstep(0.0, 0.5, h);
                float transition2 = smoothstep(0.3, 1.0, h);
                float3 col = lerp(_BaseColor.rgb, _MiddleColor.rgb, transition1);
                col = lerp(col, _TipColor.rgb, transition2);

                float3 emissionColor = _EmissionColor.rgb * pow(h, 2.0) * 60.0;
                float3 finalColor = col + emissionColor;

                float finalAlpha = _Alpha; 

                return half4(finalColor * finalAlpha, 1.0);
            }
            ENDHLSL
        }
    }
}