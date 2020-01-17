using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public void SoundON()
    {
        AudioListener.pause = false;
    }
    public void SoundOFF()
    {
        AudioListener.pause = true;
    }
}
