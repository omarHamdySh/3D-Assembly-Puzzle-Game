using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventManagment : MonoBehaviour
{
    // variables required 
    public bool Bool1 = false;
    public bool Bool2 = false;
    public int TextNumber = 0;
    public Text TextBox;
    public Text Bool1Statues;
    public Text Bool2Statues;
    
    void Update()
    {   // case if first button pressed
        if (Bool1 && !Bool2)
        {
            TextNumber++;
            TextBox.text = TextNumber.ToString();
        }
        // case of first and second button pressed
      else if (Bool1 && Bool2)
        {
            TextNumber--;
            TextBox.text = TextNumber.ToString();

        }
       

    }
    //first button function
    public void FirstBoolTrue ()
    {
        Bool1 = true;
        Bool1Statues.text = " Bool1 : true";
    }
    //second button function
    public void SecondBoolTrue()
    {
        Bool2 = true;
        Bool2Statues.text = " Bool2 : true";

    }    
    //third button function
   public void AllBoolFalse()
    {
        Bool1 = false;
        Bool1Statues.text = " Bool1 : false";
        Bool2 = false;
        Bool2Statues.text = " Bool2 : false";

    }
}
