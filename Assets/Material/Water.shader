// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Water"
{
    Properties
    {
        _Color ("Color", Color) = (0,0.2538895,0.75,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
       _BumpTex ("Normal Map", 2D) = "white" {}
        _MainLightPosition("MainLightPosition", Vector) = (0,0,0,0)
        _Cube("CubeMap", cube) = ""{}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf _CatDarkLight //alpha:blend
        // Physically based Standard lighting model, and enable shadows on all light types
        //#pragma surface surf Standard fullforwardshadows
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpTex;
        samplerCUBE _Cube;
        
        struct Input
        {
           float2 uv_MainTex;
            float2 uv_BumpTex;
            float3 worldRefl;
            float3 viewDir;
            INTERNAL_DATA
        
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)
/*
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;

        }
        */
         void surf(Input IN, inout SurfaceOutput o)
        {     
             fixed4 c=tex2D(_MainTex,IN.uv_MainTex);
             
            float n1=UnpackNormal(tex2D(_BumpTex,IN.uv_BumpTex+_Time.y*0.03));
            float n2=UnpackNormal(tex2D(_BumpTex,IN.uv_BumpTex-_Time.y*0.01));
            o.Normal=(n1+n2)*0.5;
            o.Normal*=float3(0.5,0.5,1);
//            float3 viewDir=WorldSpaceViewDir(v.vertex);
            float3 fWorldReflectionVector =reflect(IN.viewDir, o.Normal).xzy;
            float4 fCube=texCUBE(_Cube,fWorldReflectionVector);
            //float4 fCube=texCUBE(_Cube,WorldReflectionVector(IN,o.Normal)).rgb.b*_Color;
            //float3 fWorldReflectionVector =reflect(IN.viewDir, o.Normal);
            //float3 fWorldReflectionVector = WorldReflectionVector(IN, o.Normal).xyz;   
            o.Emission=fCube.rgb* unity_SpecCube0_HDR.r*_Color; ;
            //o.Emission = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, fWorldReflectionVector).rgb * unity_SpecCube0_HDR.r*_Color;        //! Reflection Probe데이터 읽어서 Emission에 출력
           // o.Emission = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, WorldReflectionVector(IN,o.Normal)).rgb * unity_SpecCube0_HDR.r*1.05;
            o.Alpha = c.a;
        }
 
        float4 Lighting_CatDarkLight(SurfaceOutput s, float3 lightDir, float3 viewDir, float atten)        //! Custom Light함수는 당장 아무것도 안함
        {
            float rim=saturate(dot(s.Normal,viewDir));
            rim=pow(1-rim,3);
            float4 fFinalColor = rim*0.1;
            return fFinalColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
