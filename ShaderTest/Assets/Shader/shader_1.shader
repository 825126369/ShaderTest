// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "xuke/shader_1"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			struct vertexInput
			{
				float4 aaa : POSITION;
				float3 bbb : NORMAL;
				float4 ccc : TEXCOORD0;
			};

			struct v2f
			{
				float4 aaa :  SV_POSITION;
				fixed3 bbb : COLOR0;
			};

//			float4 vert(float4 v: POSITION) : SV_POSITION
//			{
//				return mul (UNITY_MATRIX_MVP, v);
//			}

//			float4 vert(vertexInput v) : SV_POSITION
//			{
//				return mul (UNITY_MATRIX_MVP, v.aaa);
//			}

			v2f vert(vertexInput v)
			{
				v2f o;
				o.aaa = UnityObjectToClipPos (v.aaa);
				o.bbb = fixed3(0,0,0);
				return o;
			}

//			fixed4 frag() : SV_Target
//			{
//				return fixed4(1.0, 1.0, 1.0, 1.0);
//			}

			fixed4 frag(v2f i) : SV_Target
			{
				return fixed4(i.bbb, 1.0);
			}

			ENDCG
		}
	}
}
