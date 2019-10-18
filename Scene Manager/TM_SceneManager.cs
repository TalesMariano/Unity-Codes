/// Copyright (c) Microsoft Corporation. All rights reserved.
/// Licensed under the MIT License. See LICENSE in the project root for license information.
///
/// References
/// 
///     To Do
/// Check http://www.alanzucconi.com/2016/03/23/scene-management-unity-5/
/// Add Aditive Scene
/// Remove Instances outside singleton
/// Add require TM_SceneHelper
/// Destroy this instead game object

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TM_SceneManager : MonoBehaviour
{
    public bool rRestart = false;

    public string NextSceneName;

    static int loadingSceneNum = 1;

    public int nextSceneInt = 0;

    public bool loadNext = false;

    //Singleton
    public static TM_SceneManager instance = null;
    void Awake()
    {
        // print("TestAwake");
        if (instance == null)           //Check if instance already exists
            instance = this;            //if not, set instance to this
        else if (instance != this)
        {      //If instance already exists and it's not this:
            //instance.LoadNext();
            Destroy(gameObject);        //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
        }
        DontDestroyOnLoad(gameObject);  //Sets this to not be destroyed when reloading scene
    }

    void Start()
    {
        print("TestStart");
        if (loadNext)
        {
            LoadLoadingScene();
        }
    }

    void Update()
    {
        if (rRestart && Input.GetKeyDown(KeyCode.R))
            RestartScene();
    }

    
    public static void LoadScene(int intScene)
    {
        //nextsce
        instance.StartCoroutine(LoadAsyncScene(intScene, true));
    }

    public void LoadNext()
    {
        StartCoroutine(LoadAsyncScene(nextSceneInt, false));
    }


    public void LoadLoadingScene()
    {
        StartCoroutine(LoadAsyncScene(nextSceneInt, true));
       
    }

    //based on https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html
    static IEnumerator LoadAsyncScene(int numScene, bool next)
    {
        print(numScene + " - " + next);

        yield return null;
        AsyncOperation asyncOperation;

        if(next)
            asyncOperation = SceneManager.LoadSceneAsync(loadingSceneNum);
        else
            asyncOperation = SceneManager.LoadSceneAsync(numScene);

        //Begin to load the Scene you specify

        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //m_Text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                //    m_Text.text = "Press the space bar to continue";
                //Wait to you press the space key to activate the Scene
                //    if (Input.GetKeyDown(KeyCode.Space))
                //Activate the Scene
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        //loadNext = next;
                 //yield return new WaitForSeconds(1);
        if (next)
            instance.StartCoroutine(LoadAsyncScene(numScene, false));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadSceneName(string name)
    {
        //LoadSceneName(name);
    }

    public void LoadSceneInt(int num)
    {
        SceneManager.LoadScene(num);
    }

    private void GotoNextScene()
    {
        //InputManager.Instance.RemoveGlobalListener(gameObject);

        if (!string.IsNullOrEmpty(NextSceneName))
        {
            SceneManager.LoadScene(NextSceneName);
        }
        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }
}

