using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IGameplayState
{
    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager gameplayFSMManager;
    /// </summary>
    
    GameplayState stateName = GameplayState.Pause;
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        //pause the game        
        GameManager.Instance.PauseGame();
    }
    public void OnStateExit()
    {
        GameManager.Instance.ResumeGame();
    }

    public void OnStateUpdate()
    {
    }

    string ToString()
    {
        return stateName.ToString();
    }

    public GameplayState GetState()
    {
        return stateName;
    }
}
