using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile/Bullet class
/// </summary>
public class Projectile : MonoBehaviour
{
    #region Properties
    public float ProjectSpeed;
    public GameObject ExplosionPrefab;
    public GameObject ProjectilePrefab1;
    public GameObject ProjectilePrefab2;
    public GameObject EnemyPrefab;
    public float DirectionCoefficient = 1.0f;

    private float m_SideSpeed;
    private float m_NewProjectileSpeed;
    /// <summary>
    /// //useful to count out lookups
    /// </summary>
    private Transform m_MyTransform; 
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
    void Start()
    {
        m_SideSpeed = Player.PlayerSpeed;
        m_NewProjectileSpeed = ProjectSpeed;
        m_MyTransform = transform;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behaviour.
    /// </summary>
    void Update()
    {
        float amtToTranslate = Input.GetAxisRaw("Horizontal") * m_SideSpeed * Time.deltaTime;
        //Translating
        transform.Translate(Vector3.left * amtToTranslate * DirectionCoefficient);
        float amtToMove = ProjectSpeed * Time.deltaTime;
        m_MyTransform.Translate(Vector3.up * amtToMove);

        if (m_MyTransform.transform.position.y < -6.3f)
        {
            if (Player.Lives == 0)
                Player.GameOver = true;
            Destroy(this.gameObject);
        }

        //if (Mathf.Abs(transform.position.x) > 6.8)
        //{
        //    transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        //}
        ProjectSpeed -= .1f;
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// This message is sent to the trigger collider and the rigidbody (or the collider if there is no rigidbody) that touches the trigger.
    /// Notes: Trigger events are only sent if one of the colliders also has a rigidbody attached. Trigger events will be sent to disabled MonoBehaviours, to allow enabling Behaviours in response to collisions.
    /// </summary>
    /// <param name="otherObj"></param>
    void OnTriggerEnter(Collider otherObj)
    {
        //     Debug.Log("Collision hit enemy" + otherObj.name);
        if (otherObj.tag == "enemy"   /* this is the tag in the top left of the inspector*/)
        {

            //For kiling enemy
            //   Destroy(otherObj.gameObject);
            //Must cast this component
            Enemy j = (Enemy)otherObj.GetComponent("Enemy");
            Vector3 enPos = new Vector3(j.transform.position.x, j.transform.position.y, j.transform.position.z);
            Instantiate(ExplosionPrefab, enPos, transform.rotation);

            j.SetRandomStartLoc();
            //Instantiate(EnemyPrefab, enPos, Quaternion.identity);
            //j.createNewEnemy(j.gameObject.transform.position, Quaternion.identity);

            ProjectSpeed = m_NewProjectileSpeed;

            Vector3 projectilePos = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);

            //This is the rediculous casting that is required to make an object and access it's script properties.
            Object spawnedBullet = Instantiate(ProjectilePrefab2, projectilePos, transform.rotation);
            GameObject gameObjectSpawnedBullet = (GameObject)spawnedBullet;
            // The Projectile class is a script component that is only attached to the GameObject. 
            // All properties in C# are just attached to the component of the GameObject. 
            // Use the template version to allow for compile time errors instead of runtime errors. Don't be an idiot
            Projectile projSpawnedBullet = gameObjectSpawnedBullet.GetComponent<Projectile>();
            projSpawnedBullet.DirectionCoefficient = -1.0f;

            projectilePos.x = projectilePos.x + 0.2f;
            Instantiate(ProjectilePrefab1, projectilePos, transform.rotation);
            //Killing shot
            // doing Destroy(this) will just kill the script 
            Destroy(gameObject);
            Player.Score += 7;
            Player.Multiplier++;
            //if (Player.Lives == 0)
            //{
            //    Application.LoadLevel(3);
            //}
        }
    }
    #endregion
}
