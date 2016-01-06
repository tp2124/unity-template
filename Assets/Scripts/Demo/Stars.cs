using UnityEngine;

/// <summary>
/// These are red blocks that the bullets hit
/// </summary>
public class Stars : MonoBehaviour
{
    #region Properties
    public float Speed;
    #endregion

    #region Functions
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// Update is the most commonly used function to implement any kind of game behaviour.
    /// </summary>
    void Update()
    {
        float amtToMove = Speed * Time.deltaTime;
        transform.Translate(Vector3.down * amtToMove, Space.World);
        //This is transforming it locally, that is why it is .back instead of .down)
        //transform.Translate(Vector3.back * amtToMove);
        if (transform.position.y < -10.7f) {
            transform.position = new Vector3(transform.position.x, 15.6f, transform.position.z);
        }
    }
    #endregion


}