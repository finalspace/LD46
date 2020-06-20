using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplatScreenCamera : SingletonBehaviour<SplatScreenCamera> {
    public Camera cam;
    public Material processingImageMaterial;

    private RenderTexture myRenderTexture;
    public RenderTexture targetRenderTexture;

    protected override void Awake()
    {
        base.Awake();
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        //just in case
        if (SplatScreenController.Instance == null)
            Destroy(this);
    }

    public void Init(Material mat)
    {
        processingImageMaterial = mat;
    }

    public void RemoveSplatScreen()
    {
        Destroy(this);
    }

    public void SetupManterial(RenderTexture targetRenderTexture)
    {
        this.targetRenderTexture = targetRenderTexture;
        processingImageMaterial.SetTexture("_SplatScreenTex", targetRenderTexture);
    }

    /*
    void OnRenderImage(RenderTexture imageFromRenderedImage, RenderTexture imageDisplayedOnScreen)
    {
        if (processingImageMaterial != null)
        {
            //processingImageMaterial.SetTexture("_SplatScreenTexture", renderTexture);
            Graphics.Blit(imageFromRenderedImage, imageDisplayedOnScreen, processingImageMaterial);
        }

    }
    */

    /*
void OnRenderImage(RenderTexture src, RenderTexture dest)
{
    Texture2D proc = new Texture2D(src.width, src.height);
    proc.ReadPixels(new Rect(0, 0, src.width, src.height), 0, 0);
    //Do your line swapping on proc here
    proc.Apply();

    //Graphics.Blit(renderTexture, dest);

    Graphics.Blit(proc, dest, processingImageMaterial);
}
*/

        /*
    void OnPreRender()
    {
        Debug.Log("OnPreRender");
        if (targetRenderTexture == null)
            return;

        myRenderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        cam.targetTexture = myRenderTexture;
    }
    void OnPostRender()
    {
        Debug.Log("OnPreRender");
        if (targetRenderTexture == null)
            return;

        cam.targetTexture = null; //null means framebuffer
        Graphics.Blit(myRenderTexture, null as RenderTexture, processingImageMaterial);
        RenderTexture.ReleaseTemporary(myRenderTexture);
    }
    */

}
