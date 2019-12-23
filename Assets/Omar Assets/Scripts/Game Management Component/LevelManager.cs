using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameLevelsNames currentLevel;

    private static LevelManager _Instance;
    public static LevelManager Instance
    {
        get { return _Instance; }
    }
    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeToNextScene()
    {

    }

  
}
