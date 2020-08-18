// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33339,y:32725,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT,refract-7220-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31905,y:33304,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:19a732dca8f5d49dea8e83f72cc9c80c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32304,y:33073,cmnt:RGB,varname:node_1086,prsc:2|A-1524-RGB,B-5983-RGB,C-8631-OUT;n:type:ShaderForge.SFN_Color,id:5983,x:31905,y:33495,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:31905,y:33670,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:32622,y:32816,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32677,y:33279,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-1524-A,E-7801-OUT;n:type:ShaderForge.SFN_Vector1,id:8436,x:31316,y:30345,varname:node_8436,prsc:2,v1:1;n:type:ShaderForge.SFN_Time,id:2145,x:31316,y:30432,varname:node_2145,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2912,x:31503,y:30380,varname:node_2912,prsc:2|A-8436-OUT,B-2145-T;n:type:ShaderForge.SFN_Vector1,id:1793,x:31473,y:30258,varname:node_1793,prsc:2,v1:4;n:type:ShaderForge.SFN_Subtract,id:6208,x:31705,y:30331,varname:node_6208,prsc:2|A-1793-OUT,B-2912-OUT;n:type:ShaderForge.SFN_Sin,id:815,x:31868,y:30331,varname:node_815,prsc:2|IN-6208-OUT;n:type:ShaderForge.SFN_RemapRange,id:7632,x:32058,y:30331,varname:node_7632,prsc:2,frmn:-1,frmx:1,tomn:-0.1,tomx:0.05|IN-815-OUT;n:type:ShaderForge.SFN_TexCoord,id:8046,x:32058,y:30168,varname:node_8046,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8210,x:32304,y:30292,varname:node_8210,prsc:2,spu:0,spv:1|UVIN-8046-UVOUT,DIST-7632-OUT;n:type:ShaderForge.SFN_Tex2d,id:9846,x:32526,y:30292,varname:node_9846,prsc:2,tex:37051b9f43c694bc5af4340296fdaa1c,ntxv:0,isnm:False|UVIN-8210-UVOUT,TEX-6028-TEX;n:type:ShaderForge.SFN_OneMinus,id:5243,x:32733,y:30292,varname:node_5243,prsc:2|IN-9846-B;n:type:ShaderForge.SFN_Vector1,id:9441,x:32733,y:30451,varname:node_9441,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Add,id:7416,x:32905,y:30292,varname:node_7416,prsc:2|A-5243-OUT,B-9441-OUT;n:type:ShaderForge.SFN_Clamp01,id:3696,x:33090,y:30292,varname:node_3696,prsc:2|IN-7416-OUT;n:type:ShaderForge.SFN_TexCoord,id:5047,x:28801,y:32725,varname:node_5047,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:7917,x:29007,y:32725,varname:node_7917,prsc:2,spu:-0.1,spv:0|UVIN-5047-UVOUT;n:type:ShaderForge.SFN_Vector1,id:4907,x:29007,y:32878,varname:node_4907,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:9892,x:29188,y:32725,varname:node_9892,prsc:2|A-7917-UVOUT,B-4907-OUT;n:type:ShaderForge.SFN_Tex2d,id:8526,x:29357,y:32726,ptovrint:False,ptlb:WaveNoise2,ptin:_WaveNoise2,varname:node_8526,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9c2558f3e6bb44048afeea0dda010a13,ntxv:0,isnm:False|UVIN-9892-OUT;n:type:ShaderForge.SFN_RemapRange,id:6356,x:29534,y:32726,varname:node_6356,prsc:2,frmn:0,frmx:1,tomn:-0.2,tomx:0.2|IN-8526-G;n:type:ShaderForge.SFN_Slider,id:6180,x:30295,y:32722,ptovrint:False,ptlb:NoiseMovement,ptin:_NoiseMovement,varname:node_6180,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1630296,max:1;n:type:ShaderForge.SFN_TexCoord,id:6315,x:29951,y:32496,varname:node_6315,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:6814,x:30169,y:32632,varname:node_6814,prsc:2|A-6315-UVOUT,B-8977-OUT;n:type:ShaderForge.SFN_Lerp,id:8482,x:30410,y:32528,varname:node_8482,prsc:2|A-6315-UVOUT,B-6814-OUT,T-6180-OUT;n:type:ShaderForge.SFN_Time,id:9013,x:28786,y:33298,varname:node_9013,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8533,x:28961,y:33241,varname:node_8533,prsc:2|A-4487-OUT,B-9013-T;n:type:ShaderForge.SFN_Sin,id:536,x:29601,y:33226,varname:node_536,prsc:2|IN-6758-OUT;n:type:ShaderForge.SFN_RemapRange,id:6405,x:30135,y:33226,varname:node_6405,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.05|IN-6722-OUT;n:type:ShaderForge.SFN_Panner,id:8441,x:30801,y:32730,varname:node_8441,prsc:2,spu:0,spv:1|UVIN-8482-OUT,DIST-4507-OUT;n:type:ShaderForge.SFN_OneMinus,id:6018,x:32475,y:30824,varname:node_6018,prsc:2|IN-1524-G;n:type:ShaderForge.SFN_Tex2d,id:9969,x:32475,y:30654,ptovrint:False,ptlb:node_9969,ptin:_node_9969,varname:node_9969,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6337f74ea4d0447fcabf466fbeb336d8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8579,x:32742,y:30728,varname:node_8579,prsc:2|A-9969-RGB,B-6018-OUT;n:type:ShaderForge.SFN_Multiply,id:9144,x:33061,y:30673,varname:node_9144,prsc:2|A-3696-OUT,B-8579-OUT;n:type:ShaderForge.SFN_Add,id:9830,x:33327,y:30760,varname:node_9830,prsc:2|A-9144-OUT,B-1524-RGB;n:type:ShaderForge.SFN_Tex2d,id:1524,x:31500,y:32806,varname:node_1524,prsc:2,tex:37051b9f43c694bc5af4340296fdaa1c,ntxv:0,isnm:False|UVIN-8441-UVOUT,TEX-6028-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:6028,x:30762,y:32386,ptovrint:False,ptlb:node_6028,ptin:_node_6028,varname:node_6028,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:37051b9f43c694bc5af4340296fdaa1c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:8631,x:32147,y:32961,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_8631,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7490357,max:5;n:type:ShaderForge.SFN_Slider,id:1804,x:29003,y:33393,ptovrint:False,ptlb:Offset,ptin:_Offset,varname:node_1804,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Add,id:6758,x:29160,y:33241,varname:node_6758,prsc:2|A-8533-OUT,B-1804-OUT;n:type:ShaderForge.SFN_TexCoord,id:9563,x:28801,y:32496,varname:node_9563,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:676,x:29007,y:32496,varname:node_676,prsc:2,spu:0.2,spv:0|UVIN-9563-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3744,x:29357,y:32496,ptovrint:False,ptlb:WaveNoise1,ptin:_WaveNoise1,varname:node_3744,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0822be61d4823444e959e7b335727c7c,ntxv:0,isnm:False|UVIN-839-OUT;n:type:ShaderForge.SFN_RemapRange,id:6850,x:29534,y:32496,varname:node_6850,prsc:2,frmn:0,frmx:1,tomn:-0.2,tomx:0.2|IN-3744-G;n:type:ShaderForge.SFN_Add,id:8977,x:29913,y:32700,varname:node_8977,prsc:2|A-9064-OUT,B-6356-OUT;n:type:ShaderForge.SFN_Multiply,id:839,x:29184,y:32496,varname:node_839,prsc:2|A-676-UVOUT,B-5608-OUT;n:type:ShaderForge.SFN_Vector1,id:5608,x:29007,y:32640,varname:node_5608,prsc:2,v1:0.2;n:type:ShaderForge.SFN_If,id:7801,x:30587,y:33458,varname:node_7801,prsc:2|A-5421-OUT,B-8962-OUT,GT-3824-OUT,EQ-1572-OUT,LT-1572-OUT;n:type:ShaderForge.SFN_Vector1,id:8962,x:30354,y:33504,varname:node_8962,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRange,id:3154,x:29771,y:33226,varname:node_3154,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-536-OUT;n:type:ShaderForge.SFN_Sin,id:5604,x:29536,y:33425,varname:node_5604,prsc:2|IN-4386-OUT;n:type:ShaderForge.SFN_Pi,id:709,x:28984,y:33493,varname:node_709,prsc:2;n:type:ShaderForge.SFN_Add,id:4386,x:29355,y:33425,varname:node_4386,prsc:2|A-6758-OUT,B-9851-OUT;n:type:ShaderForge.SFN_Multiply,id:9851,x:29138,y:33544,varname:node_9851,prsc:2|A-709-OUT,B-3554-OUT;n:type:ShaderForge.SFN_Power,id:6493,x:30047,y:33590,varname:node_6493,prsc:2|VAL-3154-OUT,EXP-5421-OUT;n:type:ShaderForge.SFN_RemapRange,id:3824,x:30216,y:33590,varname:node_3824,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-6493-OUT;n:type:ShaderForge.SFN_Vector1,id:3554,x:28951,y:33619,varname:node_3554,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Slider,id:5392,x:29342,y:32401,ptovrint:False,ptlb:NoisePower,ptin:_NoisePower,varname:node_5392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9500019,max:5;n:type:ShaderForge.SFN_Multiply,id:9064,x:29699,y:32496,varname:node_9064,prsc:2|A-5392-OUT,B-6850-OUT;n:type:ShaderForge.SFN_Power,id:6722,x:29970,y:33226,varname:node_6722,prsc:2|VAL-3154-OUT,EXP-3499-OUT;n:type:ShaderForge.SFN_Vector1,id:3499,x:29970,y:33137,varname:node_3499,prsc:2,v1:1.4;n:type:ShaderForge.SFN_Slider,id:3794,x:30310,y:33275,ptovrint:False,ptlb:MovementRange,ptin:_MovementRange,varname:node_3794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.277224,max:5;n:type:ShaderForge.SFN_Multiply,id:4507,x:30467,y:33118,varname:node_4507,prsc:2|A-6405-OUT,B-3794-OUT;n:type:ShaderForge.SFN_Slider,id:4487,x:28629,y:33226,ptovrint:False,ptlb:MovementSpeed,ptin:_MovementSpeed,varname:node_4487,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.2,max:5;n:type:ShaderForge.SFN_Vector1,id:1572,x:30366,y:33622,varname:node_1572,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:6991,x:31691,y:32129,varname:node_6991,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3751,x:32149,y:32244,varname:node_3751,prsc:2,spu:0,spv:-0.1|UVIN-6991-UVOUT,DIST-7824-OUT;n:type:ShaderForge.SFN_Tex2d,id:8974,x:32368,y:32244,ptovrint:False,ptlb:FoamTex,ptin:_FoamTex,varname:node_8974,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d01457b88b1c5174ea4235d140b5fab8,ntxv:0,isnm:False|UVIN-3751-UVOUT;n:type:ShaderForge.SFN_Add,id:7504,x:32862,y:32604,varname:node_7504,prsc:2|A-6354-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Slider,id:6435,x:31708,y:32467,ptovrint:False,ptlb:node_6435,ptin:_node_6435,varname:node_6435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Time,id:7804,x:31876,y:32561,varname:node_7804,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7824,x:32089,y:32471,varname:node_7824,prsc:2|A-6435-OUT,B-7804-T;n:type:ShaderForge.SFN_OneMinus,id:2843,x:32248,y:32706,varname:node_2843,prsc:2|IN-1524-R;n:type:ShaderForge.SFN_Multiply,id:6354,x:32648,y:32415,varname:node_6354,prsc:2|A-8974-RGB,B-9933-OUT,C-2843-OUT;n:type:ShaderForge.SFN_Slider,id:9933,x:32253,y:32471,ptovrint:False,ptlb:FoamPower,ptin:_FoamPower,varname:node_9933,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3275413,max:1;n:type:ShaderForge.SFN_TexCoord,id:1275,x:32198,y:33821,varname:node_1275,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4606,x:32391,y:33821,varname:node_4606,prsc:2,spu:0,spv:0.2|UVIN-1275-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2917,x:32598,y:33821,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:node_2917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:61c0b9c0523734e0e91bc6043c72a490,ntxv:0,isnm:False|UVIN-4606-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:9646,x:32792,y:33821,varname:node_9646,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2917-RGB;n:type:ShaderForge.SFN_Multiply,id:9886,x:33208,y:33818,varname:node_9886,prsc:2|A-4207-OUT,B-9829-OUT,C-1395-OUT;n:type:ShaderForge.SFN_Slider,id:9829,x:32731,y:34056,ptovrint:False,ptlb:RefractionPower,ptin:_RefractionPower,varname:node_9829,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector2,id:5374,x:33046,y:33627,varname:node_5374,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Lerp,id:7220,x:33408,y:33662,varname:node_7220,prsc:2|A-5374-OUT,B-9886-OUT,T-603-OUT;n:type:ShaderForge.SFN_RemapRange,id:4207,x:32988,y:33818,varname:node_4207,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-9646-OUT;n:type:ShaderForge.SFN_Abs,id:5411,x:30964,y:33894,varname:node_5411,prsc:2|IN-5604-OUT;n:type:ShaderForge.SFN_RemapRange,id:1395,x:31336,y:34163,varname:node_1395,prsc:2,frmn:0,frmx:1,tomn:0.3,tomx:1|IN-5411-OUT;n:type:ShaderForge.SFN_Slider,id:5421,x:29574,y:33596,ptovrint:False,ptlb:FadePower,ptin:_FadePower,varname:node_5421,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;proporder:4805-5983-8526-6180-9969-6028-8631-1804-3744-5392-3794-4487-8974-6435-9933-2917-9829-5421;pass:END;sub:END;*/

Shader "DDT/SeaShore" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _WaveNoise2 ("WaveNoise2", 2D) = "white" {}
        _NoiseMovement ("NoiseMovement", Range(0, 1)) = 0.1630296
        _node_9969 ("node_9969", 2D) = "white" {}
        _node_6028 ("node_6028", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 5)) = 0.7490357
        _Offset ("Offset", Range(0, 10)) = 0
        _WaveNoise1 ("WaveNoise1", 2D) = "white" {}
        _NoisePower ("NoisePower", Range(0, 5)) = 0.9500019
        _MovementRange ("MovementRange", Range(0, 5)) = 2.277224
        _MovementSpeed ("MovementSpeed", Range(0, 5)) = 1.2
        _FoamTex ("FoamTex", 2D) = "white" {}
        _node_6435 ("node_6435", Range(0, 1)) = 1
        _FoamPower ("FoamPower", Range(0, 1)) = 0.3275413
        _Refraction ("Refraction", 2D) = "white" {}
        _RefractionPower ("RefractionPower", Range(0, 1)) = 1
        _FadePower ("FadePower", Range(0, 10)) = 0
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
        GrabPass{ }
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
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _WaveNoise2; uniform float4 _WaveNoise2_ST;
            uniform float _NoiseMovement;
            uniform sampler2D _node_6028; uniform float4 _node_6028_ST;
            uniform float _Brightness;
            uniform float _Offset;
            uniform sampler2D _WaveNoise1; uniform float4 _WaveNoise1_ST;
            uniform float _NoisePower;
            uniform float _MovementRange;
            uniform float _MovementSpeed;
            uniform sampler2D _Refraction; uniform float4 _Refraction_ST;
            uniform float _RefractionPower;
            uniform float _FadePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
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
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float4 node_5531 = _Time + _TimeEditor;
                float2 node_4606 = (i.uv0+node_5531.g*float2(0,0.2));
                float4 _Refraction_var = tex2D(_Refraction,TRANSFORM_TEX(node_4606, _Refraction));
                float4 node_9013 = _Time + _TimeEditor;
                float node_6758 = ((_MovementSpeed*node_9013.g)+_Offset);
                float node_5411 = abs(sin((node_6758+(3.141592654*(-0.5)))));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_3154 = (sin(node_6758)*0.5+0.5);
                float2 node_839 = ((i.uv0+node_5531.g*float2(0.2,0))*0.2);
                float4 _WaveNoise1_var = tex2D(_WaveNoise1,TRANSFORM_TEX(node_839, _WaveNoise1));
                float2 node_9892 = ((i.uv0+node_5531.g*float2(-0.1,0))*0.2);
                float4 _WaveNoise2_var = tex2D(_WaveNoise2,TRANSFORM_TEX(node_9892, _WaveNoise2));
                float2 node_8441 = (lerp(i.uv0,(i.uv0+((_NoisePower*(_WaveNoise1_var.g*0.4+-0.2))+(_WaveNoise2_var.g*0.4+-0.2))),_NoiseMovement)+((pow(node_3154,1.4)*0.15+-0.1)*_MovementRange)*float2(0,1));
                float4 node_1524 = tex2D(_node_6028,TRANSFORM_TEX(node_8441, _node_6028));
                float node_7801_if_leA = step(_FadePower,0.0);
                float node_7801_if_leB = step(0.0,_FadePower);
                float node_1572 = 1.0;
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*node_1524.a*lerp((node_7801_if_leA*node_1572)+(node_7801_if_leB*(pow(node_3154,_FadePower)*-1.0+1.0)),node_1572,node_7801_if_leA*node_7801_if_leB)); // A
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + lerp(float2(0,0),((_Refraction_var.rgb.rg*0.2+-0.1)*_RefractionPower*(node_5411*0.7+0.3)),node_603);
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float3 node_1749 = ((node_1524.rgb*_Color.rgb*_Brightness)*node_603); // Premultiply Alpha
                float3 emissive = node_1749;
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,node_603),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
