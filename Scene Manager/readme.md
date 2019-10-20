# Restart Scene


	using UnityEngine.SceneManagement;
    
    if (Input.GetKeyDown (KeyCode.R)) {
		Scene scene = SceneManager.GetActiveScene (); 
		SceneManager.LoadScene (scene.name);
	}


## Links
* https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
