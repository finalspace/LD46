using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SplatScreenController : SingletonBehaviour<SplatScreenController> 
{
    public enum PlayMode
    {
        PlayOnce,
        PlayNTimes,
        LoopForSeconds,
        StartLoopAndContinue,
        PlaySequence
    }

    public Camera camera1;
    public Camera splatScreenCamera;
    public GameObject animRoot;
    public Material processingImageMaterial;
    
    private SplatScreenCamera splatScreenMainCamera;
    private RenderTexture splatScreenRT;

    public System.Action<bool> callback;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        splatScreenMainCamera = camera1.gameObject.GetComponent<SplatScreenCamera>();
        if (splatScreenMainCamera != null)
            UnityEngine.Object.Destroy(splatScreenMainCamera);

        splatScreenMainCamera = camera1.gameObject.AddComponent<SplatScreenCamera>();
        splatScreenMainCamera.Init(processingImageMaterial);

        //setup render texture for splat screen camera
        if (splatScreenCamera.targetTexture != null)
        {
            splatScreenCamera.targetTexture.Release();
        }
        splatScreenRT = new RenderTexture(Screen.width, Screen.height, 16);
        splatScreenCamera.targetTexture = splatScreenRT;

        splatScreenMainCamera.SetupManterial(splatScreenRT);
    }

    public void Register(GameObject obj, bool keepPosition = true)
    {
        obj.transform.SetParent(animRoot.transform, keepPosition);
        SetLayerRecursively(obj, LayerMask.NameToLayer("PostEffect"));
    }

    private void SetLayerRecursively(GameObject obj, int layer)
    {
        if (obj == null)
            return;

        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            if (child == null)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, layer);
        }
    }

    /*
    // is splat screen still animating?
    public bool IsBusy
    { 
        get
        {
            return isBusy;
        }
    }

    /// <summary>
    /// simple version: play the animation once with default parameters
    /// </summary>
    /// <param name="animObj">Animation object.</param>
    /// <param name="animationName">Animation name.</param>
    /// <param name="callback">Callback.</param>
    public void Play(GameObject obj, string animationName, System.Action<bool> callback)
    {
        if (obj == null || string.IsNullOrEmpty(animationName))
        {
            Done();
            return;
        }
        animObj = obj;
        animName = animationName;
        this.callback = callback;

        obj.transform.SetParent(animRoot.transform, true);

        skeletonAnimation = animObj.GetComponent<SkeletonAnimation>();
        if (skeletonAnimation == null)
        {
            DebugUtils.LogError("gameObject [" + animObj.name + "] does not have a SkeletonAnimation component!");
            Done();
            return;
        }

        skeletonAnimation.loop = false;
        skeletonAnimation.timeScale = 1;

        if (!StringUtils.IsNullOrWhiteSpace(animationName))
        {
            skeletonAnimation.AnimationName = animationName;

            var trackEntry = skeletonAnimation.AnimationState.GetCurrent(0);
            trackEntry.MixDuration = 0;
            isBusy = true;
        }
        else
        {
            Done();
            return;
        }
    }

    public void Done(bool doneSuccessfully = false)
    {
        isBusy = false;
        if (callback != null)
            callback(doneSuccessfully);

        if (splatScreenMainCamera != null)
            UnityEngine.Object.Destroy(splatScreenMainCamera);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!isBusy)
            return;

        ValidCheck();

        // still animating?
        isBusy = !skeletonAnimation.AnimationState.GetCurrent(0).IsComplete;
        if (!isBusy)
            Done(true);
    }

    private void ValidCheck()
    {
        if (skeletonAnimation == null || skeletonAnimation.AnimationState == null)
        {
            Done();
        }
    }
    */
}
