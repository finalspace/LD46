// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32551,y:32729,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:91cd7119efab943418d39feb1906aca6,ntxv:0,isnm:False|UVIN-5102-OUT;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Tex2d,id:4037,x:31133,y:32263,ptovrint:False,ptlb:NoiseTexture,ptin:_NoiseTexture,varname:node_4037,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6e6cba53deb4f4e41a81667b73a1ca42,ntxv:0,isnm:False|UVIN-6343-OUT;n:type:ShaderForge.SFN_RemapRange,id:8366,x:31398,y:32284,varname:node_8366,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4037-R;n:type:ShaderForge.SFN_Multiply,id:3788,x:31756,y:32430,varname:node_3788,prsc:2|A-8461-OUT,B-8366-OUT,C-1918-R;n:type:ShaderForge.SFN_Slider,id:8461,x:31398,y:32168,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_8461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.117971,max:1;n:type:ShaderForge.SFN_Add,id:5102,x:32324,y:32729,varname:node_5102,prsc:2|A-7941-OUT,B-1918-OUT;n:type:ShaderForge.SFN_Panner,id:820,x:30947,y:32323,varname:node_820,prsc:2,spu:-0.2,spv:0|UVIN-6343-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:30740,y:32263,varname:node_6343,prsc:2|A-7169-OUT,B-8422-OUT;n:type:ShaderForge.SFN_TexCoord,id:5005,x:29010,y:32104,varname:node_5005,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:1445,x:29550,y:32264,varname:node_1445,prsc:2|A-6562-OUT,B-1330-OUT;n:type:ShaderForge.SFN_Slider,id:1330,x:29033,y:32390,ptovrint:False,ptlb:size,ptin:_size,varname:node_1330,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_RemapRange,id:6562,x:29190,y:32104,varname:node_6562,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:1.1|IN-5005-UVOUT;n:type:ShaderForge.SFN_Slider,id:8422,x:30583,y:32180,ptovrint:False,ptlb:Section,ptin:_Section,varname:node_8422,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.151282,max:1;n:type:ShaderForge.SFN_ComponentMask,id:1918,x:29816,y:32325,varname:node_1918,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1445-OUT;n:type:ShaderForge.SFN_Time,id:7023,x:29724,y:32637,varname:node_7023,prsc:2;n:type:ShaderForge.SFN_Slider,id:9194,x:29567,y:32783,ptovrint:False,ptlb:WindSpeed,ptin:_WindSpeed,varname:node_9194,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:-1.074768,max:2;n:type:ShaderForge.SFN_Multiply,id:5185,x:29888,y:32657,varname:node_5185,prsc:2|A-7023-T,B-9194-OUT;n:type:ShaderForge.SFN_Add,id:2926,x:30114,y:32520,varname:node_2926,prsc:2|A-1918-R,B-5185-OUT;n:type:ShaderForge.SFN_Append,id:7169,x:30357,y:32434,varname:node_7169,prsc:2|A-2926-OUT,B-1918-G;n:type:ShaderForge.SFN_Append,id:7941,x:32091,y:32421,varname:node_7941,prsc:2|A-3788-OUT,B-6569-OUT;n:type:ShaderForge.SFN_Multiply,id:6569,x:31968,y:32586,varname:node_6569,prsc:2|A-3788-OUT,B-6310-OUT;n:type:ShaderForge.SFN_Slider,id:6310,x:31584,y:32626,ptovrint:False,ptlb:radio,ptin:_radio,varname:node_6310,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-3,cur:1,max:3;proporder:4805-5983-4037-8461-1330-8422-9194-6310;pass:END;sub:END;*/

Shader "DDT/Flag" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _NoiseTexture ("NoiseTexture", 2D) = "white" {}
        _Power ("Power", Range(0, 1)) = 0.117971
        _size ("size", Range(0, 2)) = 1
        _Section ("Section", Range(0, 1)) = 0.151282
        _WindSpeed ("WindSpeed", Range(-5, 5)) = -1.074768
        _ratio ("ratio", Range(0, 10)) = 1
        _offset("offset", Range(-1, 1)) = 0
        _Speed ("Speed", Range(0, 5.0)) = 1
        _Frequency ("Frequency", Range(0, 1.3)) = 1
        _Amplitude ("Amplitude", Range(0, 5.0)) = 1
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
            uniform sampler2D _NoiseTexture; uniform float4 _NoiseTexture_ST;
            uniform float _Power;
            uniform float _size;
            uniform float _Section;
            uniform float _WindSpeed;
            uniform float _ratio;
            uniform float _offset;
            
            uniform float _Speed;
            uniform float _Frequency;
            uniform float _Amplitude;
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
                //o.uv0.y += cos((v.texcoord0.x * _Frequency * 100 + _Time.y * _Speed)) * _Amplitude * v.texcoord0.x;
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
                float2 node_1918 = ((i.uv0*1.2 + _offset)*_size).rg;
                float4 node_7023 = _Time + _TimeEditor;
                float2 node_6343 = (float2((node_1918.r+(node_7023.g*_WindSpeed)),node_1918.g)*_Section);
                float4 _NoiseTexture_var = tex2D(_NoiseTexture,TRANSFORM_TEX(node_6343, _NoiseTexture));
                float node_3788 = (_Power*(_NoiseTexture_var.r*2.0+-1.0)*node_1918.r);
                float2 node_5102 = (float2(node_3788,(node_3788*_ratio))+node_1918);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_5102, _MainTex));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                float3 emissive = ((_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
