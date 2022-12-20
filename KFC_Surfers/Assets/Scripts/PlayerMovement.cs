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
    //static float t = 0.0f;
    //public Transform transform;
    //bool DKey = false, WKey = false, AKey = false;
    private IEnumerator coroutine;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            if (transform.position.x < 8f)
            {
                transform.position+=Vector3.right * sideMoveForce * Time.deltaTime;;
                /*coroutine = MovingTo(5);
                StartCoroutine(coroutine);*/
                Debug.Log("ifD");
            }//transform.position = new Vector3(Mathf.Lerp(2, 5, t), transform.position.y, 0);//(5, transform.position.y, 0);
            //transform.position = new Vector3(Mathf.Lerp(8, 5, t), transform.position.y, 0);//(8, transform.position.y, 0);
            Debug.Log("D");
        }
        else if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.velocity = Vector3.up * upwardForce;
            Debug.Log("W");
            
        }
        else if (Input.GetKey("a"))
        {
            if (transform.position.x > 2f)
            {
                transform.position+=Vector3.left * sideMoveForce * Time.deltaTime;
                /*coroutine = MovingTo(2);
                StartCoroutine(coroutine);*/
                Debug.Log("ifA");
            }//transform.position = new Vector3(Mathf.Lerp(5, 2, t), transform.position.y, 0);//(2, transform.position.y, 0);
            //transform.position = new Vector3(Mathf.Lerp(8, 5, t), transform.position.y, 0);//(5, transform.position.y, 0);
            Debug.Log("A");
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
    }

    void FixedUpdate()
    {

    }
    void OnCollisionEnter(Collision info)
    {
        if (info.collider.tag == "Obstacle")
        {
            //zatrzymaj przesuwanie przeszkód i lasu
            aManager.SetBool("isDead", true);
            FindObjectOfType<GameManager>().EndGame();
        }
        Debug.Log(info.collider.name);
    }
    private IEnumerator MovingTo(float targetX) // do poprawienia żeby działało do presuwania między liniami
    {
        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetX, 0.1f), transform.position.y, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator DistanceTraveled()
    {
        float distance = 0f;
        while (distance < 1f)
        {
            distance += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

    }
}
