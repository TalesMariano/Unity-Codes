using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
