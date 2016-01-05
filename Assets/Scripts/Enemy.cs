using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class Enemy : MonoBehaviour
{
    #region Properties
    public float MinSpeed;
    public float MaxSpeed;
    public GameObject ProjectilePrefab1;
    public GameObject ProjectilePrefab2;

    private float m_CurSpeed;
    private float m_StartX;
    private float m_StartY;
    private float m_StartZ;
    private bool m_SpawnSide;
    #endregion

    #region Event Handlers
    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    /// 
    /// Like the Awake function, Start is called exactly once in the lifetime of the script. 
    /// However, Awake is called when the script object is initialised, regardless of whether or not the script is enabled. Start may not be called on the same frame as Awake if the script is not enabled at initialisation time.
    /// 
    /// The Awake function is called on all objects in the scene before any object's Start function is called. 
    /// This fact is useful in cases where object A's initialisation code needs to rely on object B's already being initialised; B's initialisation should be done in Awake while A's should be done in Start.
    /// </summary>
    void Awake() {
        m_StartZ = 0;
        SetRandomStartLoc();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behaviour.
    /// </summary>
    void Update()
    {
        float amtToMove = m_CurSpeed * Time.deltaTime;

        if (m_SpawnSide)
        {
            transform.Translate(Vector3.right * amtToMove);
            if (transform.position.x > 6.5f)
            {
                SetRandomStartLoc();
            }
        }
        else
        {
            transform.Translate(Vector3.left * amtToMove);
            if (transform.position.x < -6.5f)
            {
                SetRandomStartLoc();
            }
        }
        /*
        if (transform.position.y < -6.5f)
        {
            Player.Missed++;
            setRandomStartLoc();
        }*/
    }
    #endregion

    #region Functions
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool RandomizeStartingLocation()
    {
        float temp;
        temp = Random.value;
        if (temp > 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetRandomStartLoc() {
        m_SpawnSide = RandomizeStartingLocation();

        if (m_SpawnSide)
        {
            m_StartX = -6.5f;
        }
        else
        {
            m_StartX = 6.5f;
        }

        m_StartY = Random.Range(-1.4f, 5.1f);
        transform.position = new Vector3(m_StartX, m_StartY, m_StartZ);
        //Setting Enemy's speed
        m_CurSpeed = Random.Range(MinSpeed, MaxSpeed);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="rot"></param>
    void CreateNewEnemy(Vector3 pos, Quaternion rot) { 
        Enemy j = new Enemy();
        Instantiate(j.gameObject, pos, rot);
    }
    #endregion
}