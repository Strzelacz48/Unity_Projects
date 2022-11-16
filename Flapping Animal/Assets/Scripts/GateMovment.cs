using UnityEngine;

public class GateMovment : MonoBehaviour
{
    //GameManager gameManager;
    public float bladesSpeed = 20f;
    void Update()
    {
        transform.position += Vector3.left * bladesSpeed * Time.deltaTime;
        if(transform.position.x<-25f)
        {
            Destroy(gameObject);
        }
    }
}
