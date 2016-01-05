using UnityEngine;
using System.Collections;

/// <summary>
/// Lose Splash screen
/// </summary>
public class Lose : MonoBehaviour
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
        GUI.Label(new Rect((Screen.width - ButtonWidth) / 2, (Screen.height - ButtonHeight) / 2, ButtonWidth, ButtonHeight), "Game Over\nPress any key Play Again");
        if(Input.anyKeyDown){
            Player.ResetStats();
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
    }
    #endregion


}