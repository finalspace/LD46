using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class CharacterSpineAnimator : MonoBehaviour
{
	public SkeletonAnimation skeletonAnimation;
	public AnimationReferenceAsset idle, walking;
	public string currentState;
	public float speed;
	public float movement;

    void Start()
	{
		currentState = "Idle";
        SetCharacterState(currentState);
    }
        
    public void PlayEat()
    {

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
