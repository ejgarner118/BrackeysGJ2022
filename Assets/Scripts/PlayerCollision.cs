using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;        //Used to disable Player movement on collision

    public AudioSource audioSourceBox;
    public AudioSource audioSourceBounce;
    public AudioSource audioSourcePickup;


    Mesh shapeMesh;


    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        //Determine Collision Type

        //Collided with Obstacle
        if (collisionInfo.collider.tag == "Obstacle")
        {
            audioSourceBox.Play();
            movement.enabled = false;
            FindObjectOfType<GameManager>().hitObstacle();
            
        }


        if (collisionInfo.collider.tag == "BounceSFXObstacle")
        {
            Debug.Log("hit the bump");

            audioSourceBounce.Play();
        }


        //Collided with a pickup
        //Debug.Log("Picked something up");
        //Destroy(collisionInfo.collider);
        //Debug.Log(collisionInfo.collider.gameObject.ToString());

        //Player hit's a ballpick up, Mesh changes and colliders enable/disable
        if (collisionInfo.collider.tag == "BallPickup")
        {
            //Play audio for pickup collision
            audioSourcePickup.Play();

            //remove the object that was impacted
            collisionInfo.gameObject.SetActive(false);

            //Scale factor for the ball mesh
            Vector3 scale = new Vector3(.6f, .6f, .6f);

            Debug.Log("YOu hit ball");

            //Change mesh to sphere
            shapeMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
            GetComponent<MeshFilter>().mesh = shapeMesh;

            //Scale to match cube size
            GetComponent<Transform>().localScale = scale;

            //Enable disable other shape colliders
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = true;
        }

        //Player hit's a Box Pick up, Mesh changes and colliders enable/disable
        if (collisionInfo.collider.tag == "CubePickup")
        {
            audioSourcePickup.Play();

            //remove the object that was impacted
            collisionInfo.gameObject.SetActive(false);

            //Scale factor for the ball mesh
            Vector3 scale = new Vector3(1f, 1f, 1f);

            Debug.Log("YOu hit cube");

            //change mesh to cube
            shapeMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            GetComponent<MeshFilter>().mesh = shapeMesh;

            //Scale to unity cube size
            GetComponent<Transform>().localScale = scale;

            //Enable/disable other shape colliders
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = true;
        }

        if (collisionInfo.collider.tag == "PillPickup")
        {
            audioSourcePickup.Play();

            //remove the object that was impacted
            collisionInfo.gameObject.SetActive(false);

            Debug.Log("YOu hit pill");
            Vector3 scale = new Vector3 (.4f, .4f, .4f);


            shapeMesh = Resources.GetBuiltinResource<Mesh>("Capsule.fbx");
            GetComponent<MeshFilter>().mesh = shapeMesh;

            //Scale to match cube size
            GetComponent<Transform>().localScale = scale;

            //Enable/disable other shape colliders
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = true;
        }





    }
}

