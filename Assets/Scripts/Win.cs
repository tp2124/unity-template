using Assets.Scripts;
using UnityEngine;

/// <summary>
/// Win Splash screen
/// </summary>
public class Win : MonoBehaviour
{
    #region Fields
    public Texture BackgroundTexture;
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
        GUI.Label(new Rect((Screen.width - ButtonWidth) / 2, (Screen.height - ButtonHeight) / 2, ButtonWidth, ButtonHeight), "You Won!\nPress any key Play Again");
        if (Input.anyKeyDown)
        {
            Player.ResetStats();
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.LEVEL_NAME_MAIN_MENU);
        }
    }
    #endregion


}