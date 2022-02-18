using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 20f;


    void FixedUpdate()
    {
        //add a forward force to move the player
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //Move Right
        if (Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Move Left
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Jump
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        //Player fell off the ground
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().endGame();  
        }
    }
}
