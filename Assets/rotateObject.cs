using UnityEngine;

public class rotateObject : MonoBehaviour
{

    public Vector3 RotateAmount;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);

    }
}
