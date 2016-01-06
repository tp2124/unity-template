using Assets.Scripts;
using UnityEngine;
using System;

/// <summary>
/// Main Menu UI
/// </summary>
public class MainMenu : MonoBehaviour
{
    #region Fields
    public Texture BackgroundTexture;

    private String InstructionText = "Instructions:\nPress A/Left and D/Right to move\n Press Spacebar to fire\n\nGo for a high score, but make sure you get to see your score totalled\n\n Be careful with your shots. You only have 3.\n\n Press any key to continue (\"preferably not space\")";
    private int ButtonWidth = 200;
    private int ButtonHeight = 50;
    #endregion


    #region Event Handlers
    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// 
    /// This means that your OnGUI implementation might be called several times per frame (one call per event). 
    /// For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.
    /// </summary>
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BackgroundTexture);
        //This makes a button to start the game
        GUI.Label(new Rect(10, 10, ButtonWidth, ButtonHeight), InstructionText);
        if (Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.LEVEL_NAME_LEVEL_1);
        }
    }
    #endregion

}