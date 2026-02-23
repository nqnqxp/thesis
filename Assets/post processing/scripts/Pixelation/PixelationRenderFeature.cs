using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;

namespace PSX
{
    public class PixelationRenderFeature : ScriptableRendererFeature
    {
        PixelationPass pixelationPass;

        public override void Create()
        {
            pixelationPass = new PixelationPass();
            pixelationPass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(pixelationPass);
        }

        protected override void Dispose(bool disposing)
        {
            pixelationPass?.Dispose();
        }
    }

    public class PixelationPass : ScriptableRenderPass
    {
        private Material m_Material;
        private static readonly string k_ShaderPath = "PostEffect/Pixelation";
        
        // Shader Property IDs
        private static readonly int k_WidthPixelation = Shader.PropertyToID("_WidthPixelation");
        private static readonly int k_HeightPixelation = Shader.PropertyToID("_HeightPixelation");
        private static readonly int k_ColorPrecision = Shader.PropertyToID("_ColorPrecision");

        public PixelationPass()
        {
            var shader = Shader.Find(k_ShaderPath);
            if (shader != null)
                m_Material = CoreUtils.CreateEngineMaterial(shader);
        }

        // Data class for the Render Graph
        private class PassData
        {
            public TextureHandle source;
            public Material material;
            public Pixelation settings;
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            if (m_Material == null) return;

            // Fetch URP resources
            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
            UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();

            if (!cameraData.postProcessEnabled) return;

            // Get Volume component
            var stack = VolumeManager.instance.stack;
            var pixelation = stack.GetComponent<Pixelation>();

            if (pixelation == null || !pixelation.IsActive()) return;

            // 1. Get current camera texture
            TextureHandle cameraColor = resourceData.activeColorTexture;

            // 2. Setup temporary texture descriptor
            RenderTextureDescriptor desc = cameraData.cameraTargetDescriptor;
            desc.depthBufferBits = 0; // Post-effects don't need depth buffer
            
            // Create the temp texture
            TextureHandle destination = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_TempTargetPixelation", true);

            // 3. Record the Pass
            using (var builder = renderGraph.AddRasterRenderPass<PassData>("Pixelation Pass", out var passData))
            {
                passData.source = cameraColor;
                passData.material = m_Material;
                passData.settings = pixelation;

                builder.UseTexture(passData.source, AccessFlags.Read);
                builder.SetRenderAttachment(destination, 0, AccessFlags.Write);

                builder.SetRenderFunc((PassData data, RasterGraphContext context) =>
                {
                    data.material.SetFloat(k_WidthPixelation, data.settings.widthPixelation.value);
                    data.material.SetFloat(k_HeightPixelation, data.settings.heightPixelation.value);
                    data.material.SetFloat(k_ColorPrecision, data.settings.colorPrecision.value);

                    // Blitter binds data.source to _BlitTexture in your shader
                    Blitter.BlitTexture(context.cmd, data.source, new Vector4(1, 1, 0, 0), data.material, 0);
                });
            }

            // 4. CRITICAL: Pass the "new" pixelated texture forward to the rest of the pipeline
            resourceData.cameraColor = destination;
        }

        public void Dispose()
        {
            CoreUtils.Destroy(m_Material);
        }
    }
}