Shader "Custom/Water"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _BumpIntensity ("Notmal Map Intensity", Range(0,2)) = 1
        _TransVal ("Transparency Value", Range(0,1)) = 0.5
        _ScrollXSpeed ("X Scroll Speed", Range(0, 10)) = 2
        _ScrollYSpeed ("Y Scroll Speed", Range(0, 10)) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha
        #pragma target 3.0

        sampler2D _BumpMap;
        sampler2D _MainTex;
        fixed _ScrollXSpeed;
        fixed _ScrollYSpeed;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };

        float _BumpIntensity;
        float _TransVal;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed2 scrolledUV = IN.uv_MainTex;
            fixed xScrollValue = _ScrollXSpeed * _Time.x;
            fixed yScrollValue = _ScrollYSpeed * _Time.x;
            scrolledUV += fixed2(xScrollValue, yScrollValue);

            float4 color = tex2D(_MainTex, scrolledUV);
            float3 normalMap = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            normalMap = float3(normalMap.x * _BumpIntensity, normalMap.y * _BumpIntensity, normalMap.z);

            o.Normal = normalMap.rgb;
            o.Albedo = color.rgb * _Color;
            o.Alpha = _Color.a * _TransVal;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
