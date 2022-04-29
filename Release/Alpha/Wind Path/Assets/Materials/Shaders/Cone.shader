Shader "Unlit/Cone"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
            
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float3 targetPoint;

            v2f vert (appdata v)
            {
                v2f o;
                o.worldPos = mul(unity_ObjectToWorld,v.vertex);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                return o;
            }

            float angle(float2 a,float2 b)
            {
               float angle = acos(
                   (a.x * b.x + a.y * b.y) /
                   (sqrt( ( pow(a.x,2) + pow(a.y,2)) * sqrt(pow(b.x,2) +pow(b.y,2))) )
                   );

                return angle*180/UNITY_PI;
            }

            float GetDistance(float2 a,float2 b)
            {
                return sqrt( pow(a.x-b.x,2) + pow(a.y-b.y,2) );
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 forward = float2(0,1);
                float2 centeruv = i.uv - 0.5;
                
                float agl = angle(i.worldPos.xz,targetPoint.xz + float2(0,1));
                float distance = GetDistance(i.worldPos.xz,targetPoint.xz) < 10;
                float color = agl < 90 && distance ;

                
                return float4(color.xxx,1);
            }
            ENDCG
        }
    }
}
