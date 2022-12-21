using System.ComponentModel;
using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public float sideMoveForce= 10f;
    public Animator aManager;
    public Rigidbody rb;
    public float upwardForce = 5f;
    private bool isGrounded = true;
    private bool isDead = false;
    public AudioSource runSound;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    private int rollTimer = 0;
    void Update()
    {
        if (Input.GetKey("d") && !isDead)
        {
            if (transform.position.x < 8f)
            {
                transform.position+=Vector3.right * sideMoveForce * Time.deltaTime;;
                
            }
        }
        else if (Input.GetKeyDown("w") && isGrounded && !isDead)
        {
            rb.velocity = Vector3.up * upwardForce;
            jumpSound.Play();
            
            
        }
        else if (Input.GetKey("a") && !isDead)
        {
            if (transform.position.x > 2f)
            {
                transform.position+=Vector3.left * sideMoveForce * Time.deltaTime;
            }
        }
        if(transform.position.y > 0.5f)
        {
            isGrounded = false;
            aManager.SetBool("jumping", true);
        }
        else
        {
            isGrounded = true;
            aManager.SetBool("jumping", false);
        }
        if(isGrounded && !isDead)
        {
            runSound.mute = false;
        }
        else
        {
            runSound.mute = true;
        }
    }


    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle")
        {
            deathSound.Play();
            isDead = true;
            //zatrzymaj przesuwanie przeszkód i lasu
            aManager.SetBool("isDead", true);
            FindObjectOfType<GameManager>().EndGame();
        }
        Debug.Log(info.collider.name);
    }
}
/*
        else if (Input.GetKeyDown("s") && isGrounded && !isDead)
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.center = new Vector3(0, 0.0f, 0);
            jumpSound.Play();
            Debug.Log("S");
        }
        if(rollTimer > 0)
        {
            rollTimer--;
        }
        else
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            boxCollider.center = new Vector3(0, 0.96f, 0);
        }*/