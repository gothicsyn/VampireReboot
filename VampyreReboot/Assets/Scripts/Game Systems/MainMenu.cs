using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public string Version;			// The games Version Number
	public Canvas quitMenu;			// Call the Quit Menu Canvas
	public Button startText;		// Call The Game Start
	public Button loadText;			// Call The load System
	public Button optionText;		// Call The Options System
	public Button exitText;			// Calls the Quit System

	//Values used for placing version number in inspector
	public int width1 = 50;
	public int height1 = 200;
	public int offset1 = 350;
	public int pos1 = 10;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		quitMenu.enabled = false;
	}

	// Uses the Old GUI system to display a simple Text String
	void onGUI () {
		displayVersion ();
	}

	// Brings Up The Exit Game System
	public void ExitPress () {
		quitMenu.enabled = true;
		startText.enabled = false;
		loadText.enabled = false;
		optionText.enabled = false;
		exitText.enabled = false;
	}

	// Cancels The Exit Game System
	public void NoPress () {
		quitMenu.enabled = false;
		startText.enabled = true;
		loadText.enabled = true;
		optionText.enabled = true;
		exitText.enabled = true;
	}

	// Starts The Game
	public void StartGame () {
		SceneManager.LoadScene ("Dentarius");
	}

	// Exits The Game
	public void QuitGame () {
		Application.Quit ();
	}

	// Handles displaying the Version Number for testing and build version purposes.
	public void displayVersion (){
		GUI.contentColor = Color.yellow;
		GUI.Label(new Rect(pos1, Screen.height / 2 - offset1, width1, height1), "Version " + Version);
	}
}
