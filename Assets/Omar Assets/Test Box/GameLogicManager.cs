using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLogicManager : MonoBehaviour
{
    public UnityEvent playerWins, PlayerLoses, Hints;
    public GameObject fireWorks;
    public List<SnapZone3D_Omar> activeSnapZones;
    private bool isWinning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GameOver()
    {
        if(!isWinning)
            PlayerLoses.Invoke();
    }
    public void fetchAllSnapZones()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.startLevelTime();
            SnapZone3D_Omar[] snapZones = GameObject.FindObjectsOfType<SnapZone3D_Omar>();
            foreach (var snapZone in snapZones)
            {
                activeSnapZones.Add(snapZone);
                snapZone.OnSnappedEvent += removeOnSnap;
            }
        }
    }

    public void removeOnSnap(SnapZone3D_Omar snapZone) {
        //Remove the snapZone from active snap zones list which will remain the playing logic.
        activeSnapZones.Remove(snapZone);
        
        if (activeSnapZones.Count==0)
        {
            isWinning = true;
            playerWins.Invoke();
        }
    }
}
