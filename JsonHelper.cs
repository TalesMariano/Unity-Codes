//Based on this question
//https://answers.unity.com/questions/1123326/jsonutility-array-not-supported.html
using UnityEngine;

public class JsonHelper
{
	//Usage:
	//YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);
	public static T[] getJsonArray<T>(string json)
	{
		string newJson = "{ \"array\": " + json + "}";
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
		return wrapper.array;
	}

	public static string arrayToJson<T>(T[] array)
	{
		Wrapper<T> wrapper = new Wrapper<T> { array = array };
		string json = JsonUtility.ToJson(wrapper);
		var pos = json.IndexOf(":");
		json = json.Substring(pos + 1); // cut away "{ \"array\":"
		pos = json.LastIndexOf('}');
		json = json.Substring(0, pos - 1); // cut away "}" at the end
		json += "]";
		return json;
	}


	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] array;
	}

	private void How2Use(){
		string json = JsonHelper.arrayToJson(new int[] { 1, 2, 3, 42 });
		// --> "[1, 2, 3, 42]"
		// and the reverse:
		int[] numbers = JsonHelper.getJsonArray<int>(json);

		//code text
		string json2 = "[{ 'question':'qwe','awnserNumber':2,'answer':['qwe','rqw'] },{'question':'wer','awnserNumber':1,'answer':['ert','dgf','asdf','asdf']}]";

		//original text
		//	[{"question":"qwe","awnserNumber":2,"answer":["qwe","rqw"]},{"question":"wer","awnserNumber":1,"answer":["ert","dgf","asdf","asdf"]}]

		Question[] Qs = JsonHelper.getJsonArray<Question>(json2);

	}

	//Just for example
	[System.Serializable]
	private class Question
	{
		public string question;
		public int awnserNumber;
		public string[] answer;
	}
}
