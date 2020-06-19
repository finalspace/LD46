Shader "Hidden/Custom/Grayscale"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
        TEXTURE2D_SAMPLER2D(_SplatScreenTex, sampler_SplatScreenTex);
        float _Blend;

        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
            float luminance = dot(color.rgb, float3(0.2126729, 0.7151522, 0.0721750));

            float4 c1 = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
            float4 c2 = SAMPLE_TEXTURE2D(_SplatScreenTex, sampler_SplatScreenTex, i.texcoord);
            float d = i.texcoord.x - .25 - i.texcoord.y*.5;
            float mask = step(0,d);
            float4 c = c2 * mask + c1 * (1 - mask);

            color.rgb = lerp(c.rgb, luminance.xxx, _Blend.xxx);
            return color;
        }

    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM

                #pragma vertex VertDefault
                #pragma fragment Frag

            ENDHLSL
        }
    }
}