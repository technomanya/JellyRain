Shader "Custom/JellyCube"
{
    Properties
    {
        _Color ("Base Color", Color) = (0.5, 0.5, 1, 1)
        _WobbleSpeed ("Wobble Speed", Float) = 1
        _WobbleStrength ("Wobble Strength", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        #include "UnityCG.cginc"

        struct Input
        {
            float3 worldPos;
        };

        float _WobbleSpeed;
        float _WobbleStrength;
        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Get time
            float time = _Time.y * _WobbleSpeed;

            // Calculate wobble effect
            float wobbleX = sin(IN.worldPos.x * 2.0 + time) * _WobbleStrength;
            float wobbleZ = sin(IN.worldPos.z * 2.0 + time) * _WobbleStrength;

            // Apply wobble to normal
            o.Normal = normalize(float3(wobbleX, 1.0, wobbleZ));

            // Set surface properties
            o.Albedo = _Color.rgb;
            o.Metallic = 0.0;
            o.Smoothness = 0.8;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
