using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAssist : MonoBehaviour
{
    bool isSceneJustLoaded;
    int framCounter;

    [Header("Attributes")]
    public GameObject snapZones;
    public GameObject assemblyPieces;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            randomize();
            snapZones.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSceneJustLoaded)
        {
            framCounter++;
        }

        if (framCounter >= 10)
        {

        }
    }

    /// <summary>
    /// This method is goint to randomize the assembly pieces according to the level of difficulty
    /// The Level of difficulty is 
    /// </summary>
    public void randomize()
    {
        foreach (Transform piece in assemblyPieces.transform)
        {
            switch (GameManager.Instance.currentLevel)
            {
                case GameLevelsNames.Level_0:
                    nicelyRandomizePosition(piece);
                    break;
                case GameLevelsNames.Level_1:
                    roughlyRandomizePosition(piece);
                    break;
                case GameLevelsNames.Level_2:
                    roughlyRandomizePosition(piece);
                    randomizeRotation(piece);
                    break;
                default:
                    break;
            }
        }
    }

    public void nicelyRandomizePosition(Transform piece)
    {

    }

    public void roughlyRandomizePosition(Transform piece) { 
    
    }
    public void randomizeRotation(Transform piece)
    {

    }
}
