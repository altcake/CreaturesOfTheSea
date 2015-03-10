using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	private GUISkin skin;

	void Start() {
		// Load a skin for the buttons.
		skin = Resources.Load ("GUISkin") as GUISkin;
	}

	void OnGUI() {
		const int buttonWidth = 128;
		const int buttonHeight = 60;

		// Set the skin to use.
		GUI.skin = skin;

		// Draw a button to start the game.
		if (GUI.Button (
			// Center in X, 2/3 of the height in Y.
			new Rect (
				3 * (Screen.width / 4) - (buttonWidth / 2),
				Screen.height / 3 - (buttonHeight / 2),
				buttonWidth,
				buttonHeight),
			"START")) {
			// On click, load the first level.
			Application.LoadLevel ("Level_01"); // "Shooter" is the scene name.
		}
	}
}
