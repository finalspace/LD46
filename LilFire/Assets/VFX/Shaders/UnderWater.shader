// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32551,y:32729,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-9829-OUT;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_TexCoord,id:7456,x:30967,y:32710,varname:node_7456,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3111,x:31160,y:32710,varname:node_3111,prsc:2,spu:0.05,spv:0.05|UVIN-7456-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6059,x:31342,y:32710,ptovrint:False,ptlb:node_6059,ptin:_node_6059,varname:node_6059,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cd460ee4ac5c1e746b7a734cc7cc64dd,ntxv:0,isnm:False|UVIN-3111-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:8164,x:31545,y:32710,varname:node_8164,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6059-RGB;n:type:ShaderForge.SFN_Vector3,id:4967,x:31529,y:32217,varname:node_4967,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Slider,id:3260,x:31372,y:32337,ptovrint:False,ptlb:Reflection,ptin:_Reflection,varname:node_3260,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.414291,max:1;n:type:ShaderForge.SFN_Lerp,id:1240,x:31762,y:32217,varname:node_1240,prsc:2|A-4967-OUT,B-8164-OUT,T-3260-OUT;n:type:ShaderForge.SFN_Normalize,id:96,x:31952,y:32217,varname:node_96,prsc:2|IN-1240-OUT;n:type:ShaderForge.SFN_Slider,id:4675,x:31228,y:32950,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_4675,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4358473,max:1;n:type:ShaderForge.SFN_Vector1,id:1152,x:31385,y:33034,varname:node_1152,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:9884,x:31558,y:32950,varname:node_9884,prsc:2|A-4675-OUT,B-1152-OUT;n:type:ShaderForge.SFN_Multiply,id:6612,x:31806,y:32726,varname:node_6612,prsc:2|A-8164-OUT,B-9884-OUT;n:type:ShaderForge.SFN_Add,id:9829,x:32115,y:32726,varname:node_9829,prsc:2|A-6612-OUT,B-7456-UVOUT;proporder:4805-5983-6059-3260-4675;pass:END;sub:END;*/

Shader "DDT/UnderWater" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _NoiseTex ("NoiseTex", 2D) = "white" {}
        _NoiseSpeedX ("NoiseSpeedX", Range(-3, 3)) = 0.05
        _NoiseSpeedY ("NoiseSpeedY", Range(-3, 3)) = 0.05
        _Distortion ("Distortion", Range(0, 1)) = 0.4358473
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
            uniform float _NoiseSpeedX;
            uniform float _NoiseSpeedY;
            uniform float4 _Color;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _Distortion;
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
                float4 node_6780 = _Time + _TimeEditor;
                float2 node_3111 = (i.uv0+node_6780.g*float2(_NoiseSpeedX,_NoiseSpeedY));
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_3111, _NoiseTex));
                float2 node_9829 = ((_NoiseTex_var.rgb.rg*(_Distortion*0.2))+i.uv0);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9829, _MainTex));
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                float3 emissive = (_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
