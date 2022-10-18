using UnityEngine;

public class Playermov : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    bool left = false, right = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    //najlpeiej jest zbierać input z klawaiatury jeżeli chcemy żeby gracz mógł sterować grą dać getinput do zwykłego update
    //a potem w fixed update użyć tego inputu do ruchu
    // Update is called once per frame
    //FixedUpdate is called before performing any physics calculations (better for physics)
    void Update()
    {
        if (Input.GetKey("a"))
        {
            left = true;
        }
        else
        {
            left = false;
        }
        if (Input.GetKey("d"))
        {
            right = true;
        }
        else
        {
            right = false;
        }

    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (right)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (left)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

    }
}
