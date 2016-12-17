using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersnMore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Zombie") {


		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Zombie") {


		}

	}
}
