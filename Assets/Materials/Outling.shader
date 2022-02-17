Shader "Custom/Outline" {
    Properties {        
        _MainTex ("Texture", 2D) = "white" {}
        //Диффузный
        _Diffuse ("Diffuse", Color) = (1,1,1,1)
        //Эффект обводки
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineScale ("Outline Scale", Range(0,1)) = 0.001
    }
    SubShader {
        //"Queue" = "Geometry+1000" + 1000, чтобы рендеринг скайбокса не перекрывал обводку в Game, или изменить значение на "Queue" = "Transparent"
        Tags { "Queue" = "Geometry+1000" "RenderType" = "Opaque" }
        LOD 100
        
        Pass
        {
            Name "Outline"
            ZWrite off
            Cull Front
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            float4 _OutlineColor;
            float _OutlineScale;

            struct v2f {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                v.vertex.xyz += v.normal * _OutlineScale;
                o.vertex = UnityObjectToClipPos(v.vertex);

                //Метод 2
                //float4 pos = mul(UNITY_MATRIX_V, mul(unity_ObjectToWorld, v.vertex));
                //float3 normal = normalize(mul((float3x3)UNITY_MATRIX_MV, v.normal));
                //pos += float4(normal, 0) * _OutlineScale;
                //o.vertex = mul(UNITY_MATRIX_P, pos);

                //Метод 3
                //o.vertex = UnityObjectToClipPos(v.vertex);
                //float3 viewNormal = normalize(mul((float3x3)UNITY_MATRIX_MV, v.normal));
                //float2 clipNormal = normalize(TransformViewToProjection(viewNormal.xy));
                //o.vertex.xy += clipNormal * _OutlineScale;
                return o;
            }

            fixed4 frag (v2f i): SV_Target{
                return _OutlineColor;
            }

            ENDCG
            }
        
        //Pass{
        //    CGPROGRAM
            
        //    #pragma vertex vert
        //    #pragma fragment frag

        //    #include "UnityCG.cginc"
        //    #include "Lighting.cginc"

        //    struct v2f {
        //        float4 vertex : SV_POSITION;
        //        float2 uv:TEXCOORD0;
        //        float3 worldNormal:TEXCOORD1;
        //        float3 worldPos:TEXCOORD2;
        //    };

        //    sampler2D _MainTex;
        //    float4 _MainTex_ST;
        //    float4 _Diffuse;

        //    v2f vert (appdata_base v)
        //    {
        //        v2f o;
        //        o.vertex = UnityObjectToClipPos(v.vertex);
        //        o.worldNormal = UnityObjectToWorldNormal(v.normal);
        //        o.worldPos = mul(unity_ObjectToWorld, v.vertex);
        //        o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
        //        return o;
        //    }

        //    fixed4 frag (v2f i): SV_Target
        //    {
        //        float3 ambient = UNITY_LIGHTMODEL_AMBIENT;
        //        fixed3 albedo = tex2D(_MainTex, i.uv).rgba;
        //        fixed3 worldLightDir = UnityWorldSpaceLightDir(i.worldPos);
        //        float halfLambert = dot(worldLightDir, i.worldNormal) * 0.5 + 0.5;
        //        fixed3 diffuse = _LightColor0.rgba * albedo * _Diffuse.rgba * halfLambert;

        //        return fixed4(ambient + diffuse, 1);
        //    }
            
        //ENDCG
        //}
    }
    FallBack "Diffuse"
}