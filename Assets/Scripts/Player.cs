using Assets.Scripts;
using System.Collections;
using UnityEngine;

/// <summary>
/// Main player/ship
/// </summary>
public class Player : MonoBehaviour
{
    #region Properties
    public float MoveSpeed = 4.0f;
    public float Gravity = 1.75f;
    public int Score = 0;
    public int Health = 2;

    private bool Dead = false;          // Whether or not the enemy is dead.
    private int PlayerNumber;
    #endregion

    #region Event Handlers
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behaviour.
    /// </summary>
    public void Update()
    {
        ApplyGravity();

        Vector3 inputTranslation;
        float verticalTranslationCoef = Input.GetAxisRaw(Constants.VERTICAL_AXIS) * MoveSpeed * Time.deltaTime;
        float horizontalTranslationCoef = Input.GetAxisRaw(Constants.HORIZONTAL_AXIS) * MoveSpeed * Time.deltaTime;
        inputTranslation = Vector3.up * verticalTranslationCoef;
        inputTranslation += Vector3.right * horizontalTranslationCoef;
        //transform.Translate(Vector3.left * amtToMove);
        transform.Translate(inputTranslation, Space.World);


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
        Gravity = 0.0f;
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
    /// 
    /// </summary>
    public void Awake()
    {
        Health = 2;
        Score = 0;
        Dead = false;
        MoveSpeed = 4.0f;
    }
    #endregion

    #region Private Methods
    private void ApplyGravity()
    {
        if (Gravity != 0.0f)
        {
            float gravityTranslationCoef = Gravity * Time.deltaTime;
            transform.Translate(Vector3.down * gravityTranslationCoef);
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