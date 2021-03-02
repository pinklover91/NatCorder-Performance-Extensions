# NatCorder Performance Extensions
Performance extensions for video recording in Unity Engine.

## Setup Instructions
To install the library, add the following to your project's `manifest.json` file in the `Packages` folder:
```json
{
  "dependencies": {
    "com.natsuite.natrender": "git+https://github.com/natsuite/NatRender",
    "com.natsuite.ncpx": "git+https://github.com/natsuite/NatCorder-Performance-Extensions"
  }
}
```

## High Performance Recording
NCPX provides highly optimized recorder inputs that offer inexpensive [pixel buffer readbacks](https://docs.natsuite.io/natcorder/workflows/recording-rendertextures) from `RenderTexture`s, and offer [multithreaded recording](https://docs.natsuite.io/natcorder/workflows/performance-considerations#multithreaded-recording).

They can be used independently, or attached to a `CameraInput` when recording game cameras:
```csharp
// Create recorder and recording clock
var recorder = ...;
var clock = ...;
// Create a camera input
var cameraInput = new CameraInput(recorder, clock, cameras);
// Attach optimized frame input from NCPX to the camera input
cameraInput.frameInput = new GLESRenderTextureInput(recorder, multithreading: true);
```

NCPX provides `GLESRenderTextureInput` for OpenGLES 3 on Android and `MTLRenderTextureInput` for Metal on iOS.

## Watermark Recording
*INCOMPLETE*

## Cropped Recording
*INCOMPLETE*

## Recording in WebGL
*INCOMPLETE*

## Recording to a Specific File
*INCOMPLETE*

___

## Requirements
- Unity 2019.2+
- NatCorder 1.8.0+

## Resources
- [NatCorder Documentation](https://docs.natsuite.io/natcorder)
- [NatSuite Framework](https://github.com/natsuite)
- [Email Support](mailto:yusuf@natsuite.io)

Thank you very much!