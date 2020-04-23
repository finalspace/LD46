using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : SingletonBehaviour<MusicManager>
{
    [Header("Background Music")]
    public AudioSource audioSource_BG;
    public AudioClip audioClip_Game;
    public AudioClip audioClip_Title;

    private bool fadingInBG = false;
    private float fadingInProgress;

    [Header("Sound Effect")]
    public AudioSource audioSource_SE;
    public AudioClip audioClip_Jump;
    public AudioClip audioClip_Eat;
    public AudioClip audioClip_Damage;
    public AudioClip audioClip_Campfire;

    // - actually noticed a slowdown with extra audiosource, so going back to using flag checks - //
    // using a separate audiosource for thunder to avoid the complication
    // of other sounds stopping the thunder before it's heard
    public AudioSource audioSource_thunder;
    public AudioClip audioClip_Thunder;

    public Text timeText;

    private bool started = false;
    private bool damped = false; // whether music has been ducked to low volume
    private bool thundering = false; // so we don't start new sound effects until thunder is done
    private long bgTime;

    private void Start()
    {
        audioSource_thunder.clip = audioClip_Thunder;
        audioSource_thunder.volume = 0.6f;
        //audioClip_Jump = MakeSubclip(audioClip_Jump, 0.8f, 0.942f);

        //audioClip_Jump = MakeSubclip(audioClip_Jump, 0.3f, 0.9f);
        //audioClip_Jump = MakeSubclip(audioClip_Jump, 0.5f, 0.9f); // not bad at .7 vol
    }


    private void Update()
    {
        //if (thundering)
        //{
        //    if (!audioSource_SE.isPlaying) thundering = false;
            // should not assume playcampfire is still valid, actually, handling in WaypointCollision
            //PlayCampfire();
        //}
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

        audioSource_BG.Stop(); // just in case

        if (MainGameManager.Instance.gameState == GameState.Title)
        {
            TitleMusic();
        } else
        {
            GameMusic();
        }
        if (!damped) UndampenMusic(); // keep damped if on a campfire, else normal volume
        audioSource_BG.Play();
        started = true;
        bgTime = DateTimeUtil.GetUnixTime();
    }

    public void TitleMusic()
    {
        audioSource_BG.clip = audioClip_Title;
    }

    public void GameMusic()
    {
        audioSource_BG.clip = audioClip_Game;
    }

    public void OnFadeInBGMusicFinish()
    {
        fadingInBG = false;
    }

    public void PlayJump()
    {
        if (!thundering) // not used currently but thunder is false by default
        {
            audioSource_SE.clip = audioClip_Jump;
            //audioSource_SE.pitch = 0.2f; // about the right pitch for flame
            //audioSource_SE.pitch = 0.1f; // about the right pitch for flame
            //audioSource_SE.volume = 0.3f;
            //audioSource_SE.volume = 0.7f;
            //audioSource_SE.volume = 1f;
            audioSource_SE.volume = 0.06f;
            audioSource_SE.Play();
        }
    }

    public void PlayEat()
    {
        if (!thundering)
        {
            audioSource_SE.clip = audioClip_Eat;
            //audioSource_SE.clip = audioClip_Thunder;
            audioSource_SE.volume = 0.9f;
            audioSource_SE.Play();
        }
    }

    public void PlayDamage()
    {
        if (!thundering)
        {
            audioSource_SE.clip = audioClip_Damage;
            audioSource_SE.volume = 1f;
            audioSource_SE.Play();
        }
    }

    public void PlayCampfire()
    {
        if (!thundering)
        {
            audioSource_SE.clip = audioClip_Campfire;
            DampenMusic();
            audioSource_SE.volume = 1f;
            audioSource_SE.Play();
        }
    }

    public void DampenMusic()
    {
        audioSource_BG.volume = 0.1f;
        damped = true;
    }

    public void UndampenMusic()
    {
        audioSource_BG.volume = 0.6f;
        damped = false;
    }

    public void PlayThunder()
    {
        //audioSource_SE.clip = audioClip_Thunder;
        //audioSource_thunder.volume = 0.6f;
        //audioSource_thunder.clip = audioClip_Thunder;
        //thundering = true;
        DampenMusic();
        //audioSource_SE.volume = 0.6f;
        //audioSource_SE.Play();
        //audioSource_thunder.volume = 1f;
        audioSource_thunder.Play();

    }

    public int GetBGTime()
    {
        //return DateTimeUtil.MillisecondsElapse(bgTime);
        return (int)(audioSource_BG.time * 1000);
    }


    /**
     * Creates a sub clip from an audio clip based off of the start time
     * and the stop time. The new clip will have the same frequency as
     * the original.
     */
    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 1, frequency, false);
        /* Create a temporary buffer for the samples */
        float[] data = new float[samplesLength];
        /* Get the data from the original clip */
        clip.GetData(data, (int)(frequency * start));
        /* Transfer the data to the new clip */
        newClip.SetData(data, 0);
        /* Return the sub clip */
        return newClip;
    }
}
