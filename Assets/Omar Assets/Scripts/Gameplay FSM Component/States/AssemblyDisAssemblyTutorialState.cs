using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDisAssemblyTutorialState : IGameplayState
{
    GameplayState stateName = GameplayState.AssemblyDisassemblyTutorial;

    public GameplayFSMManager gameplayFSMManager;


    public void OnStateEnter()
    {

    }

    public void OnStateExit()
    {

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
