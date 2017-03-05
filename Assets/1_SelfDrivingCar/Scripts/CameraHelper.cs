using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public static class CameraHelper
{
    //const int k_OutputImageWidth = 1920;
    //const int k_OutputImageHeight = 1200;

  public static byte[] CaptureFrame(Camera camera)
  {
    //RenderTexture targetTexture = new RenderTexture(k_OutputImageWidth, k_OutputImageHeight, 24);
    //camera.targetTexture = targetTexture;
    //camera.Render();
    RenderTexture targetTexture = camera.targetTexture;
    RenderTexture.active = targetTexture;
	Texture2D texture2D = new Texture2D(targetTexture.width, targetTexture.height, TextureFormat.RGB24, false);
	texture2D.ReadPixels(new Rect(0, 0, targetTexture.width, targetTexture.height), 0, 0);
    texture2D.Apply();
	byte[] image = texture2D.EncodeToJPG();	
	Object.DestroyImmediate(texture2D); // Required to prevent leaking the texture
    return image;
  }
}
