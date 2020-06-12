using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class CharacterSpineAnimator : MonoBehaviour
{
    [Header("Spine Animation")]
	public SkeletonAnimation skeletonAnimation;
	public AnimationReferenceAsset birth, idle, jump, eat, squish, hurt, transition, die;
	public string currentState;
	public float speed;
	public float movement;

    [Header("Unity Animation")]
    public Animator unityAnimator;

    private void OnEnable()
    {
        EventManager.OnPlayerLand += PlayLanding;
        EventManager.OnPlayerJump += PlayJump;
        EventManager.OnPlayerJumpFailed += PlayIdle;

    }

    private void OnDisable()
    {
        EventManager.OnPlayerLand -= PlayLanding;
        EventManager.OnPlayerJump -= PlayJump;
        EventManager.OnPlayerJumpFailed -= PlayIdle;
    }

    void Start()
	{
        skeletonAnimation.state.Complete += OnStateComplete;

		currentState = "Idle";
        PlayIdle();
    }

    private void OnStateComplete(TrackEntry te)
    {
        if (te.Animation.Name.StartsWith("eat", System.StringComparison.CurrentCultureIgnoreCase))
        {
			PlayIdle();
        }
        else if (te.Animation.Name.StartsWith("landing_transition", System.StringComparison.CurrentCultureIgnoreCase))
        {
			PlayIdle();
        }
        else if (te.Animation.Name == "birth")
        {
            PlayIdle();
        }
    }

    /*****************************************
     * 
     * Spine Animation
     * 
     *****************************************/

    public void PlayBirth()
    {
        SetAnimatoin(birth, false, 1f);
    }

    public void PlayEat()
    {
        SetAnimatoin(eat, false, 1f);
    }

    public void PlayHurt()
    {
        SetAnimatoin(hurt, false, 1f);
    }

    public void PlayJump(float power)
    {
        SetAnimatoin(jump, true, 1f);
    }

    public void PlayIdle()
    {
        SetAnimatoin(idle, true, 1f);
    }

    public void PlaySquish()
    {
        SetAnimatoin(squish, true, 1f);
    }

    public void PlayLanding()
    {
        SetAnimatoin(transition, false, 1f);
    }

    public void PlayDie()
    {
        SetAnimatoin(die, false, 1f);
    }

    /*****************************************
     * 
     * Unity Animation
     * 
     *****************************************/

    public void PlayFlash()
    {
        unityAnimator.Play("Hit");
    }

    public void StopFlash()
    {
        unityAnimator.Play("Normal");
    }

    public void SetAnimatoin(AnimationReferenceAsset animation, bool loop, float timeScale)
	{
		skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
	}

    public void SetCharacterState(string state)
	{
		if (state.Equals("Idle"))
			SetAnimatoin(idle, true, 1f);
	}
}
