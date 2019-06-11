// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

//Reference
// Hololens toolkit
// http://www.alanzucconi.com/2016/03/23/scene-management-unity-5/


using UnityEngine;
using UnityEngine.SceneManagement;

public class TM_SceneManager : MonoBehaviour {

	public string NextSceneName;

	public void RestartScene()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadSceneName(string name){
		LoadSceneName(name);
	}

	public void LoadSceneInt(int num)
	{
		LoadSceneName(name);
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
