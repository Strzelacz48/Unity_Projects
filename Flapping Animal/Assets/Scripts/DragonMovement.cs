using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody rb;
    public float upwardForce = 100f;
    public float floorlevel=-15f;
    bool space=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="GatePoint")
        {
            gameManager.ScoreIncrease();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            space = true;
        }
        else
        {
            space = false;
        }
        if (space)
        {
            rb.velocity = upwardForce * Vector3.up;
        }
    }
    void FixedUpdate()
    {
        //rb.AddForce(2000 * Time.deltaTime, 0, 0);
        if(rb.position.y < floorlevel || rb.position.y > 2000f)//na wypadek dziwnych rzeczy
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
//instantiating objects in unity instantiate(object,position,rotation)/instantiate(object,position,rotation,transform)/instantiate(object,position,rotation,transform)/instantiate(object,transform)
//https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
//wywołanie destroy na obiekcie zniszczy go