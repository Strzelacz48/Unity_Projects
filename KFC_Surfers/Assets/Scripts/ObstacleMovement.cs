using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    //GameManager gameManager;
    public const float obstacleSpeed = 15f;
    public float obstacleSpeedReal = obstacleSpeed;
    void Update()
    {
        obstacleSpeedReal = FindObjectOfType<GameManager>().gameSpeed * obstacleSpeed;
        transform.position -= Vector3.forward * obstacleSpeedReal * Time.deltaTime;
        if (transform.position.z < -25f)
        {
            Destroy(gameObject);
        }
    }
}
