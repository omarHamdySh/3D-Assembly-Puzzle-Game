using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct Timer
{
    public int EasyTimer;
    public int NormalTimer;
    public int HardTimer;

}
public class GameManagerAssist : MonoBehaviour
{
    bool isSceneJustLoaded;
    int framCounter;

    [Header("Attributes")]
    public GameObject snapZones;
    public GameObject assemblyPieces;
    [SerializeField] private int RotationAngle = 90;
    [SerializeField] private float slowRandTime = 0.5f;

    #region CountDown Timer
    [SerializeField] private int hours = 0, minutes = 0, seconds = 5;
    [SerializeField] private TextMeshProUGUI timerTxt;
    private bool takingAway;
    private bool gameStarted = false;
    public bool m_GameOver = false;

    public Timer LevelTimer;
    #endregion

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        m_GameOver = false;
        timerTxt.text = /*hours.ToString("00") + ":" + minutes.ToString("00") + ":" +*/ seconds.ToString("00");
        snapZones.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameOver)
        {
            return;
        }
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
        else if (seconds == 0 && takingAway == false && !gameStarted && !m_GameOver)
        {
            takingAway = true;
            timerTxt.gameObject.SetActive(false);
            if (GameManager.Instance != null)
            {
                randomize();
            }
        }
        else if(seconds == 0 && !takingAway && gameStarted)
        {
            m_GameOver = true;
            this.gameObject.GetComponent<GameLogicManager>().GameOver();
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
   
    public void GameOver()
    {

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
        //March
        CheckLevel();
    }
  

    public void nicelyRandomizePosition(Transform piece)
    {
        piece.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
    //March implement
    public void roughlyRandomizePosition(Transform piece)
    {
        piece.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), Random.Range(-4f, 4f));

    }
    //March implement
    public void randomizeRotation(Transform piece)
    {
        //RotationAngle = 90
        int MaxAngleValue = 360 / RotationAngle;
        int RandomRotationX = Random.Range(0, MaxAngleValue + 1);
        int RandomRotationY = Random.Range(0, MaxAngleValue + 1);
        int RandomRotationZ = Random.Range(0, MaxAngleValue + 1);

        //add random Rotation
        Vector3 randomRotation = new Vector3(this.transform.rotation.x + RotationAngle * RandomRotationX,
            this.transform.rotation.y + RotationAngle * RandomRotationY,
            this.transform.rotation.z + RotationAngle * RandomRotationZ);

        piece.Rotate(randomRotation, Space.World);    
    }

    #region March Update
    private void CheckLevel()
    {
        switch (GameManager.Instance.currentLevel)
        {
            case GameLevelsNames.Level_0:
                StartCountDown(LevelTimer.EasyTimer);
                break;
            case GameLevelsNames.Level_1:
                StartCountDown(LevelTimer.NormalTimer);
                break;
            case GameLevelsNames.Level_2:
                StartCountDown(LevelTimer.HardTimer);
                break;
            default:
                break;
        }
    }
    private void StartCountDown(int levelTimer)
    {
        seconds = levelTimer;
        takingAway = false;
        timerTxt.text = /*hours.ToString("00") + ":" + minutes.ToString("00") + ":" +*/ seconds.ToString("00");
        timerTxt.gameObject.SetActive(true);
        gameStarted = true;
    }
    #endregion
}
