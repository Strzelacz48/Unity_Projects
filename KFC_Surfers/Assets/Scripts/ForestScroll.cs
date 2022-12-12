using UnityEngine;

public class ForestScroll : MonoBehaviour
{
    public const float Edge = -30f;
    public const float forestSpeed = 15f;
    public float forestSpeedReal = forestSpeed;
    // Update is called once per frame
    void Update()
    {
        forestSpeedReal = FindObjectOfType<GameManager>().gameSpeed * forestSpeed;
        transform.position -= Vector3.forward * forestSpeedReal * Time.deltaTime;
        if (transform.position.z < Edge)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 109f);
        }
    }
}
