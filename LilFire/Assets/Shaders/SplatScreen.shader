Shader "P3/SplatScreen" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _SplatScreenTex ("_SplatScreenTex", 2D) = "white" {}
        _bwBlend ("Black & White blend", Range (0, 1)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            //Blend SrcAlpha OneMinusSrcAlpha
            //Cull Off
            //ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 2.0
            uniform sampler2D _MainTex;
            uniform sampler2D _SplatScreenTex;
            uniform float _bwBlend;
            
            /*
            float4 frag(v2f_img i, float facing : VFACE) : COLOR {
                float4 c1 = tex2D(_MainTex, i.uv);
                float4 c2 = tex2D(_SplatScreenTex, i.uv);
                float4 c = c2 * c2.a + c1 * (1 - c2.a);
                float lum = c.r*.3 + c.g*.59 + c.b*.11;
                float3 bw = float3( lum, lum, lum ); 
 
                float4 result = c;
                result.rgb = lerp(c.rgb, bw, _bwBlend);
                return result;
            }
            */

            float4 frag(v2f_img i, float facing : VFACE) : COLOR {
                float4 c1 = tex2D(_MainTex, i.uv);
                float4 c2 = tex2D(_SplatScreenTex, i.uv);
                float d = i.uv.x - .25 - i.uv.y*.5;
                float mask = step(0,d);
                float4 c = c2 * mask + c1 * (1 - mask);
                float lum = c.r*.3 + c.g*.59 + c.b*.11;
                float3 bw = float3( lum, lum, lum ); 
 
                float4 result = c;
                result.rgb = lerp(c.rgb, bw, _bwBlend);
                return result;
            }
            ENDCG
        }
    }
}
