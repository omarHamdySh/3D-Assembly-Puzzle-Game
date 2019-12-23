using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTypingAnimation : MonoBehaviour
{
    public IEnumerator currentcourtine;
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterWritingSpeed = 0.01f;
    //Message that will displays till the end that will come out letter by letter
    private string strmessage;
    //Text for the message to display
    public Text contentTxt;
    public Text headerTxt;


    IEnumerator TypeText()
    {
        //Split each char into a char array

        foreach (char letter in strmessage.ToCharArray())
        {
            if (contentTxt)
            {
                contentTxt.text += letter;
            }
            //Add 1 letter each
            yield return 0;
            yield return new WaitForSeconds(letterWritingSpeed);
        }
    }
    public void Play( string headerStr, string massage)
    {
        if (headerTxt) {
            headerTxt.text = "";
            headerTxt.text = headerStr;
        }
        if (contentTxt)
        {
            contentTxt.text = "";
        }
        strmessage = "";
        strmessage = massage;
        if (currentcourtine != null)
        {
            StopCoroutine(currentcourtine);
        }
        currentcourtine = TypeText();
        StartCoroutine(currentcourtine);
    }

}