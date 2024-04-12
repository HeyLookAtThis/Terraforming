Shader "Custom/CoinShander"
{
    Properties
    {
        _EmissiveColor ("Emissive Color", Color) = (1,1,1,1)
        _AmbientColor ("Ambient Color", Color) = (1,1,1,1)
        _MixingValue ("Mixing Value", Range(0,10)) = 2.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BasicDiffuse

        float4 _EmissiveColor;
        float4 _AmbientColor;
        float _MixingValue;

        struct Input
        {
            float2 uv_MainTex;            
        };

        inline float4 LightingBasicDiffuse (SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            float difLight = max(0, dot(s.Normal, lightDir));
            float4 col;
            col.rgb = s.Albedo * _LightColor0.rgb * (difLight * atten * 2);
            col.a = s.Alpha;
            return col;            
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            float4 c;
            c = pow((_EmissiveColor + _AmbientColor), _MixingValue);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
