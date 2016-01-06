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
        //[HideInInspector]
        public static readonly String MELEE_ATTACK_BUTTON = "MeleeAttack";




        #endregion

        #region Event Handlers

        void Update()
        {
            // If the fire button is pressed...
            if (Input.GetButtonDown(MELEE_ATTACK_BUTTON))
            {

            }
        }
        #endregion
    }
}
