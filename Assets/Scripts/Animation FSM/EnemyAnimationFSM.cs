using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyAnimationState
{
    Move,
    Attack,
    Death
}
public class EnemyAnimationFSM : MonoBehaviour
{
    public EnemyAnimationState currentAnimationState;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimationState = EnemyAnimationState.Move;
        animator = GetComponent<Animator>();
    }

    public void updateCurrentState(EnemyAnimationState newAnimationState)
    {
        this.currentAnimationState = newAnimationState;
    }

    // Update is called once per frame


    public void activateThisAnimationStateState(EnemyAnimationState animationState)
    {
        updateCurrentState(animationState);
        var states = Enum.GetValues(typeof(AnimationState));
        foreach (int stateNumber in states)
        {

            if ((EnemyAnimationState)stateNumber == animationState)
            {
                animator.SetBool(animationState.ToString(), true);
                this.currentAnimationState = animationState;
            }
            else
            {
                animator.SetBool(((EnemyAnimationState)stateNumber).ToString(), false);
            }
        }
    }

}
