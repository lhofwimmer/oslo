using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class InstantiaBeatmap : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		string beatmapInSystem = "C:\\Users\\User\\Documents\\Schule\\Programmieren\\Unity\\ösly\\ösly_mania\\Assets\\Beatmap\\363184 Spawn of Possession - Apparition\\Spawn of Possession - Apparition (XeoStyle) [Duty to God].osu";
		var bmLines = GetAllFileLinesByType (beatmapInSystem);
		GetComponent<AudioSource> ().Play ();
		DrawBeatmap (bmLines);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public GameObject prefab;
	public void DrawBeatmap (Dictionary<string, List<string>> beatmap)
	{
		GameObject note = Instantiate (prefab) as GameObject;

		var notes = beatmap ["[HitObjects]"];

		foreach (var line in notes)
		{

		}

	}




	public Dictionary<string, List<string>> GetAllFileLinesByType(string source)
	{
		string[] lines = File.ReadAllLines (source);

		var dictionary = new Dictionary<string, List<string>> ();
		string currentKey = "";
		for(int i=0; i<lines.Length;i++)
		{
			


			if(lines[i].Equals(""))
			{
				currentKey = lines[++i];
				if(!dictionary.ContainsKey(currentKey))
				{
					dictionary [currentKey] = new List<string> ();
				}
			}
			else
			{
				if(!dictionary.ContainsKey(currentKey))
				{
					dictionary [currentKey] = new List<string> ();
				}
				dictionary[currentKey].Add(lines[i]);
				Console.WriteLine (lines[i]);
			}

		}
		return dictionary;
	}
}
