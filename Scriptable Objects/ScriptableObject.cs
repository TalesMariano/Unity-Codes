///  References
/// https://docs.unity3d.com/ScriptReference/ScriptableObject.html
/// https://unity3d.com/how-to/architect-with-scriptable-objects
/// https://www.raywenderlich.com/6183-scriptable-objects-tutorial-getting-started
/// https://www.gamasutra.com/blogs/VivekTank/20180716/322124/Create_Scriptable_Objects_with_Unity.php

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/ScriptableObject", order = 1)]
public class ScriptableObject : ScriptableObject
{
	[SerializeField]
	public Client[] users;
}

[System.Serializable]
public class Client
{
  public string nome;
  public string code;
  public bool doneQuiz;
}
