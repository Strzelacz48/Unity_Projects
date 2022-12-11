using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    //double upwardForce = 100f;
    //static float t = 0.0f;
    //public Transform transform;
    bool DKey = false, WKey = false, AKey = false;
    private IEnumerator coroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            if (transform.position.x == 2f)
            {
                coroutine = MovingTo(5);
                StartCoroutine(coroutine);
                Debug.Log("ifD");
            }//transform.position = new Vector3(Mathf.Lerp(2, 5, t), transform.position.y, 0);//(5, transform.position.y, 0);
            else if (transform.position.x == 5f)
            {
                coroutine = MovingTo(8);
                StartCoroutine(coroutine);
                Debug.Log("elseifD");
            }//transform.position = new Vector3(Mathf.Lerp(8, 5, t), transform.position.y, 0);//(8, transform.position.y, 0);
            Debug.Log("D");
        }
        else if (Input.GetKeyDown("w"))
        {
            Debug.Log("W");
        }
        else if (Input.GetKeyDown("a"))
        {
            if (transform.position.x == 5f)
            {
                coroutine = MovingTo(2);
                StartCoroutine(coroutine);
            }//transform.position = new Vector3(Mathf.Lerp(5, 2, t), transform.position.y, 0);//(2, transform.position.y, 0);
            else if (transform.position.x == 8f)
            {
                coroutine = MovingTo(5);
                StartCoroutine(coroutine);
            }//transform.position = new Vector3(Mathf.Lerp(8, 5, t), transform.position.y, 0);//(5, transform.position.y, 0);
            Debug.Log("A");
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
