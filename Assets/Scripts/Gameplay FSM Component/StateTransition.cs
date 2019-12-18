using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateTransition : IGameplayState
{
    GameplayState stateName = GameplayState.Transition;

    /// <summary>
    /// Declaration of dynamic variables for surving the logic goes here.
    /// will be populated here by the GameplayFSMManager itself that will declare this place at the first place.
    /// Eg.
    ///     GameplayFSMManager
    /// </summary>
    public GameplayFSMManager gameplayFSMManager;

    public void OnStateEnter()
    {
        GameManager.Instance.OnTransitionHaveToEnd += ExitTransition;
    }
    /// <summary>
    /// Logic of exiting the state goes here.
    ///  Eg.
    ///     pop the currentstate
    ///     push the next state
    /// </summary>
    public void OnStateExit()
    {
    }

    public bool ExitTransition(IGameplayState otherState)
    {
        if (otherState != null)
        {
            if (otherState != gameplayFSMManager.tempTransitionTo)
            {
                ExitToAnotherState(otherState);
                return true;
            }
            else if (otherState == gameplayFSMManager.tempTransitionTo)
            {
                ExitToTheSameState();
                return true;
            }
        }
        else
        {
            ExitToTheSameState();
            return true;
        }
        return false;
    }
    public void printSelfMappingError(GameplayState backTo)
    {
        if (gameplayFSMManager.hintTxt)
        {
            gameplayFSMManager.hintTxt.text = "Error You are mapping to the same sate";
            gameplayFSMManager.hintTxt.color = Color.red;
            gameplayFSMManager.hintTxt.enabled = true;

            gameplayFSMManager.changeToAState(backTo);
        }
    }

    public void ExitToTheSameState()
    {
        ////Map to according to the transitionDirection
        switch (gameplayFSMManager.tempTransitionFrom.GetState())
        {
            case GameplayState.Tutorial:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        printSelfMappingError(GameplayState.Tutorial);
                        break;
                    case GameplayState.AssemblyDisassembly:
                        gameplayFSMManager.toAssemblyDisassembly();
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        gameplayFSMManager.toAssemblyDisassemblyTutorial();
                        break;
                    case GameplayState.Shooting:
                        gameplayFSMManager.toSooting();
                        break;
                    case GameplayState.Testing:
                        gameplayFSMManager.toTesting();
                        break;
                    case GameplayState.Pause:
                        gameplayFSMManager.pauseGame();
                        break;
                }
                break;
            case GameplayState.AssemblyDisassembly:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        gameplayFSMManager.toTutorial();
                        break;
                    case GameplayState.AssemblyDisassembly:
                        printSelfMappingError(GameplayState.AssemblyDisassembly);
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        gameplayFSMManager.toAssemblyDisassemblyTutorial();
                        break;
                    case GameplayState.Shooting:
                        gameplayFSMManager.toSooting();
                        break;
                    case GameplayState.Testing:
                        gameplayFSMManager.toTesting();
                        break;
                    case GameplayState.Pause:
                        gameplayFSMManager.pauseGame();
                        break;
                }
                break;
            case GameplayState.AssemblyDisassemblyTutorial:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        gameplayFSMManager.toTutorial();
                        break;
                    case GameplayState.AssemblyDisassembly:
                        gameplayFSMManager.toAssemblyDisassembly();
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        printSelfMappingError(GameplayState.AssemblyDisassemblyTutorial);
                        break;
                    case GameplayState.Shooting:
                        gameplayFSMManager.toSooting();
                        break;
                    case GameplayState.Testing:
                        gameplayFSMManager.toTesting();
                        break;
                    case GameplayState.Pause:
                        gameplayFSMManager.pauseGame();
                        break;
                }
                break;
            case GameplayState.Shooting:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        gameplayFSMManager.toTutorial();
                        break;
                    case GameplayState.AssemblyDisassembly:
                        gameplayFSMManager.toAssemblyDisassembly();
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        gameplayFSMManager.toAssemblyDisassemblyTutorial();
                        break;
                    case GameplayState.Shooting:
                        printSelfMappingError(GameplayState.Shooting);
                        break;
                    case GameplayState.Testing:
                        gameplayFSMManager.toTesting();
                        break;
                    case GameplayState.Pause:
                        gameplayFSMManager.pauseGame();
                        break;
                }
                break;
            case GameplayState.Testing:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        gameplayFSMManager.toTutorial();
                        break;
                    case GameplayState.AssemblyDisassembly:
                        gameplayFSMManager.toAssemblyDisassembly();
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        gameplayFSMManager.toAssemblyDisassemblyTutorial();
                        break;
                    case GameplayState.Shooting:
                        gameplayFSMManager.toSooting();
                        break;
                    case GameplayState.Testing:
                        printSelfMappingError(GameplayState.Testing);
                        break;
                    case GameplayState.Pause:
                        gameplayFSMManager.pauseGame();
                        break;
                }
                break;
            case GameplayState.Pause:
                switch (gameplayFSMManager.tempTransitionTo.GetState())
                {
                    case GameplayState.Tutorial:
                        gameplayFSMManager.toTutorial();
                        break;
                    case GameplayState.AssemblyDisassembly:
                        gameplayFSMManager.toAssemblyDisassembly();
                        break;
                    case GameplayState.AssemblyDisassemblyTutorial:
                        gameplayFSMManager.toAssemblyDisassemblyTutorial();
                        break;
                    case GameplayState.Shooting:
                        gameplayFSMManager.toSooting();
                        break;
                    case GameplayState.Testing:
                        gameplayFSMManager.toTesting();
                        break;
                    case GameplayState.Pause:
                        printSelfMappingError(GameplayState.Pause);
                        break;
                }
                break;
            default:
                break;
        }
    }
    public void ExitToAnotherState(IGameplayState otherState)
    {
        gameplayFSMManager.tempTransitionTo = otherState;
        ////Map to according to the transitionDirection
        /**
         * You can copy the ExitToTheSameState() method and edit it.
         * You can use methods that changes the state with transion if 
         * needed or do what ever you want.
         * **/
        ExitToTheSameState();
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
