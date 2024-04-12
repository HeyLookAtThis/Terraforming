Shader "Custom/Volcano"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _CutoffTex("Cutoff Texture", 2D) = "white" {}
        _CutoffValue("Cutoff Value", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alphatest:_CutoffValue
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _CutoffTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_CutoffTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 d = tex2D (_CutoffTex, IN.uv_CutoffTex);
            o.Albedo = c.rgb;
            o.Alpha = d.r;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
