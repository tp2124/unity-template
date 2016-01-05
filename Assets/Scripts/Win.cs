using UnityEngine;
using System.Collections;

/// <summary>
/// Win Splash screen
/// </summary>
public class Win : MonoBehaviour
{
    #region Fields
    public Texture backgroundTexture;
    private int buttonWidth = 200;
    private int buttonHeight = 50;

    #endregion


    #region Functions
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        GUI.Label(new Rect((Screen.width - buttonWidth) / 2, (Screen.height - buttonHeight) / 2, buttonWidth, buttonHeight), "You Won!\nPress any key Play Again");
        if (Input.anyKeyDown)
        {
            Player.ResetStats();
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
    #endregion


}