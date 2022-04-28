Shader "Unlit/WaterShader"
{
    Properties
    {
        _DeppValue("Deep Value",float) = 0
        _DeepColor("DeepColor",color) = (0,0,0,0)
        _SurfaceColor("SurfaceColor",color) = (0,0,0,0)
        _FoamColor("Foam Color",color) = (0,0,0,0)
        _DepthValue("DepthValue",float) = 10
        _TraceTexture("TraceTexture",2D) = "white"
        _WaterDis("Water Distertion",2D) = "white"
        _MainTex("Main Texture",2D)="white"
        _Foam("Foamline Thickness", float) = 8
        _WaveSpeed("Wave Speed",float)=0
        _WaveAmont("Wave Amont",float)=0
        _WaveHeight("Wave Height",float)=0
        _FoamLineMaxDistance("Foam Line Max Distance",float) = 0.1
        _FoamLineMinDistance("Foam Line Min Distance",float) = 0.01


        

        
    }
    SubShader
    {
       Tags {"Queue"="Transparent" "RenderType"="Transparent"}
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
           CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
                float2 depth : TEXCOORD0;
                float4 screenuv :TEXCOORD1;
               float2 uv : TEXCOORD2;
               float3 vertex : TEXCOORD3;
               float3 normals : NORMAL;
               float3 worldPos : TEXCOORD4;
            };

            float _WaveSpeed;
            float _WaveAmont;
            float _WaveHeight;
            uniform float3 _Position;
            uniform  sampler2D _GlobalEffectRT;
            uniform float _OrtographicCamSize;
            float unityTime;

            float GetWaterHeight(float3 pos)
            {
                float func = unityTime.x *_WaveSpeed + (pos.x* pos.z*_WaveAmont);
                float height = _WaveHeight * sin(func);
                
                return height;
            }

           
            v2f vert (appdata_full v) {

                v2f o;
                float3 worldpos = mul(UNITY_MATRIX_M, v.vertex);
                v.vertex.y += sin(unityTime.x*_WaveSpeed + (worldpos.x* worldpos.z*_WaveAmont)) *_WaveHeight;
               
          
                v.vertex.y += GetWaterHeight(worldpos);
                o.vertex = v.vertex;
                
                o.pos = UnityObjectToClipPos(v.vertex);
                o.screenuv = ComputeScreenPos(o.pos);
                o.uv = v.texcoord;
                o.normals = COMPUTE_VIEW_NORMAL;
              
         
                
                return o;
            }
            sampler2D _CameraDepthTexture;
           sampler2D _CameraNormalsTexture;
           sampler2D _TraceTexture;
           sampler2D _MainTex;
           float4 _MainTex_ST;
           float4 _DeepColor;
           float4 _SurfaceColor;
           float _DepthValue;
            sampler2D _WaterDis;
           float4 _WaterDis_ST;
           float _Foam;
          float _FoamCOF;
           float4 _FoamColor;
           float _DeppValue;
           float _FoamLineMaxDistance;
           float _FoamLineMinDistance;
     
   
            half4 frag(v2f i) : SV_Target {
/*
                float3 trace = tex2D(_TraceTexture,i.uv.xy);
                float3 mainTex = tex2D(_MainTex,i.uv.xy * _MainTex_ST.xy + _MainTex_ST.zw);
            
                float2 uv = i.screenuv.xy / i.screenuv.w;
                half depth =  LinearEyeDepth(SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenuv)));
        
                
                float4 col = lerp(_DeepColor,_SurfaceColor, saturate(depth.x*4));
                float4 foamLine = 1  - saturate( _Foam * (depth-i.screenuv.w));
              //  col = lerp(col,(trace,1),trace.x);
                half foamline = 1 - saturate(_Foam * (depth - i.screenuv.w));
                foamline = step(0.5,foamline);
                
                
                col +=  foamline* _FoamColor;
                col +=  float4(depth.xxx,0);
                */


            

                float Depth01 = tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenuv)).x;
                float3 normals = tex2Dproj(_CameraNormalsTexture, UNITY_PROJ_COORD(i.screenuv));
               float4 trace3 = tex2D(_TraceTexture, i.uv ).b;
                

                
                float3 dis = tex2D(_WaterDis, i.uv * _WaterDis_ST.xy + _WaterDis_ST.zw + float2(1,1)*_Time.x);
                float3 tex = tex2D(_MainTex, i.uv * _MainTex_ST.xy + _MainTex_ST.zw + (dis.x - dis.y + (trace3.x)*2)/20 );
           
             
                float4 trace = tex2D(_TraceTexture, i.uv + (dis.x - dis.y)/500 ).b;
                
                float3 normalDot = saturate(dot(i.normals,normals));
                
                
                float Scenedepth = LinearEyeDepth(Depth01);
                float depth = saturate((Scenedepth - i.screenuv.w) / _DeppValue);

                float _Foam = lerp(_FoamLineMinDistance,_FoamLineMaxDistance,normalDot);

                
                float foamline =1- step(0.5, saturate( depth /_Foam));


                
                trace = step(0.5,trace);
                float4 col = float4(0,0,0,0) ;
                tex = step(0.5,tex);
                float v = tex + trace ;
                float4 tex2 = lerp(_SurfaceColor,_DeepColor,tex.x);
                
                col = lerp(tex2,_DeepColor,col.x);
                
                col += (foamline.x * _FoamColor) ;
                
                trace = float4(trace.xxx,0) * _FoamColor;
                col += trace;
                
                
                return col;
            }
            ENDCG
        }
    }
}
