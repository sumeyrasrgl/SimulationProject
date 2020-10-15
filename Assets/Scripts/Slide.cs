using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float t = 0f;
    public Spline spline;
    DoorController doorController;
    public GameObject door;
    Transform transformDoor;
    public GameObject npcPlayer;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        t = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (door.GetComponent<DoorController>().isOpen==true)
        {

            animator.SetBool("walk", true);
            NpcMovement();
          



        }


    }

    public void NpcMovement()
    {
        this.transform.position = spline.getSplinePosition(t);
        
        t += Time.deltaTime / 10f;
        //sürekli başa sar
        /*if (t>1)
        {
            t = 0;
        }*/
    }
}
