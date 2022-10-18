using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Playermov movement;
    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
        Debug.Log(info.collider.name);
    }//testowy komentarz
}
