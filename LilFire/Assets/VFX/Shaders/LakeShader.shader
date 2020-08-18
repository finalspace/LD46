// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:0,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33512,y:32559,varname:node_1873,prsc:2|emission-8426-OUT,alpha-4791-OUT,refract-3182-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:30695,y:32934,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:d005da5f09c4046d98a95063dbc51b30,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5983,x:31954,y:32819,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:33096,y:33702,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:32960,y:32816,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-3886-OUT,B-2440-OUT;n:type:ShaderForge.SFN_TexCoord,id:5264,x:29531,y:31744,varname:node_5264,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:6120,x:29732,y:31744,varname:node_6120,prsc:2,spu:-0.05,spv:-0.05|UVIN-5264-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2944,x:29774,y:31476,varname:node_2944,prsc:2|A-5264-UVOUT,B-6162-OUT;n:type:ShaderForge.SFN_Vector1,id:6162,x:29774,y:31417,varname:node_6162,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:4217,x:29923,y:31744,ptovrint:False,ptlb:SurfaceNoiseTex,ptin:_SurfaceNoiseTex,varname:node_4217,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82324340e56b74a18a436642ac78d477,ntxv:0,isnm:False|UVIN-6120-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:1750,x:30108,y:31744,varname:node_1750,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-4217-R;n:type:ShaderForge.SFN_Add,id:3103,x:30676,y:31634,varname:node_3103,prsc:2|A-2944-OUT,B-703-OUT,C-117-OUT;n:type:ShaderForge.SFN_Tex2d,id:8783,x:31241,y:32009,ptovrint:False,ptlb:Shimmer,ptin:_Shimmer,varname:node_8783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:72a976db866a541b692f7eb271ac1133,ntxv:0,isnm:False|UVIN-3103-OUT;n:type:ShaderForge.SFN_Subtract,id:8372,x:31427,y:32009,varname:node_8372,prsc:2|A-8783-A,B-1455-OUT;n:type:ShaderForge.SFN_Slider,id:8600,x:30911,y:32194,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_8600,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_OneMinus,id:1455,x:31241,y:32194,varname:node_1455,prsc:2|IN-8600-OUT;n:type:ShaderForge.SFN_Multiply,id:5615,x:31807,y:32100,varname:node_5615,prsc:2|A-8372-OUT,B-5877-OUT;n:type:ShaderForge.SFN_Slider,id:5877,x:31416,y:32194,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_5877,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.294519,max:2;n:type:ShaderForge.SFN_Multiply,id:38,x:32233,y:32122,cmnt:NoiseTexture,varname:node_38,prsc:2|A-8661-OUT,B-5586-OUT,C-897-OUT;n:type:ShaderForge.SFN_RemapRange,id:5586,x:30991,y:32920,varname:node_5586,prsc:2,frmn:0.2,frmx:0.6,tomn:0,tomx:1|IN-4805-R;n:type:ShaderForge.SFN_Color,id:8215,x:30991,y:33291,ptovrint:False,ptlb:ColorNear,ptin:_ColorNear,varname:node_8215,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.006704159,c2:0.8463387,c3:0.9117647,c4:1;n:type:ShaderForge.SFN_Color,id:3596,x:30991,y:33120,ptovrint:False,ptlb:ColorFar,ptin:_ColorFar,varname:node_3596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.2539532,c3:0.3235294,c4:1;n:type:ShaderForge.SFN_Lerp,id:1239,x:31981,y:32984,varname:node_1239,prsc:2|A-3596-RGB,B-8215-RGB,T-5586-OUT;n:type:ShaderForge.SFN_Multiply,id:781,x:32214,y:32815,varname:node_781,prsc:2|A-5983-RGB,B-1239-OUT;n:type:ShaderForge.SFN_Add,id:3886,x:32566,y:32602,varname:node_3886,prsc:2|A-38-OUT,B-781-OUT,C-926-OUT,D-7499-OUT;n:type:ShaderForge.SFN_Color,id:2766,x:31673,y:33951,ptovrint:False,ptlb:node_2766,ptin:_node_2766,varname:node_2766,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:2255,x:31673,y:33778,ptovrint:False,ptlb:node_2255,ptin:_node_2255,varname:node_2255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:926,x:32190,y:33778,varname:node_926,prsc:2|A-1566-OUT,B-1477-RGB,C-7733-OUT;n:type:ShaderForge.SFN_Slider,id:7733,x:32033,y:34112,ptovrint:False,ptlb:RimPower,ptin:_RimPower,varname:node_7733,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Lerp,id:1566,x:31957,y:33669,varname:node_1566,prsc:2|A-2255-RGB,B-2766-RGB,T-898-OUT;n:type:ShaderForge.SFN_Multiply,id:2440,x:32680,y:33047,varname:node_2440,prsc:2|A-4805-A,B-5983-A;n:type:ShaderForge.SFN_TexCoord,id:6408,x:33051,y:31272,varname:node_6408,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2685,x:33252,y:31272,varname:node_2685,prsc:2,spu:0.05,spv:0.05|UVIN-6408-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4108,x:33444,y:31272,ptovrint:False,ptlb:Wave,ptin:_Wave,varname:node_4108,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6e6cba53deb4f4e41a81667b73a1ca42,ntxv:0,isnm:False|UVIN-2685-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:7263,x:33627,y:31272,varname:node_7263,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-4108-RGB;n:type:ShaderForge.SFN_Slider,id:4037,x:29948,y:31950,ptovrint:False,ptlb:SurfaceNoisePower,ptin:_SurfaceNoisePower,varname:node_4037,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:703,x:30304,y:31744,varname:node_703,prsc:2|A-1750-OUT,B-4037-OUT;n:type:ShaderForge.SFN_Slider,id:2719,x:33712,y:31554,ptovrint:False,ptlb:WavePower,ptin:_WavePower,varname:node_2719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.147872,max:1;n:type:ShaderForge.SFN_Multiply,id:117,x:33826,y:31272,varname:node_117,prsc:2|A-7263-OUT,B-2719-OUT;n:type:ShaderForge.SFN_Slider,id:5,x:31262,y:32704,ptovrint:False,ptlb:DepthPower,ptin:_DepthPower,varname:node_5,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.151178,max:2;n:type:ShaderForge.SFN_Power,id:897,x:31419,y:32557,varname:node_897,prsc:2|VAL-5586-OUT,EXP-5-OUT;n:type:ShaderForge.SFN_Slider,id:968,x:31692,y:31969,ptovrint:False,ptlb:CausticBrightness,ptin:_CausticBrightness,varname:node_968,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.1819892,max:1;n:type:ShaderForge.SFN_Add,id:8661,x:32053,y:31995,varname:node_8661,prsc:2|A-968-OUT,B-5615-OUT;n:type:ShaderForge.SFN_Power,id:898,x:31414,y:33532,varname:node_898,prsc:2|VAL-5586-OUT,EXP-6902-OUT;n:type:ShaderForge.SFN_Slider,id:6902,x:31257,y:33687,ptovrint:False,ptlb:RimRange,ptin:_RimRange,varname:node_6902,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.264634,max:10;n:type:ShaderForge.SFN_Color,id:1477,x:32190,y:33937,ptovrint:False,ptlb:RimColor,ptin:_RimColor,varname:node_1477,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6176471,c2:0.8892495,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:6469,x:33005,y:33124,ptovrint:False,ptlb:OverallOpacity,ptin:_OverallOpacity,varname:node_6469,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7521368,max:1;n:type:ShaderForge.SFN_Multiply,id:4791,x:33162,y:32982,varname:node_4791,prsc:2|A-2440-OUT,B-6469-OUT;n:type:ShaderForge.SFN_Slider,id:4965,x:32792,y:32556,ptovrint:False,ptlb:OverallBrightness,ptin:_OverallBrightness,varname:node_4965,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7758111,max:2;n:type:ShaderForge.SFN_Multiply,id:8426,x:33197,y:32649,varname:node_8426,prsc:2|A-4965-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Vector3,id:8209,x:35135,y:32162,varname:node_8209,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Slider,id:7348,x:34978,y:32280,ptovrint:False,ptlb:Reflection,ptin:_Reflection,varname:node_7348,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:5658,x:35396,y:32205,varname:node_5658,prsc:2|A-8209-OUT,B-6915-OUT,T-7348-OUT;n:type:ShaderForge.SFN_TexCoord,id:8651,x:33856,y:32775,varname:node_8651,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:528,x:34022,y:32775,varname:node_528,prsc:2,spu:0.02,spv:0.02|UVIN-8651-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6962,x:34177,y:32775,ptovrint:False,ptlb:RefractionNoiseTex,ptin:_RefractionNoiseTex,varname:node_6962,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-528-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:2337,x:34721,y:32755,varname:node_2337,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3306-OUT;n:type:ShaderForge.SFN_Multiply,id:3182,x:34957,y:33023,varname:node_3182,prsc:2|A-2337-OUT,B-7744-OUT;n:type:ShaderForge.SFN_Multiply,id:7744,x:34624,y:33111,varname:node_7744,prsc:2|A-463-OUT,B-3415-OUT;n:type:ShaderForge.SFN_Slider,id:463,x:34297,y:33111,ptovrint:False,ptlb:Distortion,ptin:_Distortion,varname:node_463,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6939718,max:1;n:type:ShaderForge.SFN_Vector1,id:3415,x:34454,y:33194,varname:node_3415,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:3306,x:34547,y:32755,varname:node_3306,prsc:2|A-7307-OUT,B-6962-RGB;n:type:ShaderForge.SFN_Multiply,id:7307,x:34219,y:31780,varname:node_7307,prsc:2|A-117-OUT,B-95-OUT,C-5280-OUT;n:type:ShaderForge.SFN_Slider,id:95,x:33801,y:31867,ptovrint:False,ptlb:DistortionWave,ptin:_DistortionWave,varname:node_95,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.017094,max:2;n:type:ShaderForge.SFN_Vector1,id:5280,x:33947,y:31947,varname:node_5280,prsc:2,v1:10;n:type:ShaderForge.SFN_OneMinus,id:8438,x:31954,y:32591,varname:node_8438,prsc:2|IN-5586-OUT;n:type:ShaderForge.SFN_OneMinus,id:234,x:34942,y:32597,varname:node_234,prsc:2|IN-4105-OUT;n:type:ShaderForge.SFN_Append,id:6772,x:35184,y:32597,varname:node_6772,prsc:2|A-234-OUT,B-5888-OUT;n:type:ShaderForge.SFN_Vector1,id:5888,x:35184,y:32723,varname:node_5888,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:9413,x:33768,y:32573,varname:node_9413,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:8310,x:33934,y:32573,varname:node_8310,prsc:2,spu:0.01,spv:0.01|UVIN-9413-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8951,x:34088,y:32573,ptovrint:False,ptlb:ReflectionNoiseTex,ptin:_ReflectionNoiseTex,varname:node_8951,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:82324340e56b74a18a436642ac78d477,ntxv:0,isnm:False|UVIN-8310-UVOUT;n:type:ShaderForge.SFN_Add,id:3219,x:34547,y:32597,varname:node_3219,prsc:2|A-7307-OUT,B-8986-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4105,x:34721,y:32597,varname:node_4105,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3219-OUT;n:type:ShaderForge.SFN_Dot,id:1044,x:35590,y:32069,varname:node_1044,prsc:2,dt:0|A-8209-OUT,B-5658-OUT;n:type:ShaderForge.SFN_Step,id:2565,x:36011,y:32058,varname:node_2565,prsc:2|A-2800-OUT,B-1044-OUT;n:type:ShaderForge.SFN_Slider,id:2800,x:35433,y:31909,ptovrint:False,ptlb:ReflectionRange,ptin:_ReflectionRange,varname:node_2800,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6505137,max:1;n:type:ShaderForge.SFN_Color,id:2742,x:36042,y:31876,ptovrint:False,ptlb:ReflectionColor,ptin:_ReflectionColor,varname:node_2742,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9206,x:36295,y:31999,varname:node_9206,prsc:2|A-2742-RGB,B-2565-OUT,C-4255-OUT;n:type:ShaderForge.SFN_Slider,id:4255,x:35951,y:32220,ptovrint:False,ptlb:ReflectionPower,ptin:_ReflectionPower,varname:node_4255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Normalize,id:6915,x:35376,y:32597,varname:node_6915,prsc:2|IN-6772-OUT;n:type:ShaderForge.SFN_RemapRange,id:8986,x:34257,y:32573,varname:node_8986,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.2|IN-8951-R;n:type:ShaderForge.SFN_Multiply,id:7474,x:32129,y:32575,varname:node_7474,prsc:2|A-9206-OUT,B-8438-OUT;n:type:ShaderForge.SFN_Step,id:3943,x:32311,y:32550,varname:node_3943,prsc:2|A-5696-OUT,B-7474-OUT;n:type:ShaderForge.SFN_Vector1,id:5696,x:32129,y:32513,varname:node_5696,prsc:2,v1:0.8;n:type:ShaderForge.SFN_If,id:7499,x:36299,y:31364,varname:node_7499,prsc:2|A-2800-OUT,B-1044-OUT,GT-9002-OUT,EQ-717-OUT,LT-717-OUT;n:type:ShaderForge.SFN_RemapRange,id:6956,x:36101,y:31690,varname:node_6956,prsc:2,frmn:0.5,frmx:1,tomn:0,tomx:1|IN-1044-OUT;n:type:ShaderForge.SFN_Multiply,id:717,x:36394,y:31682,varname:node_717,prsc:2|A-6956-OUT,B-2742-RGB,C-9703-OUT;n:type:ShaderForge.SFN_Vector4,id:9002,x:35771,y:31624,varname:node_9002,prsc:2,v1:0,v2:0,v3:0,v4:1;n:type:ShaderForge.SFN_ValueProperty,id:9703,x:36370,y:31862,ptovrint:False,ptlb:node_9703,ptin:_node_9703,varname:node_9703,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;proporder:4805-5983-4217-8783-8600-5877-968-8215-3596-2766-2255-4108-4037-2719-5-7733-6902-1477-6469-4965-7348-6962-463-95-8951-2800-2742-4255-9703;pass:END;sub:END;*/

Shader "DDT/LakeShader" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _SurfaceNoiseTex ("SurfaceNoiseTex", 2D) = "white" {}
        _Shimmer ("Shimmer", 2D) = "white" {}
        _Thickness ("Thickness", Range(0, 1)) = 1
        _Opacity ("Opacity", Range(0, 2)) = 1.294519
        _CausticBrightness ("CausticBrightness", Range(-1, 1)) = -0.1819892
        _ColorNear ("ColorNear", Color) = (0.006704159,0.8463387,0.9117647,1)
        _ColorFar ("ColorFar", Color) = (0,0.2539532,0.3235294,1)
        _node_2766 ("node_2766", Color) = (1,1,1,1)
        _node_2255 ("node_2255", Color) = (0,0,0,1)
        _Wave ("Wave", 2D) = "white" {}
        _SurfaceNoisePower ("SurfaceNoisePower", Range(0, 1)) = 0
        _WavePower ("WavePower", Range(0, 1)) = 0.147872
        _DepthPower ("DepthPower", Range(0, 2)) = 1.151178
        _RimPower ("RimPower", Range(0, 10)) = 1
        _RimRange ("RimRange", Range(0, 10)) = 3.264634
        _RimColor ("RimColor", Color) = (0.6176471,0.8892495,1,1)
        _OverallOpacity ("OverallOpacity", Range(0, 1)) = 0.7521368
        _OverallBrightness ("OverallBrightness", Range(0, 2)) = 0.7758111
        _Reflection ("Reflection", Range(0, 1)) = 1
        _RefractionNoiseTex ("RefractionNoiseTex", 2D) = "white" {}
        _Distortion ("Distortion", Range(0, 1)) = 0.6939718
        _DistortionWave ("DistortionWave", Range(0, 2)) = 1.017094
        _ReflectionNoiseTex ("ReflectionNoiseTex", 2D) = "white" {}
        _ReflectionRange ("ReflectionRange", Range(0, 1)) = 0.6505137
        _ReflectionColor ("ReflectionColor", Color) = (1,1,1,1)
        _ReflectionPower ("ReflectionPower", Range(0, 2)) = 2
        _node_9703 ("node_9703", Float ) = 5
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 2.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _SurfaceNoiseTex; uniform float4 _SurfaceNoiseTex_ST;
            uniform sampler2D _Shimmer; uniform float4 _Shimmer_ST;
            uniform float _Thickness;
            uniform float _Opacity;
            uniform float4 _ColorNear;
            uniform float4 _ColorFar;
            uniform float4 _node_2766;
            uniform float4 _node_2255;
            uniform float _RimPower;
            uniform sampler2D _Wave; uniform float4 _Wave_ST;
            uniform float _SurfaceNoisePower;
            uniform float _WavePower;
            uniform float _DepthPower;
            uniform float _CausticBrightness;
            uniform float _RimRange;
            uniform float4 _RimColor;
            uniform float _OverallOpacity;
            uniform float _OverallBrightness;
            uniform float _Reflection;
            uniform sampler2D _RefractionNoiseTex; uniform float4 _RefractionNoiseTex_ST;
            uniform float _Distortion;
            uniform float _DistortionWave;
            uniform sampler2D _ReflectionNoiseTex; uniform float4 _ReflectionNoiseTex_ST;
            uniform float _ReflectionRange;
            uniform float4 _ReflectionColor;
            uniform float _node_9703;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float4 node_4456 = _Time + _TimeEditor;
                float2 node_2685 = (i.uv0+node_4456.g*float2(0.05,0.05));
                float4 _Wave_var = tex2D(_Wave,TRANSFORM_TEX(node_2685, _Wave));
                float3 node_117 = ((_Wave_var.rgb*0.1+0.0)*_WavePower);
                float3 node_7307 = (node_117*_DistortionWave*10.0);
                float2 node_528 = (i.uv0+node_4456.g*float2(0.02,0.02));
                float4 _RefractionNoiseTex_var = tex2D(_RefractionNoiseTex,TRANSFORM_TEX(node_528, _RefractionNoiseTex));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + ((node_7307+_RefractionNoiseTex_var.rgb).rg*(_Distortion*0.1));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
////// Emissive:
                float2 node_6120 = (i.uv0+node_4456.g*float2(-0.02,-0.02));
                float4 _SurfaceNoiseTex_var = tex2D(_SurfaceNoiseTex,TRANSFORM_TEX(node_6120, _SurfaceNoiseTex));
                float3 node_3103 = (float3((i.uv0*1.0),0.0)+((_SurfaceNoiseTex_var.r*0.1+0.0)*_SurfaceNoisePower)+node_117);
                float4 _Shimmer_var = tex2D(_Shimmer,TRANSFORM_TEX(node_3103, _Shimmer));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_5586 = (_MainTex_var.r*2.5+-0.5);
                float3 node_8209 = float3(0,0,1);
                float2 node_8310 = (i.uv0+node_4456.g*float2(0.01,0.01));
                float4 _ReflectionNoiseTex_var = tex2D(_ReflectionNoiseTex,TRANSFORM_TEX(node_8310, _ReflectionNoiseTex));
                float node_1044 = dot(node_8209,lerp(node_8209,normalize(float3((1.0 - (node_7307+(_ReflectionNoiseTex_var.r*0.2+0.0)).rg),1.0)),_Reflection));
                float node_7499_if_leA = step(_ReflectionRange,node_1044);
                float node_7499_if_leB = step(node_1044,_ReflectionRange);
                float3 node_717 = ((node_1044*2.0+-1.0)*_ReflectionColor.rgb*_node_9703);
                float node_2440 = (_MainTex_var.a*_Color.a);
                float3 emissive = (_OverallBrightness*((((_CausticBrightness+((_Shimmer_var.a-(1.0 - _Thickness))*_Opacity))*node_5586*pow(node_5586,_DepthPower))+(_Color.rgb*lerp(_ColorFar.rgb,_ColorNear.rgb,node_5586))+(lerp(_node_2255.rgb,_node_2766.rgb,pow(node_5586,_RimRange))*_RimColor.rgb*_RimPower)+lerp((node_7499_if_leA*node_717)+(node_7499_if_leB*float4(0,0,0,1)),node_717,node_7499_if_leA*node_7499_if_leB))*node_2440)).rgb;
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,(node_2440*_OverallOpacity)),1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
