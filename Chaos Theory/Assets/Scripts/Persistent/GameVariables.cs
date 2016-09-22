using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Collections.Generic;

public class GameVariables : MonoBehaviour 
{
	public static GameVariables gVar;

	public bool newGameGUI = false;
	public bool doubleCheckGUI = false;
	public bool confirmationGUI = false;

	//LoadSaveFiles
	public string saveGameName0;
	public string saveGameName1;
	public string saveGameName2;

	public string timePlayed0;
	public string timePlayed1;
	public string timePlayed2;

	// Load into game after loading file
	public bool loadGame = false;

	// Levels
	// TDL: allow the level to change and make sure the current level is saved
	public string levelName = "Level1";

	// Audio
	// for audio

	// Options
	// By default the tutorial should be on. Allow the player to turn it off and save this option.
	public bool tutorialOn = true;
	// toolTips are inmportant to new players! They should be on automatically, but have the option to turn off. Save the state of the option.
	public bool toolTips = true;

	void Awake ()
	{
		if(gVar == null)
		{
			DontDestroyOnLoad(gameObject);
			gVar = this;
		}
		else if (gVar != this)
		{
			Destroy(gameObject);
		}
	}

	/*
    public string[] ReadDocumentFromFile(string filePath)
    {
        return File.ReadAllLines(filePath);
    }

    private static List<string> ReadSaveInfoFromFile(string filePath)
    {
        // Get rid of previous file
        if (!File.Exists(filePath))
        {
            return null;
        }

        // Read all content into memory as one large string.
        string content = File.ReadAllText(filePath);

        //Process the string only if we have content in it.
        if (content != null
            && content.Trim().Length > 0)
        {
            // Split the string into a string array 
            string[] thisArray = content.Split('\n');
            List<string> sArray = new List<string>();
            sArray.AddRange(thisArray);
            return sArray;
        }

        return null;
    }
    */
}
