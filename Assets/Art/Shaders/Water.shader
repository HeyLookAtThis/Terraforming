Shader "Custom/Water"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _BumpIntensity ("Notmal Map Intensity", Range(0,2)) = 1
        _TransVal ("Transparency Value", Range(0,1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha
        #pragma target 3.0

        sampler2D _BumpMap;

        struct Input
        {
            float2 uv_BumpMap;
        };

        float _BumpIntensity;
        float _TransVal;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            float3 normalMap = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            normalMap = float3(normalMap.x * _BumpIntensity, normalMap.y * _BumpIntensity, normalMap.z);

            o.Normal = normalMap.rgb;
            o.Albedo = _Color.rgb;
            o.Alpha = _Color.a * _TransVal;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
