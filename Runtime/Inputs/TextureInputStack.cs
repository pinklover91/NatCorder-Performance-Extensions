/* 
*   NatCorder Performance Extensions
*   Copyright (c) 2021 Yusuf Olokoba.
*/

namespace NatSuite.Recorders.Inputs {

    using UnityEngine;

    public sealed class TextureInputStack : ITextureInput { // INCOMPLETE

        #region --Client API--
        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        public TextureInputStack (params ITextureInput[] inputs) { // Null is ok

        }

        /// <summary>
        /// Commit a video frame from a texture.
        /// </summary>
        /// <param name="texture">Source texture.</param>
        /// <param name="timestamp">Frame timestamp in nanoseconds.</param>
        public void CommitFrame (Texture texture, long timestamp) {

        }

        /// <summary>
        /// </summary>
        public void Dispose () {

        }
        #endregion


        #region --Operations--

        #endregion
    }
}