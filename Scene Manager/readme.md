# Restart Scene


	using UnityEngine.SceneManagement;
    
    if (Input.GetKeyDown (KeyCode.R)) {
		Scene scene = SceneManager.GetActiveScene (); 
		SceneManager.LoadScene (scene.name);
	}


## Links
* https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
* https://forum.unity.com/threads/how-to-prevent-a-freeze-in-between-loading-scenes-clicking-windows-false-positive-freeze-err.497083/
