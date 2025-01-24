Shader "Custom/Jelly"
{
    Properties
    {
        _Color ("Base Color", Color) = (0.5, 0.5, 1, 1)
        _WobbleSpeed ("Wobble Speed", Float) = 1
        _WobbleStrength ("Wobble Strength", Float) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            float _WobbleSpeed;
            float _WobbleStrength;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.normal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float time = _Time.y * _WobbleSpeed;

                // Wobble calculation
                float wobbleX = sin(i.worldPos.x * 2.0 + time) * _WobbleStrength;
                float wobbleZ = sin(i.worldPos.z * 2.0 + time) * _WobbleStrength;

                // Adjust normals
                float3 wobbleNormal = normalize(float3(wobbleX, 1.0, wobbleZ));

                // Basic shading
                float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                float diff = max(0.0, dot(wobbleNormal, lightDir));
                fixed4 col = _Color * diff;

                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
