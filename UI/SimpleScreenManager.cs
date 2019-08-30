using UnityEngine;

public class CanvasScreenManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("screen in canvas opened by buttons")]
    GameObject[] screens;

    [SerializeField]
    int startScreen = 0; //

    public int testStartScreen = 0;

    private void Start()
    {
#if UNITY_EDITOR
        startScreen = testStartScreen;
#endif

        CloseAllScreen();
        OpenScreen(startScreen);
    }


    void CloseAllScreen()
    {
        foreach (var item in screens)
        {
            item.SetActive(false);
        }
    }

    //For Internal Use
    void InternalOpenScreen(int numScreen)
    {
        screens[numScreen].SetActive(true);
    }

    public void OpenScreen(int numScreen)
    {
        if(numScreen > screens.Length || numScreen < 0)
        {
            Debug.LogError("Num Screen invalid");

        }
        else
        {
            CloseAllScreen();
            InternalOpenScreen(numScreen);
        }

    }

}
