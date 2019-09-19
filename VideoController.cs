// Code by Tales Mariano - TalesMariano.com
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer vp;
    public UnityEvent videoOver;

    private void OnEnable()
    {
        vp.loopPointReached += EndVideo;
    }

    private void OnDisable()
    {
        vp.loopPointReached -= EndVideo;
    }

    public void EndVideo(VideoPlayer vp)
    {
        videoOver.Invoke();
    }
}
