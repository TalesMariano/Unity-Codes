using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
	
	[Header ("Audio")]
	public AudioClip[] monsterNoises;
	protected AudioSource aSource;
	[Range (0,1)]
	public float pitchChange = 0.1f;
	public float criesPerSecond = 0.5f;
	float soundStep = 0;
	
  void PlayList(AudioSource aSource, AudioClip[] aList, float pitchChange){
		
		aSource.pitch = Random.Range (1 - pitchChange / 2, 1 + pitchChange / 2);
		int rand = Random.Range (0, aList.Length);
		aSource.PlayOneShot ( aList[rand]);

	}
	
}
