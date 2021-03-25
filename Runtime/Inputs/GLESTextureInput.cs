/* 
*   NatCorder Performance Extensions
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Recorders.Inputs {

    using UnityEngine;
    using Unity.Collections.LowLevel.Unsafe;
    using Rendering;

    /// <summary>
    /// Recorder input for recording video frames from textures with hardware acceleration on Android OpenGL ES.
    /// </summary>
    public sealed class GLESTextureInput : ITextureInput {

        #region --Client API--
        /// <summary>
        /// Create a GLES texture input.
        /// </summary>
        /// <param name="recorder">Media recorder to receive video frames.</param>
        /// <param name="multithreading">Enable multithreading. This improves recording performance.</param>
        public GLESTextureInput (IMediaRecorder recorder, bool multithreading = false) {
            this.recorder = recorder;
            this.readback = new GLESReadback(recorder.frameSize.width, recorder.frameSize.height, multithreading);
        }

        /// <summary>
        /// Commit a video frame from a texture.
        /// </summary>
        /// <param name="texture">Source texture.</param>
        /// <param name="timestamp">Frame timestamp in nanoseconds.</param>
        public unsafe void CommitFrame (Texture texture, long timestamp) {
            readback.Request(texture, pixelBuffer => recorder?.CommitFrame(
                NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(pixelBuffer),
                timestamp
            ));
        }

        /// <summary>
        /// Stop recorder input and release resources.
        /// </summary>
        public void Dispose () {
            recorder = default;
            readback.Dispose();
        }
        #endregion


        #region --Operations--

        private IMediaRecorder recorder;
        private readonly GLESReadback readback;
        #endregion
    }
}