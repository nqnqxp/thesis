Shader "PostEffect/Dithering"
{
    Properties
    {
        [HideInInspector] _BlitTexture("Texture", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderPipeline" = "UniversalPipeline"}
        LOD 100
        ZWrite Off Cull Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex Vert
            #pragma fragment Frag
            
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.core/Runtime/Utilities/Blit.hlsl"

            uint _PatternIndex; 
            float _DitherThreshold;
            float _DitherStrength;
            float _DitherScale;

            float4x4 GetDitherPattern(uint index)
            {
                if(index == 0) return float4x4(0,1,0,1, 1,0,1,0, 0,1,0,1, 1,0,1,0);
                if(index == 1) return float4x4(0.23,0.2,0.6,0.2, 0.2,0.43,0.2,0.77, 0.88,0.2,0.87,0.2, 0.2,0.46,0.2,0);
                if(index == 2) return float4x4(-4,0,-3,1, 2,-2,3,-1, -3,1,-4,0, 3,-1,2,-2);
                if(index == 3) return float4x4(1,0,0,1, 0,1,1,0, 0,1,1,0, 1,0,0,1);
                return 1.0;
            }

            float PixelBrightness(float3 col)
            {
                return dot(col, float3(0.2126, 0.7152, 0.0722));
            }

            float4 Frag (Varyings i) : SV_Target
            {
 
                float4 Color = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, i.texcoord);
                
                float scale = max(0.001, _DitherScale);
                float2 pixelPos = i.texcoord * _ScreenParams.xy;

                uint2 ditherCoordinate = (uint2)(pixelPos / scale) % 4;
                
                float brightness = PixelBrightness(Color.rgb);
                float4x4 ditherPattern = GetDitherPattern(_PatternIndex);

                float threshold = ditherPattern[ditherCoordinate.x][ditherCoordinate.y];
                
                float ditherResult = (brightness * _DitherThreshold < threshold) ? 0.0 : 1.0;
                float3 finalRGB = lerp(Color.rgb, Color.rgb * ditherResult, _DitherStrength);
                
                return float4(finalRGB, Color.a);        
            }
            ENDHLSL
        }
    }
}