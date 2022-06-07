using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(Coroti());
    }
    private IEnumerator Coroti()
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;
        Texture2D screenshot = new Texture2D(width, height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, width, height);
        screenshot.ReadPixels(rect, 0, 0);
        screenshot.Apply();

        byte[] byteArray = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/CameraSc.png", byteArray);
    }
}
