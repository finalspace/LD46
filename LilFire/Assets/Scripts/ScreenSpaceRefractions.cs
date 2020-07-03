using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ScreenSpaceRefractions : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Camera cam;
    private int downResFactor = 1;

    [SerializeField]
    [Range(0, 1)]
    private float refractionVisibility = 0;
    [SerializeField]
    [Range(0, 1f)]
    private float refractionMagnitude = 0;

    public int mirrorWidth = 200;
    public int mirrorHeight = 248;

    private string globalTextureName = "_GlobalRefractionTex";
    private string globalVisibilityName = "_GlobalVisibility";
    private string globalMagnitudeName = "_GlobalRefractionMag";

    public void VisibilityChange(float value)
    {
        refractionVisibility = value;
        Shader.SetGlobalFloat(globalVisibilityName, refractionVisibility);
    }

    public void MagnitudeChange(float value)
    {
        refractionMagnitude = value;
        Shader.SetGlobalFloat(globalMagnitudeName, refractionMagnitude);
    }

    void OnEnable()
    {
        GenerateRT();
        Shader.SetGlobalFloat(globalVisibilityName, refractionVisibility);
        Shader.SetGlobalFloat(globalMagnitudeName, refractionMagnitude);
    }

    void OnValidate()
    {
        Shader.SetGlobalFloat(globalVisibilityName, refractionVisibility);
        Shader.SetGlobalFloat(globalMagnitudeName, refractionMagnitude);
    }

    void GenerateRT()
    {
        cam = GetComponent<Camera>();

        if (cam.targetTexture != null)
        {
            RenderTexture temp = cam.targetTexture;

            cam.targetTexture = null;
            DestroyImmediate(temp);
        }

        cam.targetTexture = new RenderTexture(mirrorWidth >> downResFactor, mirrorHeight >> downResFactor, 16);
        cam.targetTexture.filterMode = FilterMode.Bilinear;

        Shader.SetGlobalTexture(globalTextureName, cam.targetTexture);
    }
}