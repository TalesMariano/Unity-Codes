using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Analise : MonoBehaviour {

	DirectoryInfo dir;
	FileInfo[] info; 
  
  public Text pathText;
	string path;
  
  void Start () {

		path = (Application.dataPath + "/Result/");
		pathText.text = "Diretorio dos Resultados: " + path;
    
    System.IO.Directory.CreateDirectory(Application.dataPath + "/Quiz_txt/");
    dir = new DirectoryInfo(Application.dataPath + "/Quiz_txt/");
    //print(File.Exists(Application.persistentDataPath + "/" + sName + ".txt"));

    info = dir.GetFiles("*.txt");
    
		foreach (FileInfo f in info){
			string[] lines = System.IO.File.ReadAllLines(f.FullName);

			ListSorter(ParseString(lines[0]));
			///List<Person> SortedList = people.OrderBy(o=>o.Age).ToList();
		}
		quiz1 = quiz1.OrderByDescending(o => o.sortvalue).ToList();
    //string[] split = s.Split(';');
  
  }

	void WriteTxt(string text, string title){

		System.IO.Directory.CreateDirectory(path);

		StreamWriter writer = new StreamWriter(path + title + ".txt");

		writer.Write(text);

		writer.Close();
	}
  
  	public void WriteTxt(int perguntasCertas, int perguntas, float durationQuiz){

		//print(Application.persistentDataPath);

		
		DateTime localDate = DateTime.Now;
		theText += "\r\n\r\nFim das Perguntas: " + localDate.ToString();

		StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/" + saveName +  ".txt"); //new StreamWriter("MyPath.txt", true);
																											 //print(Application.persistentDataPath + "/" + saveName + ".txt");

		firstTime += ("\r\nAcertou " + perguntasCertas + " de " + perguntas);

		firstTime += ("\r\nTempo em segundos: " + durationQuiz + "\r\n");

		FillUser(perguntasCertas, perguntas, durationQuiz, localDate.ToString());

		string textWrite = WriteAnailisisCode();

		textWrite += "\r\n\r\n";

		writer.Write(textWrite);

		writer.Write(firstTime);

		writer.Write(theText);

		writer.Close();
	  }
  
  }
