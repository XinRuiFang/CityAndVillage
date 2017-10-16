sampler s0;
texture lightMask;
sampler lightSampler = sampler_state
{ 
Texture = lightMask; 
MinFilter = Linear;
MagFilter = Linear;
MipFilter = Linear;

AddressU = Clamp;
AddressV = Clamp;
};

float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{

    // TODO: add your pixel shader code here.
	float4 color = tex2D(s0, coords);
	float4 lightColor = tex2D(lightSampler, coords);
	return color * lightColor;
}

technique Technique1
{
    pass Pass1
    {
        // TODO: set renderstates here.
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}

