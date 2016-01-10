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
        public static readonly String WEAPON_TAG = "WEAPON";
        public static readonly String PLAYER_TAG = "PLAYER";
        public static readonly String PLATFORM_TAG = "PLATFORM";

        public static readonly String LEVEL_NAME_MAIN_MENU = "MainMenu";
        public static readonly String LEVEL_NAME_LEVEL_1 = "Level1";
        public static readonly String LEVEL_NAME_WIN = "Win";
        public static readonly String LEVEL_NAME_LOSE = "Lose";
        #endregion

        #region Input Values
        public static readonly String JUMP_KEY = "Jump";
        public static readonly String HORIZONTAL_AXIS = "Horizontal";
        public static readonly String VERTICAL_AXIS = "Vertical";
        public static readonly String MELEE_ATTACK_BUTTON_NAME = "MeleeAttack";
        public static readonly String RANGED_ATTACK_BUTTON_NAME = "RangedAttack";
        #endregion
        #endregion
    }
}
