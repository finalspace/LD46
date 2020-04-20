using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : SingletonBehaviour<MusicManager>
{
    [Header("Background Music")]
    public AudioSource audioSource_BG;
    public AudioClip audioClip_BG;
    public AudioClip audioClip_Title;

    private bool fadingInBG = false;
    private float fadingInProgress;

    [Header("Sound Effect")]
    public AudioSource audioSource_SE;
    public AudioClip audioClip_Jump;
    public AudioClip audioClip_Eat;
    public AudioClip audioClip_Damage;

    public Text timeText;

    private bool started = false;
    private long bgTime;


    private void Update()
    {
        //Debug.Log(audioSource_BG.time);
        if (started && !audioSource_BG.isPlaying)
            PlayBGMusic();
    }

    public void PlayBGMusic()
    {
        //fadingInProgress = 0;
        //DOTween.To(() => fadingInProgress, x => fadingInProgress = x, 1, 5).SetDelay(1).SetEase(Ease.Linear).OnComplete(OnFadeInBGMusicFinish);
        //fadingInBG = true;

        //audioSource_BG.clip = audioClip_BG;
        //audioSource_BG.loop = true;

        audioSource_BG.Play();
        started = true;
        bgTime = DateTimeUtil.GetUnixTime();
    }

    public void OnFadeInBGMusicFinish()
    {
        fadingInBG = false;
    }

    public void PlayJump()
    {
        audioSource_SE.clip = audioClip_Jump;
        audioSource_SE.Play();
    }

    public void PlayEat()
    {
        audioSource_SE.clip = audioClip_Eat;
        audioSource_SE.Play();
    }

    public void PlayDamage()
    {
        audioSource_SE.clip = audioClip_Damage;
        audioSource_SE.Play();
    }

    public int GetBGTime()
    {
        //return DateTimeUtil.MillisecondsElapse(bgTime);
        return (int)(audioSource_BG.time * 1000);
    }


}
