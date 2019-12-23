using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TutorialEvent
{
    IntroVideo,
    CleaningStarted,
    CheeringBeautiful,
    CheeringAmazing,
    CheeringPerfact,
    SheildActivation,
    AttackStarted,
    Attention,
    WhileShooting,
    WhenInjured,
    SheildDestraction,
    TeethDecayBreakfast,
    TeethDecayLunch,
    TeethDecayDinner,
    GameEnded,
    SweetDreams
}

public class TutorialManager : MonoBehaviour
{

    public static TutorialManager _Instance;

    //[HideInInspector]
    public List<TutorialEntity> tutorialStateEntities = new List<TutorialEntity>();
    public Queue<TutorialEntity> EntitiesQueue = new Queue<TutorialEntity>();
    private Dictionary<TutorialEvent, TutorialEntity> tutorialMap = new Dictionary<TutorialEvent, TutorialEntity>();
    public AnimationFSM avatarAnimationFSM;
    public TextTypingAnimation textTypingAnimator;

    public static TutorialManager Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        foreach (Transform level in transform)
        {
            foreach (Transform tutroialEntity in level)
            {
                tutorialMap.Add(
                    tutroialEntity.gameObject.GetComponent<TutorialEntity>().tutorialEvent,
                    tutroialEntity.gameObject.GetComponent<TutorialEntity>());
            }
        }

        foreach (var item in tutorialStateEntities)
        {
            EntitiesQueue.Enqueue(item.gameObject.GetComponent<TutorialEntity>());
        }

    }

    public void PlayNextSequence() {

        EntitiesQueue.Dequeue().playSequence();

    }

    public void playThisSequence(TutorialEvent tutorialEvent){

        tutorialMap[tutorialEvent].playSequence();

    }

}
