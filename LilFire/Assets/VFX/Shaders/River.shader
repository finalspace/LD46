// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32176,y:33252,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:6337f74ea4d0447fcabf466fbeb336d8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32522,y:32869,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32176,y:33435,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32176,y:33584,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-6550-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A,D-5642-A,E-9581-OUT;n:type:ShaderForge.SFN_TexCoord,id:6650,x:30235,y:33305,varname:node_6650,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1010,x:30452,y:33007,varname:node_1010,prsc:2,spu:0,spv:1|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4136,x:30452,y:33171,ptovrint:False,ptlb:node_4136,ptin:_node_4136,varname:node_4136,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:7688,x:31142,y:32563,ptovrint:False,ptlb:TextureColor,ptin:_TextureColor,varname:node_7688,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7769,x:31517,y:32652,varname:node_7769,prsc:2|A-7688-RGB,B-3993-OUT;n:type:ShaderForge.SFN_Add,id:6550,x:32766,y:32514,varname:node_6550,prsc:2|A-9623-OUT,B-1086-OUT;n:type:ShaderForge.SFN_Step,id:1779,x:30829,y:32934,varname:node_1779,prsc:2|A-8042-OUT,B-6594-R;n:type:ShaderForge.SFN_Vector1,id:8042,x:30829,y:32878,varname:node_8042,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Panner,id:1705,x:30452,y:33329,varname:node_1705,prsc:2,spu:0,spv:0.6|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Panner,id:713,x:30452,y:33517,varname:node_713,prsc:2,spu:0,spv:0.5|UVIN-6650-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2021,x:31078,y:33126,varname:node_2021,prsc:2|A-6284-OUT,B-8533-OUT,C-8533-OUT;n:type:ShaderForge.SFN_Step,id:3722,x:30829,y:33328,varname:node_3722,prsc:2|A-579-OUT,B-9841-G;n:type:ShaderForge.SFN_Vector1,id:579,x:30829,y:33272,varname:node_579,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Step,id:8533,x:30847,y:33517,varname:node_8533,prsc:2|A-3871-OUT,B-8778-B;n:type:ShaderForge.SFN_Vector1,id:3871,x:30847,y:33461,varname:node_3871,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Step,id:6284,x:30829,y:33126,varname:node_6284,prsc:2|A-4774-OUT,B-6594-G;n:type:ShaderForge.SFN_Vector1,id:4774,x:30829,y:33070,varname:node_4774,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Add,id:3993,x:31245,y:32875,varname:node_3993,prsc:2|A-1779-OUT,B-2021-OUT;n:type:ShaderForge.SFN_Tex2d,id:6594,x:30633,y:33007,varname:node_6594,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-8236-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:9841,x:30637,y:33328,varname:node_9841,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-6920-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:8778,x:30637,y:33517,varname:node_8778,prsc:2,tex:f0039f72d81b04e3b88a97ad5eb721f4,ntxv:0,isnm:False|UVIN-5656-OUT,TEX-4136-TEX;n:type:ShaderForge.SFN_Tex2d,id:5642,x:31572,y:33258,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_5642,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f864feb7dd8b3214ebf22602cf36c378,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:487,x:31884,y:32367,varname:node_487,prsc:2|A-7769-OUT,B-5642-R;n:type:ShaderForge.SFN_Slider,id:3144,x:31743,y:32228,ptovrint:False,ptlb:TextureBrightness,ptin:_TextureBrightness,varname:node_3144,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Add,id:9623,x:32100,y:32299,varname:node_9623,prsc:2|A-3144-OUT,B-487-OUT;n:type:ShaderForge.SFN_Slider,id:5651,x:28760,y:33566,ptovrint:False,ptlb:FlowSpeed,ptin:_FlowSpeed,varname:node_5651,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2060641,max:2;n:type:ShaderForge.SFN_Time,id:6929,x:29515,y:33552,varname:node_6929,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3397,x:29515,y:33430,varname:node_3397,prsc:2|A-5951-OUT,B-6929-T;n:type:ShaderForge.SFN_TexCoord,id:723,x:29241,y:33239,varname:node_723,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:8236,x:29896,y:33267,varname:node_8236,prsc:2|A-723-U,B-3632-OUT;n:type:ShaderForge.SFN_Vector1,id:7336,x:28917,y:33647,varname:node_7336,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:1669,x:28917,y:33781,varname:node_1669,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:6693,x:28917,y:33713,varname:node_6693,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Multiply,id:5951,x:29146,y:33486,varname:node_5951,prsc:2|A-5651-OUT,B-7336-OUT;n:type:ShaderForge.SFN_Multiply,id:7388,x:29146,y:33647,varname:node_7388,prsc:2|A-5651-OUT,B-6693-OUT;n:type:ShaderForge.SFN_Multiply,id:5446,x:29146,y:33800,varname:node_5446,prsc:2|A-5651-OUT,B-1669-OUT;n:type:ShaderForge.SFN_Time,id:9037,x:29530,y:33947,varname:node_9037,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9736,x:29530,y:33821,varname:node_9736,prsc:2|A-7388-OUT,B-9037-T;n:type:ShaderForge.SFN_Append,id:6920,x:29911,y:33662,varname:node_6920,prsc:2|A-723-U,B-1001-OUT;n:type:ShaderForge.SFN_Time,id:8032,x:29539,y:34402,varname:node_8032,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2642,x:29539,y:34278,varname:node_2642,prsc:2|A-5446-OUT,B-8032-T;n:type:ShaderForge.SFN_Append,id:5656,x:29920,y:34117,varname:node_5656,prsc:2|A-723-U,B-5142-OUT;n:type:ShaderForge.SFN_Add,id:3632,x:29699,y:33360,varname:node_3632,prsc:2|A-723-V,B-3397-OUT;n:type:ShaderForge.SFN_Add,id:1001,x:29734,y:33733,varname:node_1001,prsc:2|A-723-V,B-9736-OUT;n:type:ShaderForge.SFN_Add,id:5142,x:29734,y:34132,varname:node_5142,prsc:2|A-723-V,B-2642-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5518,x:31927,y:32950,varname:node_5518,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7769-OUT;n:type:ShaderForge.SFN_Multiply,id:9581,x:32158,y:32881,varname:node_9581,prsc:2|A-607-OUT,B-5518-OUT;n:type:ShaderForge.SFN_Slider,id:607,x:31809,y:32814,ptovrint:False,ptlb:OverallTransparency,ptin:_OverallTransparency,varname:node_607,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;proporder:4805-5983-4136-7688-5642-3144-5651-607;pass:END;sub:END;*/

Shader "DDT/River" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _node_4136 ("node_4136", 2D) = "white" {}
        _TextureColor ("TextureColor", Color) = (1,1,1,1)
        _Mask ("Mask", 2D) = "white" {}
        _TextureBrightness ("TextureBrightness", Range(0, 5)) = 1
        _FlowSpeed ("FlowSpeed", Range(0, 2)) = 0.2060641
        _OverallTransparency ("OverallTransparency", Range(0, 5)) = 1
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
            uniform float4 _Color;
            uniform sampler2D _node_4136; uniform float4 _node_4136_ST;
            uniform float4 _TextureColor;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _TextureBrightness;
            uniform float _FlowSpeed;
            uniform float _OverallTransparency;
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
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_6929 = _Time + _TimeEditor;
                float2 node_8236 = float2(i.uv0.r,(i.uv0.g+((_FlowSpeed*1.0)*node_6929.g)));
                float4 node_6594 = tex2D(_node_4136,TRANSFORM_TEX(node_8236, _node_4136));
                float4 node_8032 = _Time + _TimeEditor;
                float2 node_5656 = float2(i.uv0.r,(i.uv0.g+((_FlowSpeed*0.5)*node_8032.g)));
                float4 node_8778 = tex2D(_node_4136,TRANSFORM_TEX(node_5656, _node_4136));
                float node_8533 = step(0.6,node_8778.b);
                //float3 node_7769 = (_TextureColor.rgb*(step(0.5,node_6594.r)+(step(0.6,node_6594.g)*node_8533*node_8533)));
                float node_3993 = (step(0.5,node_6594.r)+(step(0.6,node_6594.g)*node_8533*node_8533));
                //float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*_Mask_var.a*(_OverallTransparency*node_7769.r)); // A
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a*_Mask_var.a*(_OverallTransparency*node_3993.r)); // A
                float3 emissive = (((_TextureBrightness+_Mask_var.r)+(_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb))*_TextureColor.rgb*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
