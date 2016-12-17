using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	https://docs.unity3d.com/ScriptReference/RequireComponent.html
// PlayerScript requires the GameObject to have a Rigidbody component
[RequireComponent (typeof (Rigidbody))]

//	https://docs.unity3d.com/ScriptReference/SelectionBaseAttribute.html
[SelectionBase]
public class Attributes : MonoBehaviour {

	[Tooltip("Health value between 0 and 100.")]
	public int health2 = 0;

	[HideInInspector]
	public int p = 5;

	[TextArea]
	public string MyTextArea;

	//	https://docs.unity3d.com/ScriptReference/SerializeField.html
	//This field gets serialized even though it is private
	//because it has the SerializeField attribute applied.
	[SerializeField]
	private bool hasHealthPotion = true;


	//	https://docs.unity3d.com/ScriptReference/RangeAttribute.html
	[Range (0,1)]
	public int binary;

	//	https://docs.unity3d.com/ScriptReference/PropertyAttribute-order.html
	[Space (10, order=0)]
	[Header ("Header with some space around it", order=1)]
	[Space (40, order=2)]

	public string playerName = "Unnamed";

	//	https://docs.unity3d.com/ScriptReference/HeaderAttribute.html
	[Header("Health Settings")]
	public int health = 0;
	public int maxHealth = 100;
	[Header("Shield Settings")]
	public int shield = 0;
	public int maxShield = 0;

	//	https://docs.unity3d.com/ScriptReference/ContextMenu.html
	/// Add a context menu named "Do Something" in the inspector
	/// of the attached script.
	[ContextMenu ("Do Something")]
	void DoSomething () {
		Debug.Log ("Perform operation");
	}


	// 	https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html
	[ExecuteInEditMode]
	//public class ExampleClass : MonoBehaviour {
		public Transform target;
		void Update() {
			if (target)
				transform.LookAt(target);

		}
	//}

}
