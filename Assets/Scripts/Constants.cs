using System;

namespace Assets.Scripts
{
    /// <summary>
    /// Static class to hold static definitions to be used by scripts
    /// </summary>
    public static class Constants
    {
        #region Properties
        #region Game Specific
        public static readonly String ENEMY_TAG = "enemy";

        public static readonly String LEVEL_NAME_MAIN_MENU = "MainMenu";
        public static readonly String LEVEL_NAME_LEVEL_1 = "Level1";
        public static readonly String LEVEL_NAME_WIN = "Win";
        public static readonly String LEVEL_NAME_LOSE = "Lose";
        #endregion

        #region Unity Parsed Values
        public static readonly String SPACE_KEY = "space";
        public static readonly String HORIZONTAL_AXIS = "Horizontal";
        #endregion
        #endregion
    }
}
