using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc1 : MonoBehaviour
{
    private static sc1 instance;

    private Camera myCamera;
    private bool takeScreen;
    public int colorCount;


    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (takeScreen)
        {
            colorCount = 0;
            takeScreen = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

        
            for (int i = 0; i < 500; i++)
            {
                for (int k = 0; k < 500; k++)
                {
                    Color clll = renderResult.GetPixel(i, k);
                    if(clll.r == 1 && clll.g == 0 && clll.b == 0)
                    {
                        colorCount++;
                    }
                }
            }
          
          
            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenShot(int widt, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(widt, height, 16);
        {
            takeScreen = true;
        }
    }
    public static void TakeScreenShot_static(int width, int height)
    {
        instance.TakeScreenShot(width, height);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenShot_static(500, 500);
        }
    }
}
