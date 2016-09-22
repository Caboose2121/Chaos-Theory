using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GUINav : MonoBehaviour
{
	// loader https://www.youtube.com/watch?v=oNf3gdjiEEQ

	public GameObject MainGUI;
	public GameObject MainMenuGUI;
	public GameObject PauseGUI;
	public GameObject OptionsGUI;
	public GameObject LoadGUI;
	public GameObject SaveGUI;
	public GameObject NewGameGUI;
	public GameObject DoubleCheckGUI;
	public GameObject ConfirmationGUI;
	public GameObject LoaderScreenGUI;
	public GameObject CreditsGUI;

	private AsyncOperation ao;

	private int saveNum = 0;

	public AudioSource pauseOpen;
	public AudioSource pauseClose;

	void Update()
	{
		if (Enums.currEnum == Enums.enumVars.Menu)
		{
			if (MainGUI.activeSelf == true)
			{
				MainGUI.SetActive(false);
			}

			if (MainMenuGUI.activeSelf == false)
			{
				MainMenuGUI.SetActive(true);
			}
			return;
		}

		if (Enums.currEnum == Enums.enumVars.Load)
		{
			if (LoadGUI.activeSelf == false)
			{
				LoadGUI.SetActive(true);
			}

			if (GameVariables.gVar.newGameGUI == true)
			{
				NewGameGUI.SetActive(true);
			}

			if (GameVariables.gVar.loadGame == true)
			{
				ContinueGame();
			}
		}

		if (Enums.currEnum == Enums.enumVars.Save)
		{
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(false);
			LoadGUI.SetActive(false);
			MainMenuGUI.SetActive(false);
			NewGameGUI.SetActive(false);
			LoaderScreenGUI.SetActive(false);
			CreditsGUI.SetActive(false);
			MainGUI.SetActive(false);

			if (SaveGUI.activeSelf == false)
			{
				SaveGUI.SetActive(true);
			}

			if (GameVariables.gVar.doubleCheckGUI == true)
			{
				DoubleCheckGUI.SetActive(true);
			}

			if (GameVariables.gVar.confirmationGUI == true)
			{
				ConfirmationGUI.SetActive(true);
			}
		}

		if (Enums.currEnum == Enums.enumVars.Play)
		{
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(false);
			LoadGUI.SetActive(false);
			SaveGUI.SetActive(false);
			MainMenuGUI.SetActive(false);
			NewGameGUI.SetActive(false);
			LoaderScreenGUI.SetActive(false);
			CreditsGUI.SetActive(false);

			MainGUI.SetActive(true);

			if (Input.GetKeyDown(KeyCode.Return))
			{
				pauseOpen.Play();
				Enums.preEnum = Enums.currEnum;
				Enums.currEnum = Enums.enumVars.Pause;
				MainGUI.SetActive(false);
				PauseGUI.SetActive(true);
			}
		}

		if (Enums.currEnum == Enums.enumVars.Credits)
		{
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(false);
			LoadGUI.SetActive(false);
			SaveGUI.SetActive(false);
			MainMenuGUI.SetActive(false);
			NewGameGUI.SetActive(false);
			LoaderScreenGUI.SetActive(false);
			MainGUI.SetActive(false);

			CreditsGUI.SetActive(true);
		}

		if (Enums.currEnum == Enums.enumVars.Loader)
		{
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(false);
			LoadGUI.SetActive(false);
			SaveGUI.SetActive(false);
			MainMenuGUI.SetActive(false);
			NewGameGUI.SetActive(false);
			MainGUI.SetActive(false);
			CreditsGUI.SetActive(false);

			LoaderScreenGUI.SetActive(true);
		}
	}

	public void MenuNav(string selected)
	{
		//Resume
		if (selected == "Resume")
		{
			if (Enums.currEnum == Enums.enumVars.Pause)
			{
				PauseGUI.SetActive(false);
				pauseClose.Play();
			}

			if (Enums.currEnum == Enums.enumVars.Options)
			{
				OptionsGUI.SetActive(false);
			}

			if (Enums.currEnum == Enums.enumVars.Load)
			{
				LoadGUI.SetActive(false);
			}

			Enums.preEnum = Enums.currEnum;
			Enums.currEnum = Enums.enumVars.Play;
			MainGUI.SetActive(true);
			return;
		}

		//Options
		if (selected == "Options")
		{
			Enums.preEnum = Enums.currEnum;
			Enums.currEnum = Enums.enumVars.Options;
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(true);
			return;
		}

		if (selected == "Quit")
		{
			Application.Quit();
		}

		if (selected == "Play")
		{
			MainMenuGUI.SetActive(false);
			Enums.preEnum = Enums.currEnum;
			Enums.currEnum = Enums.enumVars.Load;
			SceneManager.LoadScene("LoadGame");
		}

		if (selected == "Back")
		{
			LoadGUI.SetActive(false);

			if (Enums.preEnum == Enums.enumVars.Menu)
			{
				Enums.preEnum = Enums.currEnum;
				Enums.currEnum = Enums.enumVars.Menu;
				SceneManager.LoadScene("MainMenu");
			}

			else if (Enums.preEnum == Enums.enumVars.Pause)
			{
				Enums.preEnum = Enums.currEnum;
				Enums.currEnum = Enums.enumVars.Pause;
				LoadGUI.SetActive(false);
				PauseGUI.SetActive(true);
			}

			else //(Enums.preEnum == Enums.enumVars.Play)
			{
				Enums.preEnum = Enums.currEnum;
				Enums.currEnum = Enums.enumVars.Play;
				SaveGUI.SetActive(false);
				MainGUI.SetActive(true);
			}
		}

		if (selected == "New Game")
		{
			GameVariables.gVar.newGameGUI = false;
			NewGameGUI.SetActive(false);
			LoadGUI.SetActive(false);
			NewGameReset();
		}

		if (selected == "Close")
		{
			GameVariables.gVar.newGameGUI = false;
			NewGameGUI.SetActive(false);
		}

		if (selected == "Return")
		{
			PauseGUI.SetActive(false);
			OptionsGUI.SetActive(false);
			LoadGUI.SetActive(false);
			SaveGUI.SetActive(false);
			NewGameGUI.SetActive(false);
			LoaderScreenGUI.SetActive(false);
			CreditsGUI.SetActive(false);
			MainGUI.SetActive(false);

			MainMenuGUI.SetActive(true);

			Enums.preEnum = Enums.currEnum;
			Enums.currEnum = Enums.enumVars.Menu;
		}

		if (selected == "CancelSave")
		{
			GameVariables.gVar.doubleCheckGUI = false;
			DoubleCheckGUI.SetActive(false);
		}


		if (selected == "SaveGame")
		{
			GameVariables.gVar.doubleCheckGUI = false;
			GameControl.control.Save(saveNum);
			DoubleCheckGUI.SetActive(false);
			ConfirmationGUI.SetActive(true);
		}

		if (selected == "Confirm")
		{
			GameVariables.gVar.confirmationGUI = false;
			ConfirmationGUI.SetActive(false);
			// make the saveGUI reload
			SaveGUI.SetActive(false);
		}

		if (selected == "Save0")
		{
			saveNum = 0;
			DoubleCheckGUI.SetActive(true);
		}

		if (selected == "Save1")
		{
			saveNum = 1;
			DoubleCheckGUI.SetActive(true);
		}

		if (selected == "Save2")
		{
			saveNum = 2;
			DoubleCheckGUI.SetActive(true);
		}

		if (selected == "Load")
		{
			Enums.preEnum = Enums.currEnum;
			Enums.currEnum = Enums.enumVars.Load;
			PauseGUI.SetActive(false);
		}
	}

	public void NewGameReset()
	{
		//reset game
		//Enums.currEnum = Enums.enumVars.Loader;
		//LoaderScreenGUI.SetActive(true);
		Enums.preEnum = Enums.currEnum;
		Enums.currEnum = Enums.enumVars.Loader;
		//LoaderScreenGUI.SetActive(true);

		SceneManager.LoadScene("Loader");
	}

	public void ContinueGame()
	{
		Enums.preEnum = Enums.currEnum;
		Enums.currEnum = Enums.enumVars.Loader;

		SceneManager.LoadScene("Loader");
	}
}