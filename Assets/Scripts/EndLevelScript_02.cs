﻿using UnityEngine;
using System.Collections;

public class EndLevelScript_02 : MonoBehaviour
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
            "Retry!"
        ))
        {
            // Reload the level.
            Application.LoadLevel("Level_Boss");
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
