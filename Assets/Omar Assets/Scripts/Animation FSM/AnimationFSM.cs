using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TheAnimationState
{
    Idle,
    Waving,
    Attention,
    Talking,
    Talking01,
    Talking02,
    clipping,
}
public class AnimationFSM : MonoBehaviour
{
    public TheAnimationState currentAnimationState;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimationState = TheAnimationState.Idle;
        animator = GetComponent<Animator>();
    }

    public void updateCurrentState(TheAnimationState newAnimationState)
    {
        this.currentAnimationState = newAnimationState;
    }

    // Update is called once per frame


    public void activateThisAnimationStateState(TheAnimationState animationState)
    {
        updateCurrentState(animationState);
        var states = Enum.GetValues(typeof(TheAnimationState));
        foreach (int stateNumber in states)
        {

            if ((TheAnimationState)stateNumber == animationState)
            {
                animator.SetBool(animationState.ToString(), true);
                this.currentAnimationState = animationState;
            }
            else
            {
                animator.SetBool(((TheAnimationState)stateNumber).ToString(), false);
            }
        }
    }


}
