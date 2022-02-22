using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashObstacle : MonoBehaviour
{
    public GameObject block;

    public Material mat1;
    public Material mat2;
    public Light flasher;

    public float flashRate = .2f;

    bool flipColor = true;

    private void Start()
    {
        InvokeRepeating("flash", flashRate, flashRate);
    }

    void FixedUpdate ()
    {
    }

    void flash()
    {
        if (flipColor)
        {
            block.GetComponent<Renderer>().material = mat2;
            flipColor = false;
            flasher.enabled = true;
        }
        else
        {
            block.GetComponent<Renderer>().material = mat1;
            flipColor = true;
            flasher.enabled = false;

        }
    }
}
