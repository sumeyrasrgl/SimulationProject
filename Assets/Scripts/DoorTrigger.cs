using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public float openedRotationn,closedRotationn,speedd;
    public bool isOpenn;
    public void Moved()
    {
        isOpenn = !isOpenn;
    }
    private void Update()
    {
        if (isOpenn==true)
        {
            Quaternion doorRotationn1 = Quaternion.Euler(0, openedRotationn, 0);
            transform.localRotation = Quaternion.Slerp(transform.rotation, doorRotationn1, speedd * Time.deltaTime);

        }
    }

   

}
