Shader "Custom/ArrowShader"
{
    Properties
    {
        _ColorMin ("colorMin", color) = (1,1,1,1)
        _ColorMax ("colorMax", color) = (1,1,1,1)
        _Threshold("Threshold",float)=0
    }
    SubShader
    {
        Tags { "RenderType"="GeometryLast" }
        
        
        
        Pass
        {
            
            Zwrite On
            
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float3 _ColorMin;
            float3 _ColorMax;
            float _Threshold;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float v =  saturate( i.uv.y + _Threshold);
                float3 color = lerp(_ColorMin,_ColorMax,v);
                
                return float4(color,1);
            }
            ENDCG
        }
    }
}
