Shader "Unlit/SkyBox_Shader"
{
    Properties
    {
        _BottomColor ("BottomColor", color) = (0,0,0)
        _TopColor ("BottomColor", color) = (0,0,0)
        _Threshold("Threshold",float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Backgrond" "Queue"="Background" }
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

         

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
             
                return o;
            }
            float3 _BottomColor;
            float3 _TopColor;
            float _Threshold;
            
            fixed4 frag (v2f i) : SV_Target
            {
                float value = clamp(i.uv.y + _Threshold,0,1);
                float3 col = lerp(_BottomColor,_TopColor,value);
                
                return float4(col.xyz,0);
            }
            ENDCG
        }
    }
}
