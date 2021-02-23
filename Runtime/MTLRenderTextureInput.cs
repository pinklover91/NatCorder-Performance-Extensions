/* 
*   NatCorder Performance Extensions
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Recorders.Inputs {

    using UnityEngine;
    using Rendering;

    /// <summary>
    /// Recorder input for recording video frames from RenderTexture's with hardware acceleration on iOS Metal.
    /// </summary>
    public class MTLRenderTextureInput : RenderTextureInput { // DEPLOY

        #region --Client API--
        /// <summary>
        /// Create a Metal RenderTexture input.
        /// </summary>
        /// <param name="recorder">Media recorder to receive video frames.</param>
        /// <param name="multithreading">Enable multithreading. This improves recording performance.</param>
        public MTLRenderTextureInput (IMediaRecorder recorder, bool multithreading = false) : base(recorder) => this.readback = new MTLReadback(
            recorder.frameSize.width,
            recorder.frameSize.height,
            multithreading
        );

        /// <summary>
        /// Commit a video frame from a RenderTexture.
        /// </summary>
        /// <param name="renderTexture">Source RenderTexture.</param>
        /// <param name="timestamp">Frame timestamp in nanoseconds.</param>
        public override void CommitFrame (RenderTexture renderTexture, long timestamp) => readback.Request<byte>(renderTexture, buffer => CommitFrame(buffer, timestamp));

        /// <summary>
        /// Stop recorder input and release resources.
        /// </summary>
        public override void Dispose () {
            readback.Dispose();
            base.Dispose();
        }
        #endregion


        #region --Operations--

        private readonly MTLReadback readback;
        #endregion
    }
}