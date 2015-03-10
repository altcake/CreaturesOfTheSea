using UnityEngine;
using System.Collections;

public class EndLevelScript_01 : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 120;
        const int buttonHeight = 60;

        if (GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (1 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
            ),
            "Onwards to Level 2!"
        ))
        {
            // Reload the level.
            Application.LoadLevel("Level_02");
        }

        if (GUI.Button(
            new Rect(
                Screen.width / 2 - (buttonWidth / 2),
                (2 * Screen.height / 3) - (buttonHeight / 2),
                buttonWidth,
                buttonHeight
            ),
            "Back to Menu"
        ))
        {
            // Reload the level.
            Application.LoadLevel("Menu");
        }
    }
}
