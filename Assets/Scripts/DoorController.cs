using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool isOpen;
    public float openedRotation,closedRotation,speed;

    public void MoveDoor()
    {
        isOpen = !isOpen; 
        
    }
    private void Update()
    {
        if (isOpen)
        {
            Quaternion doorRotation1 = Quaternion.Euler(0, openedRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, doorRotation1, speed * Time.deltaTime);
        }else if (isOpen==false)
        {
            Quaternion doorRotation2 = Quaternion.Euler(0, closedRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, doorRotation2, speed * Time.deltaTime);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen==false)
            {
                isOpen = true;
            }else if (isOpen)
            {
                isOpen = false;
            }
           
        }
    }

}
