using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour 
{
	//https://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/persistence-data-saving-loading

	public static GameControl control;

	void Awake () 
	{
		if (control == null) 
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}

		else if (control != this)
		{
			Destroy(gameObject);
		}
	}

	public void Save(int saveNum)
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo" + saveNum.ToString() + ".dat");

		PlayerData data = new PlayerData ();

		//data.levelName = GameVariables.gVar.levelName;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(int loadNum)
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo" + loadNum.ToString() + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo" + loadNum.ToString() + ".dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			//GameVariables.gVar.levelName = data.levelName;
			GameVariables.gVar.loadGame = true;
		}

		else
		{
			Debug.Log("File did not exist");
			GameVariables.gVar.newGameGUI = true;
		}
	}

	// Save/Load files themselves
	public void SaveFileInfo(int saveNum)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/saveLoadInfo" + saveNum.ToString() + ".dat");

		PlayerData data = new PlayerData();

		data.saveGameName0 = GameVariables.gVar.saveGameName0;
		data.saveGameName1 = GameVariables.gVar.saveGameName1;
		data.saveGameName2 = GameVariables.gVar.saveGameName2;

		data.timePlayed0 = GameVariables.gVar.timePlayed0;
		data.timePlayed1 = GameVariables.gVar.timePlayed1;
		data.timePlayed2 = GameVariables.gVar.timePlayed2;

		bf.Serialize(file, data);
		file.Close();
	}

	public void LoadFileInfo(int loadNum)
	{
		if (File.Exists(Application.persistentDataPath + "/saveLoadInfo" + loadNum.ToString() + ".dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			GameVariables.gVar.saveGameName0 = data.saveGameName0;
			GameVariables.gVar.saveGameName1 = data.saveGameName1;
			GameVariables.gVar.saveGameName2 = data.saveGameName2;

			GameVariables.gVar.timePlayed0 = data.timePlayed0;
			GameVariables.gVar.timePlayed1 = data.timePlayed1;
			GameVariables.gVar.timePlayed2 = data.timePlayed2;
		}

		else
		{
			Debug.Log("Load file did not exist");
			//GameVariables.gVar.newGameGUI = true;
		}
	}
}

[Serializable]
class PlayerData
{
	public string saveGameName0;
	public string saveGameName1;
	public string saveGameName2;

	public string timePlayed0;
	public string timePlayed1;
	public string timePlayed2;
}