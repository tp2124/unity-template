using Assets.Scripts;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    /// <summary>
    /// Handles melee attack input
    /// </summary>
    public class MeleeAttack : MonoBehaviour
    {
        #region Properties
        #endregion

        #region Event Handlers

        void Update()
        {
            // If the fire button is pressed...
            if (Input.GetButtonDown(Constants.MELEE_ATTACK_BUTTON_NAME))
            {

            }
        }
        #endregion
    }
}
