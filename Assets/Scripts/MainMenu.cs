using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region Fields

    public Texture backgroundTexture;

    private string instructionText = "Welcome to Unity ITP 280\nBrought to you by Your Great Instructors";
    private int buttonWidth = 100;
    private int buttonHeight = 50;
    
    #endregion


    #region Functions
    
    void OnGUI() {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        //This makes a button to start the game
        GUI.Label(new Rect(Screen.width / 2 - 100, 20, 200, 200), instructionText);
        if (GUI.Button(new Rect((Screen.width-buttonWidth) / 2, (Screen.height-buttonHeight) / 2, buttonWidth, buttonHeight), "Play!")) {
            Application.LoadLevel(3);
        }
    }

    #endregion


}