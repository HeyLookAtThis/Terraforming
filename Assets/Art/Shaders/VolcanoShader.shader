Shader "Custom/VolcanoShader"
{
    Properties
    {
        _MainColor("Main Color", Color) = (1.0,1.0,1.0,1.0)
        _MainTex("Base (RGB)", 2D) = "white" {}
        _Bump("Bump", 2D) = "bump" {}
        _Snow("Level of snow", Range(1, 0)) = 1
        _SnowColor("Color of snow", Color) = (1.0,1.0,1.0,1.0)
        _SnowDirection("Direction of snow", Vector) = (0,1,0)
        _SnowDepth("Depth of snow", Range(0,1)) = 0
        _TransVal ("Transparency Value", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf BlinnPhong alpha vertex:vert

        #pragma target 3.0

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_Bump;
            float3 worldNormal;
            INTERNAL_DATA
        };

        sampler2D _MainTex;
        sampler2D _Bump;
        float _Snow;
        float4 _SnowColor;
        float4 _MainColor;
        float4 _SnowDirection;
        float _SnowDepth;
        float _TransVal;


        void surf (Input IN, inout SurfaceOutput o)
        {
            half4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));

            if (dot(WorldNormalVector(IN, o.Normal), _SnowDirection.xyz) >= _Snow)
                o.Albedo = _SnowColor.rgb;
            else
                o.Albedo = c.rgb * _MainColor;

            o.Alpha = _TransVal;
        }

        void vert(inout appdata_full v) 
        {
            float4 sn = mul(UNITY_MATRIX_IT_MV, _SnowDirection);

            if (dot(v.normal, sn.xyz) >= _Snow)
                v.vertex.xyz += (sn.xyz + v.normal) * _SnowDepth * _Snow;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
