using UnityEngine;
using UnityEngine.SceneManagement;

public class TM_SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
