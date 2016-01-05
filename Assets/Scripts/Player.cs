using Assets.Scripts;
using System.Collections;
using UnityEngine;

/// <summary>
/// Main player/ship
/// </summary>
public class Player : MonoBehaviour
{
    #region Properties
    public static float PlayerSpeed = 4.0f;
    public GameObject ProjectilePrefab;
    public GameObject ExplosionPrefab;
    public static int Score = 0;
    public static int Lives = 3;
    public static int Missed = 0;
    public static bool GameOver = false;
    public static int Multiplier = 0;

    //private int m_BestScore = 0;
    private float m_StartProjectileHigher = 2.3f;
    #endregion

    #region Event Handlers
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behaviour.
    /// </summary>
    void Update()
    {
        float amtToMove = Input.GetAxisRaw(Constants.HORIZONTAL_AXIS) * PlayerSpeed * Time.deltaTime;
        //  More flowy of movement    
        //float amtToMove = Input.GetAxis("Horizontal")*PlayerSpeed * Time.deltaTime;

        //Translating
        transform.Translate(Vector3.right * amtToMove);

        // With Absolute Value
        if (Mathf.Abs(transform.position.x) > 7.0f)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        ////Without Absolute Value
        //if (transform.position.x <= -7.5f) {
        //    transform.position = new Vector3(7.5f, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x >= 7.5f) {
        //    transform.position = new Vector3(-7.5f, transform.position.y, transform.position.z);
        //}

        if (Input.GetKeyDown(Constants.SPACE_KEY) && Player.Lives > 0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + m_StartProjectileHigher, transform.position.z);
            Instantiate(ProjectilePrefab, pos, /*transform.rotation*/ Quaternion.identity);
            //if (bestScore < Player.Score * Player.Multiplier)
            //{
            //    bestScore = Player.Score * Player.Multiplier;
            //}
            Player.Lives--;
        }
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// 
    /// This means that your OnGUI implementation might be called several times per frame (one call per event). 
    /// For more information on GUI events see the Event reference. If the MonoBehaviour's enabled property is set to false, OnGUI() will not be called.
    /// </summary>
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Score: " + Player.Score.ToString() + " x " + Player.Multiplier.ToString());
        GUI.Label(new Rect(10, 30, 100, 20), "Shots Left: " + Player.Lives.ToString());
        //GUI.Label(new Rect(100, 100, 100, 20), "Best Shot: " + bestScore.ToString());
        if (GameOver)
        {
            int temp;
            temp = Player.Score * Player.Multiplier;
            GUI.Label(new Rect(100, 100, 100, 20), "Total: " + temp.ToString());

        }
        //GUI.Label(new Rect(10, 50, 60, 20), "Missed: " + Player.Missed.ToString());
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// This message is sent to the trigger collider and the rigidbody (or the collider if there is no rigidbody) that touches the trigger.
    /// Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
    /// </summary>
    /// <param name="otherObj"></param>
    void OnTriggerEnter(Collider otherObj)
    {
        //Debug.Log("Collision hit enemy" + otherObj.name);
        if (otherObj.tag.Equals(Constants.ENEMY_TAG, System.StringComparison.OrdinalIgnoreCase)) // this is the tag in the top left of the inspector
        {
            Player.Lives--;
            Enemy enemy = otherObj.GetComponent<Enemy>();
            enemy.SetRandomStartLoc();
            StartCoroutine(DestroyShip());
        }
    }
    #endregion

    #region Static Functions
    /// <summary>
    /// 
    /// </summary>
    public static void ResetStats()
    {
        Player.Lives = 3;
        Player.Score = 0;
        Player.Missed = 0;
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Try to destroy the ship/character. This game is backwards and that the player wins if the player is able to get to 0 ammo. 
    /// </summary>
    /// <returns></returns>
    IEnumerator DestroyShip()
    {
        Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        gameObject.GetComponent<Renderer>().enabled = false;
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(1.5f);
        if (Player.Lives > 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.LEVEL_NAME_WIN);
        }
    }
    #endregion
}