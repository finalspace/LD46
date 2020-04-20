using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class CharacterSpineAnimator : MonoBehaviour
{
	public SkeletonAnimation skeletonAnimation;
	public AnimationReferenceAsset idle, jump, eat, squish, hurt;
	public string currentState;
	public float speed;
	public float movement;

    void Start()
	{
        skeletonAnimation.state.End += OnStateEnd;

		currentState = "Idle";
        PlayIdle();
    }

    private void OnStateEnd(TrackEntry te)
    {
        if (te.Animation.Name.StartsWith("eat"))
        {
            PlayIdle();
        }
        else if (te.Animation.Name.StartsWith("eat"))
        {
            PlayIdle();
        }
    }

    public void PlayEat()
    {
        SetAnimatoin(eat, true, 1f);
    }

    public void PlayJump()
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
