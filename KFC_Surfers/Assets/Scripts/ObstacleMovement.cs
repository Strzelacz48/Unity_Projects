using UnityEngine;

public class GateMovment : MonoBehaviour
{
    //GameManager gameManager;
    public float obstacleSpeed = 20f;
    void Update()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;
        if(transform.position.x<-25f)
        {
            Destroy(gameObject);
        }
    }
}
