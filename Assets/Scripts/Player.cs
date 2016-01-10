using Assets.Scripts;
using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Main player/ship
/// </summary>
public class Player : MonoBehaviour
{
    #region Properties
    public float MoveSpeed = 4.0f;
    public float JumpSpeed = 50.0f;
    public int Health = 2;

    [HideInInspector]
    public float Gravity;
    [HideInInspector]
    public int Score = 0;

    private bool Dead = false;          // Whether or not the enemy is dead.
    private bool ApplyGravity = true; 
    private int PlayerNumber;
    private Vector2 Velocity;
    #endregion

    #region Static Variables
    /// <summary>
    /// This will clamp only the fall speed of the velocity for each frame.
    /// </summary>
    public static readonly float MAX_FALL_SPEED = -0.7f; 
    #endregion

    #region Event Handlers
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behavior.
    /// </summary>
    public void Update()
    {
        // This is a left handed based coordinate system with Y axis being the world vertical axis. 
        float verticalInput = Input.GetAxisRaw(Constants.VERTICAL_AXIS) * Time.deltaTime;
        float horizontalInput = Input.GetAxisRaw(Constants.HORIZONTAL_AXIS) * Time.deltaTime;

        HandleActionInput(horizontalInput, verticalInput);

        HandleMovement(horizontalInput, verticalInput);


        //// With Absolute Value
        //if (Mathf.Abs(transform.position.x) > 7.0f)
        //{
        //    transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        //}

        //if (Input.GetKeyDown(KeyCode.Space) && Player.Lives > 0)
        //{
        //    Vector3 pos = new Vector3(transform.position.x, transform.position.y + m_StartProjectileHigher, transform.position.z);
        //    Instantiate(ProjectilePrefab, pos, /*transform.rotation*/ Quaternion.identity);
        //    //if (bestScore < Player.Score * Player.Multiplier)
        //    //{
        //    //    bestScore = Player.Score * Player.Multiplier;
        //    //}
        //    Player.Lives--;
        //}
        
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// 
    /// This means that your OnGUI implementation might be called several times per frame (one call per event). 
    /// For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.
    /// </summary>
    public void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 200, 20), "Score: " + Player.Score.ToString() + " x " + Player.Multiplier.ToString());
        //GUI.Label(new Rect(10, 30, 100, 20), "Shots Left: " + Player.Lives.ToString());
        //if (GameOver)
        //{
        //    int temp;
        //    temp = Player.Score * Player.Multiplier;
        //    GUI.Label(new Rect(100, 100, 100, 20), "Total: " + temp.ToString());

        //}
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter()");
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        // If the colliding gameobject is an Enemy...
        if (col.gameObject.tag.Equals("REPLACE THIS"))
        {
            // ... and if the time exceeds the time of the last hit plus the time between hits...
            //if (Time.time > lastHitTime + repeatDamagePeriod)
            //{
            //    // ... and if the player still has health...
            //    if (health > 0f)
            //    {
            //        // ... take damage and reset the lastHitTime.
            //        TakeDamage(col.transform);
            //        lastHitTime = Time.time;
            //    }
            //    // If the player doesn't have health, do some stuff, let him fall into the river to reload the level.
            //    else
            //    {
            //        // Find all of the colliders on the gameobject and set them all to be triggers.
            //        Collider2D[] cols = GetComponents<Collider2D>();
            //        foreach (Collider2D c in cols)
            //        {
            //            c.isTrigger = true;
            //        }

            //        // Move all sprite parts of the player to the front
            //        SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
            //        foreach (SpriteRenderer s in spr)
            //        {
            //            s.sortingLayerName = "UI";
            //        }

            //        // ... disable user Player Control script
            //        GetComponent<PlayerControl>().enabled = false;

            //        // ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
            //        GetComponentInChildren<Gun>().enabled = false;

            //        // ... Trigger the 'Die' animation state
            //        anim.SetTrigger("Die");
            //    }
            //}
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// This message is sent to the trigger collider and the rigidbody (or the collider if there is no rigidbody) that touches the trigger.
    /// Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
    /// </summary>
    /// <param name="otherObj"></param>
    public void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.tag.Equals(Constants.PLATFORM_TAG, StringComparison.OrdinalIgnoreCase))
        {
            Velocity.y = 0.0f;
            ApplyGravity = false;
        }
        //Debug.Log("Collision hit enemy" + otherObj.name);
        //if (otherObj.tag.Equals(Constants.ENEMY_TAG, System.StringComparison.OrdinalIgnoreCase)) // this is the tag in the top left of the inspector
        //{
        //    Player.Lives--;
        //    Enemy enemy = otherObj.GetComponent<Enemy>();
        //    enemy.SetRandomStartLoc();
        //    StartCoroutine(DestroyShip());
        //}
    }

    /// <summary>
    /// Tune these to get around using the editor
    /// </summary>
    public void Awake()
    {
        Health = 2;
        Score = 0;
        Dead = false;
        MoveSpeed = 16.0f;
        Gravity = 3.0f;
        JumpSpeed = 1.0f;
        Velocity = new Vector2(0.0f, 0.0f);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Handle initializing game play mechanics. EX: check if attacking has been inputted. 
    /// </summary>
    private void HandleActionInput(float horizontalInput, float verticalInput)
    {
        HandleMeleeAttack(horizontalInput, verticalInput);
        HandleRangedAttack(horizontalInput, verticalInput);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="horizontalInput"></param>
    /// <param name="verticalInput"></param>
    private void HandleMeleeAttack(float horizontalInput, float verticalInput)
    {
        if (Input.GetButtonDown(Constants.MELEE_ATTACK_BUTTON_NAME))
        {
            Debug.LogFormat("Melee attack triggered. ({0}, {1})", horizontalInput, verticalInput);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="horizontalInput"></param>
    /// <param name="verticalInput"></param>
    private void HandleRangedAttack(float horizontalInput, float verticalInput)
    {
        if (Input.GetButtonDown(Constants.RANGED_ATTACK_BUTTON_NAME))
        {
            Debug.LogFormat("Ranged attack triggered. ({0}, {1})", horizontalInput, verticalInput);
        }
    }

    /// <summary>
    /// Handling all movement based inputs.
    /// </summary>
    private void HandleMovement(float horizontalInput, float verticalInput)
    {
        ApplyConstantForces();

        if (Input.GetButtonDown(Constants.JUMP_KEY))
        {
            Debug.LogFormat("Jump triggered. ({0}, {1})", horizontalInput, verticalInput);
            Velocity.y = JumpSpeed;
            ApplyGravity = true;
        }
        float horizontalTranslationCoef = horizontalInput * MoveSpeed;
        Velocity.x = horizontalTranslationCoef;
        Velocity.y = Velocity.y < MAX_FALL_SPEED ? MAX_FALL_SPEED : Velocity.y;
        transform.Translate(Velocity.x, Velocity.y, 0.0f);
    }

    /// <summary>
    /// Apply all of gravity and constant 
    /// </summary>
    private void ApplyConstantForces()
    {
        if (ApplyGravity)
        {
            float gravityTranslationCoef = Gravity * Time.deltaTime;
            Velocity.y -= gravityTranslationCoef;
        }
    }

    /// <summary>
    /// Try to destroy the ship/character. This game is backwards and that the player wins if the player is able to get to 0 ammo. 
    /// </summary>
    /// <returns></returns>
    //IEnumerator DestroyShip()
    //{
    //    Instantiate(ExplosionPrefab, transform.position, transform.rotation);
    //    gameObject.GetComponent<Renderer>().enabled = false;
    //    transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    //    yield return new WaitForSeconds(1.5f);
    //    if (Player.Lives > 0)
    //    {
    //        gameObject.GetComponent<Renderer>().enabled = true;
    //    }
    //    else
    //    {
    //        UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.LEVEL_NAME_WIN);
    //    }
    //}
    #endregion
}