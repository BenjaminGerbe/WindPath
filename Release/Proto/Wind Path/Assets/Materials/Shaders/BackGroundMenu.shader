Shader "Custom/BackGroundMenu"
{
    Properties
    {
        _Color1 ("Couleur 1", color) = (1,1,1,1)
        _Color2 ("Couleur 2", color) = (1,1,1,1)
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
            };

            float4 _Color1;
            float4 _Color2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
             
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float val=  saturate( cos(((i.uv.x +  (_Time.w/250) )- (i.uv.y))*250)*10);
      

               
                

                val = smoothstep(0.5,0.6,val.x);

                float3 valcolor = lerp(_Color1,_Color2,val);
                
                return float4(valcolor.xyz,1);
            }
            ENDCG
        }
    }
}
