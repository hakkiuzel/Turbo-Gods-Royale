//---------------------------------------------------------------
//        Writed by ALIyerEdon in summer 2016
//          surface shader - shader model 2
//---------------------------------------------------------------

	Shader "MobilePro/Water/Mobile_Water_Color_Aplha" 
	{
	Properties
	 {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_SpecPower("Specular Power",Float) = 2
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SpecTex ("Specular Texture", 2D) = "white" {}
		_Cube ("Cubemap", 2D) = "" {}
		_CubePower("CubePower",Float) = 3
		_WaveHeight("Wave Height",Float) = .07
		_WaveSpeed("Wave Speed",Float) = 14
		_WaveCount("Wave Count",Float) = 30
		_AlphaPower("Water Alpha",Float) = 1.4

	}

SubShader {

		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}


		CGPROGRAM

		// BlinnPhong lighting model for specular setup  -  vertex:vert is for wave animation
		#pragma surface surf BlinnPhong vertex:vert alpha:fade

		// Shader Model 2 for mobile platforms(OpenGL ES2)
		#pragma target 2.0

		sampler2D _MainTex;
		sampler2D _SpecTex;
		float _Shininess;
		sampler2D _Cube;
		float _CubePower;
		half4 _Color;

		float _WaveHeight;
		float _WaveSpeed;
		float _WaveCount;
		float _AlphaPower;
		float _SpecPower;

		struct Input {
			float2 uv_MainTex;
			float2 uv_SpecTex;

			// This if for cubemap world view direction
			float3 worldRefl;


			half3 vDir : TEXCOORD2;
		};


		// This vertex function is for wave animation system
		void vert (inout appdata_full v, out Input o){   
		UNITY_INITIALIZE_OUTPUT(Input,o);
		    float phase = _Time * _WaveSpeed;
		    float offset = (v.vertex.x * (v.vertex.z * 0.2)) * _WaveCount;
		    v.vertex.y = sin(phase + offset) * _WaveHeight;

		     o.vDir = normalize( ObjSpaceViewDir(v.vertex) ).xzy;
		}

		// This is main pixel shader function for final result
		void surf (Input IN, inout SurfaceOutput o) {
			
			half4 tex = tex2D(_MainTex, IN.uv_MainTex);
			half4 s_tex = tex2D(_SpecTex, IN.uv_SpecTex);

			half2 worldRefl = WorldReflectionVector (IN, o.normal);
			half2 R = IN.vDir - ( 2 * dot(IN.vDir, o.Normal )) * o.Normal;
		    half4 reflcol = tex2D (_Cube, R);

			o.Albedo = tex.rgb *_Color.rgb*4;
			o.Alpha = reflcol.rgb*_AlphaPower;
			o.Gloss = s_tex.rgb*tex.a*_SpecPower;

			o.Specular = s_tex.rgb*_Shininess;   

			o.Emission = (reflcol.rgb*_CubePower)*s_tex.rgb;

		}

		ENDCG   
	}

	Fallback "Diffuse"
}
