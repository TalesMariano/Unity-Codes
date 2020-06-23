using UnityEngine;

public class MatchSizeVideoScreen : MonoBehaviour
{

    public Vector2 screenSize = new Vector2(1920, 1080);
    public Vector2 videoSize = new Vector2(2048f, 1000f);

    public Vector2 newResolutionVideo;

    [ContextMenu("ScreenFit")]
    void ScreenFit()
    {
        float ratioScreen = screenSize.y / screenSize.x;
        float ratioVideo = videoSize.y / videoSize.x;

        Debug.Log("ratioScreen " + ratioScreen);
        Debug.Log("ratioVideo " + ratioVideo);

        

        if (ratioScreen > ratioVideo)
        {
            float newWight = screenSize.x;
            float newHeight = (videoSize.y * screenSize.x) / videoSize.x;
            

            newResolutionVideo = new Vector2(newWight, newHeight);
        }
        else
        {
            float  newHeight = screenSize.y;
            float newWight = (videoSize.x * screenSize.y) / videoSize.y;

            newResolutionVideo = new Vector2(newWight, newHeight);
        }
    }
}
