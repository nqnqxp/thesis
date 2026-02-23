using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.RenderGraphModule;

namespace PSX
{
    public class DitheringRenderFeature : ScriptableRendererFeature
    {
        DitheringPass ditheringPass;

        public override void Create()
        {
            ditheringPass = new DitheringPass();
            ditheringPass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(ditheringPass);
        }

        protected override void Dispose(bool disposing)
        {
            ditheringPass?.Dispose();
        }
    }

    public class DitheringPass : ScriptableRenderPass
    {
        private Material m_Material;
        private static readonly string k_ShaderPath = "PostEffect/Dithering";
        
        // Property IDs
        private static readonly int k_PatternIndex = Shader.PropertyToID("_PatternIndex");
        private static readonly int k_DitherThreshold = Shader.PropertyToID("_DitherThreshold");
        private static readonly int k_DitherStrength = Shader.PropertyToID("_DitherStrength");
        private static readonly int k_DitherScale = Shader.PropertyToID("_DitherScale");

        public DitheringPass()
        {
            var shader = Shader.Find(k_ShaderPath);
            if (shader != null) m_Material = CoreUtils.CreateEngineMaterial(shader);
        }

        private class PassData
        {
            public TextureHandle source;
            public Material material;
            public Dithering settings;
        }

        public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
        {
            if (m_Material == null) return;

            UniversalResourceData resourceData = frameData.Get<UniversalResourceData>();
            UniversalCameraData cameraData = frameData.Get<UniversalCameraData>();

            var stack = VolumeManager.instance.stack;
            var dithering = stack.GetComponent<Dithering>();
            if (dithering == null || !dithering.IsActive() || !cameraData.postProcessEnabled) return;

            TextureHandle source = resourceData.activeColorTexture;

            RenderTextureDescriptor desc = cameraData.cameraTargetDescriptor;
            desc.depthBufferBits = 0; 
            TextureHandle destination = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "_DitherTemp", true);

            using (var builder = renderGraph.AddRasterRenderPass<PassData>("Dithering Pass", out var passData))
            {
                passData.source = source;
                passData.material = m_Material;
                passData.settings = dithering;

                builder.UseTexture(source, AccessFlags.Read);
                builder.SetRenderAttachment(destination, 0, AccessFlags.Write);

                builder.SetRenderFunc((PassData data, RasterGraphContext context) =>
                {
                    data.material.SetInt(k_PatternIndex, data.settings.patternIndex.value);
                    data.material.SetFloat(k_DitherThreshold, data.settings.ditherThreshold.value);
                    data.material.SetFloat(k_DitherStrength, data.settings.ditherStrength.value);
                    data.material.SetFloat(k_DitherScale, data.settings.ditherScale.value);

                    Blitter.BlitTexture(context.cmd, data.source, new Vector4(1, 1, 0, 0), data.material, 0);
                });
            }

            resourceData.cameraColor = destination;
            //resourceData.activeColorTexture = destination;
        }

        public void Dispose() => CoreUtils.Destroy(m_Material);
    }
}

