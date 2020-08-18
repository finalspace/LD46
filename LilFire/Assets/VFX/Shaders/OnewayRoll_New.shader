// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33615,y:32553,varname:node_1873,prsc:2|emission-1785-OUT,alpha-7549-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32228,y:33074,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:6337f74ea4d0447fcabf466fbeb336d8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32522,y:32869,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32228,y:33257,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32228,y:33406,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33008,y:32739,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32887,y:33247,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-817-OUT,E-837-OUT;n:type:ShaderForge.SFN_Tex2d,id:9749,x:30453,y:31630,ptovrint:False,ptlb:WaveTexture,ptin:_WaveTexture,varname:node_9749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2437492445a014c40af8c893bb55a062,ntxv:0,isnm:False|UVIN-4641-OUT;n:type:ShaderForge.SFN_TexCoord,id:7027,x:29500,y:32273,varname:node_7027,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:3227,x:30469,y:32127,ptovrint:False,ptlb:FoamTexture,ptin:_FoamTexture,varname:node_3227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cfb478ea62d034c43a0c3ea6175d0388,ntxv:0,isnm:False|UVIN-6248-OUT;n:type:ShaderForge.SFN_TexCoord,id:9919,x:29097,y:31802,varname:node_9919,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4338,x:29333,y:31619,varname:node_4338,prsc:2,spu:0,spv:0.02|UVIN-9919-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6339,x:29516,y:31619,ptovrint:False,ptlb:WaveNoise,ptin:_WaveNoise,varname:node_6339,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9789d23040cb1fb45ad60392430c3c15,ntxv:0,isnm:False|UVIN-4338-UVOUT;n:type:ShaderForge.SFN_Add,id:4641,x:30191,y:31751,varname:node_4641,prsc:2|A-6457-OUT,B-307-OUT;n:type:ShaderForge.SFN_RemapRange,id:3873,x:29781,y:31616,varname:node_3873,prsc:2,frmn:0,frmx:1,tomn:-0.02,tomx:0.02|IN-6339-R;n:type:ShaderForge.SFN_Clamp01,id:5266,x:31231,y:32254,varname:node_5266,prsc:2|IN-3601-OUT;n:type:ShaderForge.SFN_Add,id:6248,x:30184,y:32123,varname:node_6248,prsc:2|A-6457-OUT,B-8578-OUT;n:type:ShaderForge.SFN_Slider,id:388,x:31471,y:31647,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.530007,max:10;n:type:ShaderForge.SFN_RemapRange,id:4357,x:29941,y:31987,varname:node_4357,prsc:2,frmn:0,frmx:1,tomn:-0.008,tomx:-0.008|IN-6339-R;n:type:ShaderForge.SFN_Slider,id:8318,x:31019,y:32508,ptovrint:False,ptlb:FoamOpacity,ptin:_FoamOpacity,varname:node_8318,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.033347,max:5;n:type:ShaderForge.SFN_Time,id:2983,x:29008,y:32044,varname:node_2983,prsc:2;n:type:ShaderForge.SFN_Slider,id:3719,x:28851,y:32211,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_3719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.08,max:1;n:type:ShaderForge.SFN_Multiply,id:939,x:29212,y:32112,varname:node_939,prsc:2|A-2983-T,B-3719-OUT;n:type:ShaderForge.SFN_Add,id:1649,x:29467,y:32021,varname:node_1649,prsc:2|A-9919-V,B-939-OUT;n:type:ShaderForge.SFN_Append,id:307,x:29691,y:31943,varname:node_307,prsc:2|A-9919-U,B-1649-OUT;n:type:ShaderForge.SFN_Add,id:9353,x:29755,y:32513,varname:node_9353,prsc:2|A-7027-V,B-1256-OUT;n:type:ShaderForge.SFN_Slider,id:9462,x:28851,y:32424,ptovrint:False,ptlb:FoamSpeed,ptin:_FoamSpeed,varname:node_9462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.1,max:1;n:type:ShaderForge.SFN_Multiply,id:1256,x:29328,y:32487,varname:node_1256,prsc:2|A-2983-T,B-9462-OUT;n:type:ShaderForge.SFN_Append,id:8578,x:29941,y:32253,varname:node_8578,prsc:2|A-7027-U,B-9353-OUT;n:type:ShaderForge.SFN_Slider,id:9447,x:29611,y:31478,ptovrint:False,ptlb:NoisePower,ptin:_NoisePower,varname:node_9447,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2961822,max:5;n:type:ShaderForge.SFN_Multiply,id:6457,x:29968,y:31581,varname:node_6457,prsc:2|A-9447-OUT,B-3873-OUT;n:type:ShaderForge.SFN_Tex2d,id:6682,x:30469,y:31906,ptovrint:False,ptlb:FoamDetailMask,ptin:_FoamDetailMask,varname:node_6682,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c05193f65b84945c38f8c52a0cc4175f,ntxv:0,isnm:False|UVIN-4641-OUT;n:type:ShaderForge.SFN_Multiply,id:1785,x:33169,y:32326,varname:node_1785,prsc:2|A-3860-OUT,B-1086-OUT;n:type:ShaderForge.SFN_Multiply,id:3601,x:31038,y:32254,varname:node_3601,prsc:2|A-1602-OUT,B-3227-R;n:type:ShaderForge.SFN_Multiply,id:8861,x:31447,y:32337,varname:node_8861,prsc:2|A-5266-OUT,B-8318-OUT;n:type:ShaderForge.SFN_Add,id:3860,x:32786,y:32333,varname:node_3860,prsc:2|A-9673-OUT,B-8861-OUT;n:type:ShaderForge.SFN_Multiply,id:9673,x:31609,y:31491,varname:node_9673,prsc:2|A-9749-RGB,B-388-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:8640,x:30707,y:34028,varname:node_8640,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:7405,x:30707,y:34187,varname:node_7405,prsc:2;n:type:ShaderForge.SFN_Subtract,id:1976,x:30935,y:34014,varname:node_1976,prsc:2|A-8640-XYZ,B-7405-XYZ;n:type:ShaderForge.SFN_ComponentMask,id:371,x:31325,y:34014,varname:node_371,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-67-XYZ;n:type:ShaderForge.SFN_Subtract,id:725,x:31668,y:34040,varname:node_725,prsc:2|A-3853-OUT,B-4328-OUT;n:type:ShaderForge.SFN_Abs,id:4328,x:31463,y:34157,varname:node_4328,prsc:2|IN-371-OUT;n:type:ShaderForge.SFN_Vector1,id:3853,x:31482,y:33949,varname:node_3853,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Transform,id:67,x:31133,y:34014,varname:node_67,prsc:2,tffrom:0,tfto:1|IN-1976-OUT;n:type:ShaderForge.SFN_Slider,id:870,x:33029,y:33439,ptovrint:False,ptlb:OverallOpcity,ptin:_OverallOpcity,varname:node_870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:20;n:type:ShaderForge.SFN_Multiply,id:7549,x:33253,y:33222,varname:node_7549,prsc:2|A-603-OUT,B-870-OUT;n:type:ShaderForge.SFN_Add,id:817,x:31665,y:31829,varname:node_817,prsc:2|A-9749-A,B-8861-OUT;n:type:ShaderForge.SFN_Power,id:1602,x:31002,y:31995,varname:node_1602,prsc:2|VAL-6682-A,EXP-835-OUT;n:type:ShaderForge.SFN_Slider,id:835,x:30845,y:31921,ptovrint:False,ptlb:FoamPower,ptin:_FoamPower,varname:node_835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.669361,max:5;n:type:ShaderForge.SFN_Vector1,id:7720,x:32096,y:34157,varname:node_7720,prsc:2,v1:2;n:type:ShaderForge.SFN_Clamp01,id:837,x:32388,y:33895,varname:node_837,prsc:2|IN-5057-OUT;n:type:ShaderForge.SFN_Power,id:5057,x:32096,y:34028,varname:node_5057,prsc:2|VAL-725-OUT,EXP-7720-OUT;proporder:4805-5983-9749-3227-6339-388-8318-3719-9462-9447-6682-870-835;pass:END;sub:END;*/

Shader "DDT/OnewayRollDetail" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _WaveTexture ("WaveTexture", 2D) = "white" {}
        _FoamTexture ("FoamTexture", 2D) = "white" {}
        _WaveNoise ("WaveNoise", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 10)) = 8.530007
        _FoamOpacity ("FoamOpacity", Range(0, 5)) = 2.033347
        _WaveSpeed ("WaveSpeed", Range(-1, 1)) = -0.08
        _FoamSpeed ("FoamSpeed", Range(-1, 1)) = -0.1
        _NoisePower ("NoisePower", Range(0, 5)) = 0.2961822
        _FoamDetailMask ("FoamDetailMask", 2D) = "white" {}
        _OverallOpcity ("OverallOpcity", Range(0, 20)) = 1
        _FoamPower ("FoamPower", Range(0, 5)) = 1.669361
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
            uniform sampler2D _FoamTexture; uniform float4 _FoamTexture_ST;
            uniform sampler2D _WaveNoise; uniform float4 _WaveNoise_ST;
            uniform float _Brightness;
            uniform float _FoamOpacity;
            uniform float _WaveSpeed;
            uniform float _FoamSpeed;
            uniform float _NoisePower;
            uniform sampler2D _FoamDetailMask; uniform float4 _FoamDetailMask_ST;
            uniform float _OverallOpcity;
            uniform float _FoamPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
////// Lighting:
////// Emissive:
                float4 node_1641 = _Time + _TimeEditor;
                float2 node_4338 = (i.uv0+node_1641.g*float2(0,0.02));
                float4 _WaveNoise_var = tex2D(_WaveNoise,TRANSFORM_TEX(node_4338, _WaveNoise));
                float node_6457 = (_NoisePower*(_WaveNoise_var.r*0.04+-0.02));
                float4 node_2983 = _Time + _TimeEditor;
                float2 node_4641 = (node_6457+float2(i.uv0.r,(i.uv0.g+(node_2983.g*_WaveSpeed))));
                float4 _WaveTexture_var = tex2D(_WaveTexture,TRANSFORM_TEX(node_4641, _WaveTexture));
                float4 _FoamDetailMask_var = tex2D(_FoamDetailMask,TRANSFORM_TEX(node_4641, _FoamDetailMask));
                float2 node_6248 = (node_6457+float2(i.uv0.r,(i.uv0.g+(node_2983.g*_FoamSpeed))));
                float4 _FoamTexture_var = tex2D(_FoamTexture,TRANSFORM_TEX(node_6248, _FoamTexture));
                float node_8861 = (saturate((pow(_FoamDetailMask_var.a,_FoamPower)*_FoamTexture_var.a))*_FoamOpacity);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_1086 = (_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb); // RGB
                float3 emissive = (((_WaveTexture_var.rgb*_Brightness)+node_8861)*node_1086);
                float3 finalColor = emissive;
                float node_725 = (0.5-abs(mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.g));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*(_WaveTexture_var.a+node_8861)*saturate(pow(node_725,2.0))); // A
                return fixed4(finalColor,(node_603*_OverallOpcity));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
