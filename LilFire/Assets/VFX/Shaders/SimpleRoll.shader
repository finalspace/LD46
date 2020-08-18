// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33615,y:32553,varname:node_1873,prsc:2|emission-1785-OUT,alpha-7549-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32228,y:33074,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:6337f74ea4d0447fcabf466fbeb336d8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32522,y:32869,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32228,y:33257,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32228,y:33406,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:603,x:32887,y:33247,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-9749-A,E-5502-OUT;n:type:ShaderForge.SFN_Tex2d,id:9749,x:31092,y:32197,ptovrint:False,ptlb:WaveTexture,ptin:_WaveTexture,varname:node_9749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ce77bc6ade2d94cd0b315e73bdb3f5e3,ntxv:0,isnm:False|UVIN-307-OUT;n:type:ShaderForge.SFN_TexCoord,id:9919,x:29900,y:32169,varname:node_9919,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:388,x:32017,y:32430,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.530007,max:10;n:type:ShaderForge.SFN_Time,id:2983,x:29622,y:32425,varname:node_2983,prsc:2;n:type:ShaderForge.SFN_Slider,id:3719,x:29465,y:32602,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_3719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:-0.1010247,max:1;n:type:ShaderForge.SFN_Multiply,id:939,x:29912,y:32378,varname:node_939,prsc:2|A-2983-T,B-3719-OUT;n:type:ShaderForge.SFN_Add,id:1649,x:30347,y:32268,varname:node_1649,prsc:2|A-9919-V,B-939-OUT,C-9468-OUT;n:type:ShaderForge.SFN_Append,id:307,x:30628,y:32198,varname:node_307,prsc:2|A-9919-U,B-1649-OUT;n:type:ShaderForge.SFN_Multiply,id:1785,x:33169,y:32326,varname:node_1785,prsc:2|A-9673-OUT,B-1086-OUT;n:type:ShaderForge.SFN_Multiply,id:9673,x:32155,y:32274,varname:node_9673,prsc:2|A-9749-RGB,B-388-OUT;n:type:ShaderForge.SFN_Slider,id:870,x:33029,y:33439,ptovrint:False,ptlb:OverallOpcity,ptin:_OverallOpcity,varname:node_870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:20;n:type:ShaderForge.SFN_Multiply,id:7549,x:33253,y:33222,varname:node_7549,prsc:2|A-603-OUT,B-870-OUT;n:type:ShaderForge.SFN_Sin,id:8874,x:31232,y:33444,varname:node_8874,prsc:2|IN-9365-OUT;n:type:ShaderForge.SFN_RemapRange,id:2106,x:31426,y:33444,varname:node_2106,prsc:2,frmn:-1,frmx:1,tomn:-0.1,tomx:0.1|IN-8874-OUT;n:type:ShaderForge.SFN_Pi,id:6148,x:30526,y:33452,varname:node_6148,prsc:2;n:type:ShaderForge.SFN_Vector1,id:6036,x:30493,y:33550,varname:node_6036,prsc:2,v1:2;n:type:ShaderForge.SFN_Divide,id:6366,x:30653,y:33452,varname:node_6366,prsc:2|A-6148-OUT,B-6036-OUT;n:type:ShaderForge.SFN_Multiply,id:9365,x:30947,y:33438,varname:node_9365,prsc:2|A-8347-OUT,B-6366-OUT;n:type:ShaderForge.SFN_Time,id:5611,x:29987,y:32948,varname:node_5611,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5217,x:30369,y:33040,varname:node_5217,prsc:2|A-5611-T,B-1446-OUT;n:type:ShaderForge.SFN_Clamp01,id:5502,x:31621,y:33444,varname:node_5502,prsc:2|IN-2106-OUT;n:type:ShaderForge.SFN_Multiply,id:1446,x:29897,y:33093,varname:node_1446,prsc:2|A-3719-OUT,B-1772-OUT;n:type:ShaderForge.SFN_Vector1,id:1772,x:29596,y:33197,varname:node_1772,prsc:2,v1:4;n:type:ShaderForge.SFN_Slider,id:4311,x:30431,y:33313,ptovrint:False,ptlb:FadeOffset,ptin:_FadeOffset,varname:node_4311,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.870313,max:5;n:type:ShaderForge.SFN_Add,id:8347,x:30655,y:33148,varname:node_8347,prsc:2|A-5217-OUT,B-4311-OUT;n:type:ShaderForge.SFN_Slider,id:9468,x:30181,y:32725,ptovrint:False,ptlb:RollOffset,ptin:_RollOffset,varname:node_9468,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.2,max:1;proporder:4805-5983-9749-388-3719-870-4311-9468;pass:END;sub:END;*/

Shader "DDT/SimpleRoll" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _WaveTexture ("WaveTexture", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 10)) = 8.530007
        _WaveSpeed ("WaveSpeed", Range(-2, 1)) = -0.1010247
        _OverallOpcity ("OverallOpcity", Range(0, 20)) = 1
        _FadeOffset ("FadeOffset", Range(0, 5)) = 1.870313
        _RollOffset ("RollOffset", Range(-1, 1)) = 0.2
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 2.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform float _Brightness;
            uniform float _WaveSpeed;
            uniform float _OverallOpcity;
            uniform float _FadeOffset;
            uniform float _RollOffset;
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
                float4 node_2983 = _Time + _TimeEditor;
                float2 node_307 = float2(i.uv0.r,(i.uv0.g+(node_2983.g*_WaveSpeed)+_RollOffset));
                float4 _WaveTexture_var = tex2D(_WaveTexture,TRANSFORM_TEX(node_307, _WaveTexture));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 emissive = ((_WaveTexture_var.rgb*_Brightness)*(_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb));
                float3 finalColor = emissive;
                float4 node_5611 = _Time + _TimeEditor;
                return fixed4(finalColor,((_MainTex_var.a*_Color.a*i.vertexColor.a*_WaveTexture_var.a*saturate((sin((((node_5611.g*(_WaveSpeed*4.0))+_FadeOffset)*(3.141592654/2.0)))*0.1+0.0)))*_OverallOpcity));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
