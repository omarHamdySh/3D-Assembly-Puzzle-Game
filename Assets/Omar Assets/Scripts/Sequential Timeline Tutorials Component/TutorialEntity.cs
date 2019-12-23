using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TutorialEntity : MonoBehaviour
{
    public TutorialEvent tutorialEvent;
    public TheAnimationState animationClip;
    public AudioSource audioSource;
    public string messageHeader;
    public string messageContent;


    public void playSequence()
    {
        TutorialManager.Instance.avatarAnimationFSM.activateThisAnimationStateState(animationClip);
        if (audioSource)
        {
            if (audioSource.clip != null)
                audioSource.Play();
        }
        TutorialManager.Instance.textTypingAnimator.Play(messageHeader, messageContent);
    }
}
