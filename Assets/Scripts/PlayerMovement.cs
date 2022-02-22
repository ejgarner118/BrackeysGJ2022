using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 20f;
    public float downForce = 2000f;



    void FixedUpdate()
    {
        //add a forward force to move the player
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //Move Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Move Left
        if (Input.GetKey("a") || Input.GetKey("left") )
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Rotate
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.transform.Rotate(0, -2f, 0, Space.World);
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Rotate
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.transform.Rotate(0, 2f, 0, Space.World);
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


        //Player fell off the ground
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().fallOff();  
        }

        //Player is too high, add downward force
        if (rb.position.y > 3f)
        {
            rb.AddForce(0, -downForce * Time.deltaTime, 0);
        }
    }
}
