using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    double upwardForce=100f;
    //public Transform transform;
    bool DKey=false,WKey=false,AKey=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            DKey = true;
        }
        else
        {
            DKey = false;
        }
        if (Input.GetKeyDown("w"))
        {
            WKey = true;
        }
        else
        {
            WKey = false;
        }
        if (Input.GetKeyDown("a"))
        {
            AKey = true;
        }
        else
        {
            AKey = false;
        }
        if (WKey)
        {
            if(transform.position.y<=1)
                transform.position = new Vector3(transform.position.x, 2, 0);
            Debug.Log("W");
        }
        if (AKey)
        {
            if(transform.position.x==5)
                transform.position = new Vector3(2, transform.position.y, 0);
            else if(transform.position.x==8)
                transform.position = new Vector3(5, transform.position.y, 0);
            Debug.Log("A");
        }
        if (DKey)
        {
            if(transform.position.x==2)
                transform.position = new Vector3(5, transform.position.y, 0);
            else if(transform.position.x==5)
                transform.position = new Vector3(8, transform.position.y, 0);
            Debug.Log("D");
        }
    }

    void FixedUpdate()
    {

    }
}
