using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float ver, hor, mouseY, mouseX;
    private Transform mainCamera;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        mouseY = Input.GetAxis("Mouse Y");
        mouseX = Input.GetAxis("Mouse X");
        MoveForwardBack();
        MoveLeftRight();
        TurnLeftRight();
        LookUpDown();

    }


    private void MoveForwardBack()
    {
        float multiplier = 10;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 15;
        }
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * multiplier * Time.deltaTime);


    }
    private void MoveLeftRight()
    {
        float multiplier = 10;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            multiplier = 15;
        }
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * multiplier * Time.deltaTime);


    }

    private void TurnLeftRight()
    {
        transform.rotation *= Quaternion.Euler(0, mouseX * speed, 0);
    }

    private void LookUpDown()
    {
        mainCamera.GetComponent<CameraController>().SetLookUpDown(-mouseY);
    }



}
