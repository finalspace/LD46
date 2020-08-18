// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33615,y:32553,varname:node_1873,prsc:2|emission-7392-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32228,y:33074,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:6337f74ea4d0447fcabf466fbeb336d8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32522,y:32869,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32228,y:33257,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32228,y:33406,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33008,y:32739,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT,C-6736-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32790,y:33011,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-7249-OUT,E-6736-OUT;n:type:ShaderForge.SFN_TexCoord,id:6650,x:30161,y:33351,varname:node_6650,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1010,x:30494,y:33125,varname:node_1010,prsc:2,spu:0,spv:1|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4136,x:30494,y:33289,ptovrint:False,ptlb:node_4136,ptin:_node_4136,varname:node_4136,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:7688,x:31150,y:32833,ptovrint:False,ptlb:node_7688,ptin:_node_7688,varname:node_7688,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7769,x:31496,y:32912,varname:node_7769,prsc:2|A-7688-RGB,B-3993-OUT;n:type:ShaderForge.SFN_Step,id:1779,x:30871,y:33052,varname:node_1779,prsc:2|A-8042-OUT,B-6594-R;n:type:ShaderForge.SFN_Vector1,id:8042,x:30871,y:32996,varname:node_8042,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Panner,id:1705,x:30494,y:33447,varname:node_1705,prsc:2,spu:0,spv:0.6|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Panner,id:713,x:30494,y:33635,varname:node_713,prsc:2,spu:0,spv:0.5|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:31120,y:33244,varname:node_2021,prsc:2|A-6284-OUT,B-8533-OUT,C-8533-OUT;n:type:ShaderForge.SFN_Step,id:3722,x:30871,y:33446,varname:node_3722,prsc:2|A-579-OUT,B-9841-G;n:type:ShaderForge.SFN_Vector1,id:579,x:30871,y:33390,varname:node_579,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Step,id:8533,x:30889,y:33635,varname:node_8533,prsc:2|A-3871-OUT,B-8778-B;n:type:ShaderForge.SFN_Vector1,id:3871,x:30889,y:33579,varname:node_3871,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Step,id:6284,x:30871,y:33244,varname:node_6284,prsc:2|A-4774-OUT,B-6594-G;n:type:ShaderForge.SFN_Vector1,id:4774,x:30871,y:33188,varname:node_4774,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Add,id:3993,x:31307,y:33080,varname:node_3993,prsc:2|A-1779-OUT,B-2021-OUT;n:type:ShaderForge.SFN_Tex2d,id:6594,x:30675,y:33125,varname:node_6594,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-8236-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:9841,x:30679,y:33446,varname:node_9841,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-6920-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:8778,x:30679,y:33635,varname:node_8778,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-5656-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:5642,x:31377,y:33311,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_5642,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:24c2b50b6271b4577ac017ff3abba330,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:487,x:31744,y:32981,varname:node_487,prsc:2|A-7769-OUT,B-5642-R;n:type:ShaderForge.SFN_Slider,id:3144,x:31414,y:33525,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_3144,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8819971,max:5;n:type:ShaderForge.SFN_Slider,id:5651,x:28760,y:33566,ptovrint:False,ptlb:FlowSpeed,ptin:_FlowSpeed,varname:node_5651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2060641,max:2;n:type:ShaderForge.SFN_Time,id:6929,x:29515,y:33552,varname:node_6929,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3397,x:29515,y:33430,varname:node_3397,prsc:2|A-5951-OUT,B-6929-T;n:type:ShaderForge.SFN_TexCoord,id:723,x:29241,y:33239,varname:node_723,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:8236,x:29896,y:33267,varname:node_8236,prsc:2|A-723-U,B-3632-OUT;n:type:ShaderForge.SFN_Vector1,id:7336,x:28917,y:33647,varname:node_7336,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:1669,x:28917,y:33781,varname:node_1669,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:6693,x:28917,y:33713,varname:node_6693,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Multiply,id:5951,x:29146,y:33486,varname:node_5951,prsc:2|A-5651-OUT,B-7336-OUT;n:type:ShaderForge.SFN_Multiply,id:7388,x:29146,y:33647,varname:node_7388,prsc:2|A-5651-OUT,B-6693-OUT;n:type:ShaderForge.SFN_Multiply,id:5446,x:29146,y:33800,varname:node_5446,prsc:2|A-5651-OUT,B-1669-OUT;n:type:ShaderForge.SFN_Time,id:9037,x:29530,y:33947,varname:node_9037,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9736,x:29530,y:33821,varname:node_9736,prsc:2|A-7388-OUT,B-9037-T;n:type:ShaderForge.SFN_Append,id:6920,x:29911,y:33662,varname:node_6920,prsc:2|A-723-U,B-1001-OUT;n:type:ShaderForge.SFN_Time,id:8032,x:29539,y:34402,varname:node_8032,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2642,x:29539,y:34278,varname:node_2642,prsc:2|A-5446-OUT,B-8032-T;n:type:ShaderForge.SFN_Append,id:5656,x:29920,y:34117,varname:node_5656,prsc:2|A-723-U,B-5142-OUT;n:type:ShaderForge.SFN_Add,id:3632,x:29699,y:33360,varname:node_3632,prsc:2|A-723-V,B-3397-OUT;n:type:ShaderForge.SFN_Add,id:1001,x:29734,y:33733,varname:node_1001,prsc:2|A-723-V,B-9736-OUT;n:type:ShaderForge.SFN_Add,id:5142,x:29734,y:34132,varname:node_5142,prsc:2|A-723-V,B-2642-OUT;n:type:ShaderForge.SFN_Tex2d,id:9749,x:31039,y:31815,ptovrint:False,ptlb:WaveTexture,ptin:_WaveTexture,varname:node_9749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c7c0fbf62929047afb232a9c6d24ab36,ntxv:0,isnm:False|UVIN-4641-OUT;n:type:ShaderForge.SFN_Multiply,id:1468,x:32216,y:32719,varname:node_1468,prsc:2|A-9749-RGB,B-487-OUT;n:type:ShaderForge.SFN_TexCoord,id:7027,x:30082,y:32205,varname:node_7027,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:3227,x:31068,y:32049,ptovrint:False,ptlb:FoamTexture,ptin:_FoamTexture,varname:node_3227,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cfb478ea62d034c43a0c3ea6175d0388,ntxv:0,isnm:False|UVIN-6248-OUT;n:type:ShaderForge.SFN_Multiply,id:9066,x:31572,y:32045,varname:node_9066,prsc:2|A-3227-A,B-9749-R,C-9749-A,D-8318-OUT,E-3227-R;n:type:ShaderForge.SFN_Add,id:8151,x:32064,y:31882,varname:node_8151,prsc:2|A-4029-OUT,B-5266-OUT;n:type:ShaderForge.SFN_Multiply,id:4029,x:31425,y:31809,varname:node_4029,prsc:2|A-9749-B,B-9749-A;n:type:ShaderForge.SFN_Add,id:7392,x:33086,y:32438,varname:node_7392,prsc:2|A-6736-OUT,B-1749-OUT;n:type:ShaderForge.SFN_TexCoord,id:9919,x:29679,y:31734,varname:node_9919,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4338,x:29915,y:31551,varname:node_4338,prsc:2,spu:0,spv:0.02|UVIN-9919-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6339,x:30098,y:31551,ptovrint:False,ptlb:WaveNoise,ptin:_WaveNoise,varname:node_6339,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9789d23040cb1fb45ad60392430c3c15,ntxv:0,isnm:False|UVIN-4338-UVOUT;n:type:ShaderForge.SFN_Add,id:4641,x:30773,y:31683,varname:node_4641,prsc:2|A-6457-OUT,B-307-OUT;n:type:ShaderForge.SFN_RemapRange,id:3873,x:30363,y:31548,varname:node_3873,prsc:2,frmn:0,frmx:1,tomn:-0.02,tomx:0.02|IN-6339-R;n:type:ShaderForge.SFN_Clamp01,id:5266,x:31846,y:32035,varname:node_5266,prsc:2|IN-9066-OUT;n:type:ShaderForge.SFN_Add,id:6248,x:30766,y:32055,varname:node_6248,prsc:2|A-4357-OUT,B-8578-OUT;n:type:ShaderForge.SFN_Multiply,id:6736,x:32404,y:31924,varname:node_6736,prsc:2|A-388-OUT,B-8151-OUT;n:type:ShaderForge.SFN_Slider,id:388,x:32078,y:31795,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_388,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:4357,x:30523,y:31919,varname:node_4357,prsc:2,frmn:0,frmx:1,tomn:-0.01,tomx:0.01|IN-6339-R;n:type:ShaderForge.SFN_Slider,id:8318,x:31091,y:32388,ptovrint:False,ptlb:FoamOpacity,ptin:_FoamOpacity,varname:node_8318,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.920179,max:5;n:type:ShaderForge.SFN_Time,id:2983,x:29590,y:31976,varname:node_2983,prsc:2;n:type:ShaderForge.SFN_Slider,id:3719,x:29433,y:32143,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_3719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.1,max:1;n:type:ShaderForge.SFN_Multiply,id:939,x:29794,y:32044,varname:node_939,prsc:2|A-2983-T,B-3719-OUT;n:type:ShaderForge.SFN_Add,id:1649,x:30049,y:31953,varname:node_1649,prsc:2|A-9919-V,B-939-OUT;n:type:ShaderForge.SFN_Append,id:307,x:30273,y:31875,varname:node_307,prsc:2|A-9919-U,B-1649-OUT;n:type:ShaderForge.SFN_Add,id:9353,x:30337,y:32445,varname:node_9353,prsc:2|A-7027-V,B-1256-OUT;n:type:ShaderForge.SFN_Slider,id:9462,x:29433,y:32356,ptovrint:False,ptlb:FoamSpeed,ptin:_FoamSpeed,varname:node_9462,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.06452992,max:1;n:type:ShaderForge.SFN_Multiply,id:1256,x:29910,y:32419,varname:node_1256,prsc:2|A-2983-T,B-9462-OUT;n:type:ShaderForge.SFN_Append,id:8578,x:30523,y:32185,varname:node_8578,prsc:2|A-7027-U,B-9353-OUT;n:type:ShaderForge.SFN_Multiply,id:7249,x:31892,y:33393,varname:node_7249,prsc:2|A-5642-A,B-3144-OUT;n:type:ShaderForge.SFN_Color,id:5937,x:32452,y:31580,ptovrint:False,ptlb:node_5937,ptin:_node_5937,varname:node_5937,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:1154,x:32848,y:31814,varname:node_1154,prsc:2|A-5937-RGB,B-6736-OUT;n:type:ShaderForge.SFN_Slider,id:9447,x:30193,y:31410,ptovrint:False,ptlb:NoisePower,ptin:_NoisePower,varname:node_9447,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2961822,max:5;n:type:ShaderForge.SFN_Multiply,id:6457,x:30550,y:31513,varname:node_6457,prsc:2|A-9447-OUT,B-3873-OUT;proporder:4805-5983-4136-7688-5642-3144-5651-9749-3227-6339-388-8318-3719-9462-5937-9447;pass:END;sub:END;*/

Shader "DDT/OnewayRoll" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _node_4136 ("node_4136", 2D) = "white" {}
        _node_7688 ("node_7688", Color) = (1,1,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _Opacity ("Opacity", Range(0, 5)) = 0.8819971
        _FlowSpeed ("FlowSpeed", Range(0, 2)) = 0.2060641
        _WaveTexture ("WaveTexture", 2D) = "white" {}
        _FoamTexture ("FoamTexture", 2D) = "white" {}
        _WaveNoise ("WaveNoise", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 1
        _FoamOpacity ("FoamOpacity", Range(0, 5)) = 1.920179
        _WaveSpeed ("WaveSpeed", Range(-1, 1)) = -0.1
        _FoamSpeed ("FoamSpeed", Range(-1, 1)) = -0.06452992
        _node_5937 ("node_5937", Color) = (1,1,1,1)
        _NoisePower ("NoisePower", Range(0, 5)) = 0.2961822
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Opacity;
            uniform sampler2D _WaveTexture; uniform float4 _WaveTexture_ST;
            uniform sampler2D _FoamTexture; uniform float4 _FoamTexture_ST;
            uniform sampler2D _WaveNoise; uniform float4 _WaveNoise_ST;
            uniform float _Brightness;
            uniform float _FoamOpacity;
            uniform float _WaveSpeed;
            uniform float _FoamSpeed;
            uniform float _NoisePower;
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
                float4 node_9861 = _Time + _TimeEditor;
                float2 node_4338 = (i.uv0+node_9861.g*float2(0,0.02));
                float4 _WaveNoise_var = tex2D(_WaveNoise,TRANSFORM_TEX(node_4338, _WaveNoise));
                float4 node_2983 = _Time + _TimeEditor;
                float2 node_4641 = ((_NoisePower*(_WaveNoise_var.r*0.04+-0.02))+float2(i.uv0.r,(i.uv0.g+(node_2983.g*_WaveSpeed))));
                float4 _WaveTexture_var = tex2D(_WaveTexture,TRANSFORM_TEX(node_4641, _WaveTexture));
                float2 node_6248 = ((_WaveNoise_var.r*0.02+-0.01)+float2(i.uv0.r,(i.uv0.g+(node_2983.g*_FoamSpeed))));
                float4 _FoamTexture_var = tex2D(_FoamTexture,TRANSFORM_TEX(node_6248, _FoamTexture));
                float node_6736 = (_Brightness*((_WaveTexture_var.b*_WaveTexture_var.a)+saturate((_FoamTexture_var.a*_WaveTexture_var.r*_WaveTexture_var.a*_FoamOpacity*_FoamTexture_var.r))));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*(_Mask_var.a*_Opacity)*node_6736); // A
                float3 emissive = (node_6736+((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_603*node_6736));
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
