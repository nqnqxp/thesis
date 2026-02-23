Shader "PostEffect/Pixelation"
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

            float _WidthPixelation;
            float _HeightPixelation;
            float _ColorPrecision;
            
            float4 Frag (Varyings i) : SV_Target
            {
                float2 screenRes = _ScreenParams.xy;
                
                float2 pixelCount = float2(_WidthPixelation, _HeightPixelation);
                float2 uv = floor(i.texcoord * pixelCount) / pixelCount;
                uv += (1.0 / pixelCount) * 0.5; 

                float4 Color = SAMPLE_TEXTURE2D_X(_BlitTexture, sampler_LinearClamp, uv);

                float precision = max(1.0, _ColorPrecision);

                Color.rgb = floor(Color.rgb * precision + 0.5) / precision;

                return Color;
            }
            ENDHLSL
        }
    }
}