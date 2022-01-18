Shader "Unlit/DepthBoat"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Geometry + 100" }
        ColorMask 0
        Zwrite On

        Pass
        {
           
        }
    }
}
