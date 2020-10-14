using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool isOpen;
    public float openedRotation,closedRotation,speed1,speed2;
    public GameObject Door2;
    Transform door;
    void Start()
    {
         door = Door2.GetComponent<Transform>();
            
    }

    public void MoveDoor()
    {
        isOpen = !isOpen; 
        
    }
    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if (isOpen)
        {
            Quaternion doorRotation1 = Quaternion.Euler(0, openedRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, doorRotation1, speed1 * Time.deltaTime);
            door.localRotation = Quaternion.Slerp(door.rotation, doorRotation1, speed2 * Time.deltaTime);


        }
        else if (isOpen == false)
        {
            Quaternion doorRotation2 = Quaternion.Euler(0, closedRotation, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, doorRotation2, speed1 * Time.deltaTime);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isOpen==false)
            {
               
                isOpen = true;
 
            }
          

        }
    }

}
