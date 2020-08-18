// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33507,y:32379,varname:node_1873,prsc:2|emission-6006-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32008,y:32633,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:abddb235748294582a58ad6ead854003,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB,D-2593-OUT;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-5469-OUT,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_TexCoord,id:2451,x:30999,y:32366,varname:node_2451,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3665,x:31175,y:32366,varname:node_3665,prsc:2,spu:-0.01,spv:0.01|UVIN-2451-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7713,x:31377,y:32366,varname:node_7713,prsc:2|A-3665-UVOUT,B-1515-OUT;n:type:ShaderForge.SFN_Vector1,id:1515,x:31175,y:32524,varname:node_1515,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:4250,x:31558,y:32366,ptovrint:False,ptlb:NoiseTex,ptin:_NoiseTex,varname:node_4250,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:99496d4d2b28c424f86cf029cc40a6d1,ntxv:0,isnm:False|UVIN-7713-OUT;n:type:ShaderForge.SFN_Slider,id:2593,x:32394,y:33263,ptovrint:False,ptlb:OverallBrightness,ptin:_OverallBrightness,varname:node_2593,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.709346,max:5;n:type:ShaderForge.SFN_Multiply,id:6006,x:32572,y:32336,varname:node_6006,prsc:2|A-7536-OUT,B-4805-RGB;n:type:ShaderForge.SFN_Add,id:9551,x:32779,y:32431,varname:node_9551,prsc:2|A-7536-OUT,B-4805-RGB;n:type:ShaderForge.SFN_Slider,id:6239,x:31377,y:32593,ptovrint:False,ptlb:NoisePower,ptin:_NoisePower,varname:node_6239,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6474919,max:5;n:type:ShaderForge.SFN_Multiply,id:7536,x:32163,y:32326,varname:node_7536,prsc:2|A-3268-OUT,B-6239-OUT;n:type:ShaderForge.SFN_TexCoord,id:77,x:30999,y:32169,varname:node_77,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8102,x:31175,y:32169,varname:node_8102,prsc:2,spu:0.01,spv:-0.01|UVIN-77-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1578,x:31377,y:32169,varname:node_1578,prsc:2|A-8102-UVOUT,B-5348-OUT;n:type:ShaderForge.SFN_Vector1,id:5348,x:31175,y:32313,varname:node_5348,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:9113,x:31558,y:32169,ptovrint:False,ptlb:node_9113,ptin:_node_9113,varname:node_9113,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0822be61d4823444e959e7b335727c7c,ntxv:0,isnm:False|UVIN-1578-OUT;n:type:ShaderForge.SFN_Add,id:5224,x:31810,y:32243,varname:node_5224,prsc:2|A-9113-R,B-4250-R;n:type:ShaderForge.SFN_RemapRange,id:3268,x:31978,y:32243,varname:node_3268,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5224-OUT;n:type:ShaderForge.SFN_Multiply,id:5469,x:32395,y:32788,varname:node_5469,prsc:2|A-7536-OUT,B-4805-A;proporder:4805-5983-2593-4250-6239-9113;pass:END;sub:END;*/

Shader "DDT/OceanWaveReflectionFixed" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _OverallBrightness ("OverallBrightness", Range(0, 5)) = 2.709346
        _NoiseTex ("NoiseTex", 2D) = "white" {}
        _Noise1SpeedX ("Noise1SpeedX", Range(-3, 3)) = -0.01
        _Noise1SpeedY ("Noise1SpeedY", Range(-3, 3)) = 0.01
        _NoisePower ("NoisePower", Range(0, 5)) = 0.6474919
        _node_9113 ("node_9113", 2D) = "white" {}
        _Noise2SpeedX ("Noise2SpeedX", Range(-3, 3)) = 0.01
        _Noise2SpeedY ("Noise2SpeedY", Range(-3, 3)) = -0.01
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
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
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _OverallBrightness;
            uniform float _Noise1SpeedX;
            uniform float _Noise1SpeedY;
            uniform float4 _Color;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _NoisePower;
            uniform float _Noise2SpeedX;
            uniform float _Noise2SpeedY;
            uniform sampler2D _node_9113; uniform float4 _node_9113_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_1246 = _Time + _TimeEditor;
                float2 node_1578 = ((i.uv0+node_1246.g*float2(_Noise2SpeedX,_Noise2SpeedY))*1.5);
                float4 _node_9113_var = tex2D(_node_9113,TRANSFORM_TEX(node_1578, _node_9113));
                float2 node_7713 = ((i.uv0+node_1246.g*float2(_Noise1SpeedX,_Noise1SpeedY))*1.5);
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_7713, _NoiseTex));
                float node_7536 = (((_node_9113_var.r+_NoiseTex_var.r)*2.0+-1.0)*_NoisePower);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = _MainTex_var.rgb*_Color.rgb*_OverallBrightness;
                float3 finalColor = emissive;
                float node_603 = ((node_7536*_MainTex_var.a)*_Color.a*i.vertexColor.a); // A
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
