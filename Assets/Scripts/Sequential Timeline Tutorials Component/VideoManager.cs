using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    public UnityEvent onVideoEnd;
    
    private void Start()
    {
        videoPlayer.loopPointReached += EndVideo;
    }

    private void EndVideo(VideoPlayer player)
    {
        if (!videoPlayer.isPlaying)
        {

            onVideoEnd.Invoke();
            
        }
    }
}
