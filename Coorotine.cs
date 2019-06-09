using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
	//https://unity3d.com/pt/learn/tutorials/topics/scripting/coroutines

    IEnumerator iFade()
    {
        for (float i = 0; i < fadeTime; i+= Time.deltaTime )
        {


            yield return null;
        }
    }


	public void HighlightColor (){
		StopCoroutine("IChangeColor");
		StartCoroutine(IChangeColor(0.3f, startColor, changeColor));

		StopCoroutine("IChangePos");
		StartCoroutine(IChangePos(0.3f, startPos, changePos ));
	}

	IEnumerator IChangeColor(float duration, Color color1, Color color2)
	{

		float time = 0;
		while (time / duration < 1)
		{

			img.color = Color.Lerp(color1, color2, time / duration);

			time += Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator IChangePos(float duration, Vector3 pos1, Vector3 pos2)
	{

		float time = 0;
		while (time / duration < 1)
		{

			transform.localPosition = Vector3.Lerp(pos1, pos2, time / duration);

			time += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = pos2;
	}
}
