using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float ver, hor, mouseX, mouseY;
    public Transform mainCamera;
    public float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        Movement();
        TurnLeftRight();
        LookUpDown();


    }

    public void Movement()
    {
        
        Vector3 hizimiz = new Vector3(hor, 0.0f, ver);
        rb.AddForce(hizimiz * speed);
       
    }

    public void TurnLeftRight()
    {
        transform.rotation *= Quaternion.Euler(0, mouseX * speed, 0);
    }
    public void LookUpDown()
    {
        mainCamera.GetComponent<CameraController>().SetLookUpDown(-mouseY);
    }
}
