/* 
*   NatCorder Performance Extensions
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Recorders.Inputs {

    using UnityEngine;

    /// <summary>
    /// Recorder input for recording video frames from RenderTexture's with a watermark.
    /// </summary>
    public sealed class WatermarkRenderTextureInput : RenderTextureInput { // INCOMPLETE
        
        #region --Client API--
        /// <summary>
        /// Watermark image.
        /// </summary>
        public Texture watermark;

        /// <summary>
        /// Watermark display rect in pixel coordinates of the recorder.
        /// </summary>
        public RectInt displayRect;

        /// <summary>
        /// Watermark aspect mode.
        /// </summary>
        public AspectMode aspectMode;

        /// <summary>
        /// Create a watermark render texture input.
        /// </summary>
        /// <param name="recorder">Media recorder to receive video frames.</param>
        /// <param name="frameInput">Frame input for committing frames to recorder.</param>
        public WatermarkRenderTextureInput (IMediaRecorder recorder, RenderTextureInput frameInput = null) : base(recorder) {
            this.frameInput = frameInput ?? CreateDefault(recorder);
            this.displayRect = new RectInt(0, 0, recorder.frameSize.width, recorder.frameSize.height);
            this.aspectMode = 0;
        }

        /// <summary>
        /// Commit a video frame from a RenderTexture.
        /// </summary>
        /// <param name="renderTexture">Source RenderTexture.</param>
        /// <param name="timestamp">Frame timestamp in nanoseconds.</param>
        public override void CommitFrame (RenderTexture renderTexture, long timestamp) {

        }

        /// <summary>
        /// Stop recorder input and release resources.
        /// </summary>
        public override void Dispose () {
            frameInput.Dispose();
            base.Dispose();
        }
        #endregion


        #region --Operations--

        private readonly RenderTextureInput frameInput;
        #endregion
    }
}