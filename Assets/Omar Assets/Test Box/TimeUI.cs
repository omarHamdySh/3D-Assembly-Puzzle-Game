using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TimeUI : MonoBehaviour
{
    TextMeshProUGUI timeText;
    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time in Seconds:" + GameManager.Instance.timeManager.gameTime.realSecond;
    }
}
