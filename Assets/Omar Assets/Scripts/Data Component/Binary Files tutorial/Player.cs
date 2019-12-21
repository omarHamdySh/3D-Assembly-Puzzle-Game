using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int health = 100;
    public Text levelTxt;
    public Text healthTxt;

    #region Data manipulation methods for UI
    public void changeLevel(int levelNo)
    {

        level += levelNo;
        level = Mathf.Clamp(level, 1, 5);
        levelTxt.text = level.ToString();
    }

    public void changeHealth(int amount)
    {

        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        healthTxt.text = health.ToString();

    }

    public void reflectDataOnUI() {
        levelTxt.text = level.ToString();
        healthTxt.text = health.ToString();
    }
    #endregion
    #region Player Data Saving/Loading Funcion

    public void savePlayer()
    {
        SaveSystem.savePlayer(this);
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();
        level = data.level;
        health = data.health;

        Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
        transform.position = position;
    }

    #endregion
}
