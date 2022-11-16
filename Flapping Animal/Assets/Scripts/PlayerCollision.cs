using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public DragonMovement movement;
    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        Debug.Log(info.collider.name);
    }//testowy komentarz
}
