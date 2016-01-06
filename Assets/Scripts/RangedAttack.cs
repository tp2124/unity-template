using Assets.Scripts;
using UnityEngine;
using System;

namespace Assets.Scripts
{
    /// <summary>
    /// Hnadles melee attack input
    /// </summary>
    public class RangedAttack : MonoBehaviour
    {
        #region Properties
        //[HideInInspector]
        public static readonly String RANGED_ATTACK_BUTTON = "RangedAttack";

        public Rigidbody2D m_Projectile;
        #endregion
        #region Event Handlers
        void Update()
        {
            // If the fire button is pressed...
            if (Input.GetButtonDown(RANGED_ATTACK_BUTTON))
            {

            }
        }
        #endregion
    }
}
