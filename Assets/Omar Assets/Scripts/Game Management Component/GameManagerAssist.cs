using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerAssist : MonoBehaviour
{
    bool isSceneJustLoaded;
    int framCounter;

    [Header("Attributes")]
    public GameObject snapZones;
    public GameObject assemblyPieces;
    [SerializeField] private float slowRandTime = 0.5f;


    #region CountDown Timer
    [SerializeField] private int hours = 0, minutes = 0, seconds = 5;
    [SerializeField] private TextMeshProUGUI timerTxt;
    private bool takingAway;
    #endregion

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        timerTxt.text = /*hours.ToString("00") + ":" + minutes.ToString("00") + ":" +*/ seconds.ToString("00");
        snapZones.gameObject.SetActive(false);
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

        if (takingAway == false && seconds > 0)
        {
            StartCoroutine(TakeDownTimer());
        }
        else if (seconds == 0 && takingAway == false)
        {
            takingAway = true;
            timerTxt.gameObject.SetActive(false);
            if (GameManager.Instance != null)
            {
                randomize();
            }
        }

    }

    IEnumerator TakeDownTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        seconds--;
        timerTxt.text = /*hours.ToString("00") + ":" + minutes.ToString("00") + ":" +*/ seconds.ToString("00");
        takingAway = false;
    }

    /// <summary>
    /// This method is goint to randomize the assembly pieces according to the level of difficulty
    /// The Level of difficulty is 
    /// </summary>
    public void randomize()
    {
        StartCoroutine(SlowDownRand());
    }

    IEnumerator SlowDownRand()
    {
        foreach (Transform piece in assemblyPieces.transform)
        {
            yield return new WaitForSeconds(slowRandTime);
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
            piece.GetComponent<MeshCollider>().enabled = true;
        }
        snapZones.gameObject.SetActive(true);
        GetComponent<GameLogicManager>().fetchAllSnapZones();
    }

    public void nicelyRandomizePosition(Transform piece)
    {
        piece.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }

    public void roughlyRandomizePosition(Transform piece)
    {

    }
    public void randomizeRotation(Transform piece)
    {

    }
}
