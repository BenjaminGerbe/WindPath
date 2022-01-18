Shader "Unlit/WaterShader"
{
    Properties
    {
        _Color("Color",Color) = (0,0,0)
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 screenuv : TEXCOORD3;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float3 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                      UNITY_TRANSFER_DEPTH(o.depth);

                o.screenuv = ComputeScreenPos(o.vertex);
                return o;
            }
   
            sampler2D _CameraDepthTexture;
           
            
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv *_MainTex_ST.xy + _MainTex_ST.zw);

                 float3 output = lerp(_Color,1,col.x);
                
                UNITY_APPLY_FOG(i.fogCoord, col);
                return float4(output.xyz,0);
            }
            ENDCG
        }
    }
}
