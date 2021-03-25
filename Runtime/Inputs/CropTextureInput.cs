/* 
*   NatCorder Performance Extensions
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Recorders.Inputs {

    using UnityEngine;

    /// <summary>
    /// Recorder input for recording video frames from textures with cropping.
    /// </summary>
    public sealed class CropTextureInput : ITextureInput {

        #region --Client API--
        /// <summary>
        /// Crop rect in pixel coordinates of the recorder.
        /// </summary>
        public RectInt cropRect;

        /// <summary>
        /// Crop aspect mode.
        /// </summary>
        public AspectMode aspectMode;

        /// <summary>
        /// Create a crop texture input.
        /// </summary>
        /// <param name="recorder">Media recorder to receive video frames.</param>
        /// <param name="textureInput">Backing texture input for committing frames to recorder.</param>
        public CropTextureInput (IMediaRecorder recorder, ITextureInput textureInput = null) {
            this.recorder = recorder;
            this.input = textureInput ?? new TextureInput(recorder);
            this.material = new Material(Shader.Find(@"Hidden/NCPX/CropTextureInput"));
            this.cropRect = new RectInt(0, 0, recorder.frameSize.width, recorder.frameSize.height);
            this.aspectMode = 0;
        }

        /// <summary>
        /// Commit a video frame from a texture.
        /// </summary>
        /// <param name="texture">Source texture.</param>
        /// <param name="timestamp">Frame timestamp in nanoseconds.</param>
        public void CommitFrame (Texture texture, long timestamp) {
            // Create temp RT
            var (width, height) = recorder.frameSize;
            var renderTexture = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
            // Blit
            Graphics.Blit(texture, renderTexture, material);
            // Commit
            input.CommitFrame(renderTexture, timestamp);
            RenderTexture.ReleaseTemporary(renderTexture);
        }

        /// <summary>
        /// Stop recorder input and release resources.
        /// </summary>
        public void Dispose () {
            input.Dispose();
            Material.Destroy(material);
        }
        #endregion


        #region --Operations--
        private readonly IMediaRecorder recorder;
        private readonly ITextureInput input;
        private readonly Material material;
        #endregion
    }
}