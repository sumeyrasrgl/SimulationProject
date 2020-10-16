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
    private GameObject target;
    public GameObject table;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        t = 0;
        


    }

    public void LookUpTarget()
    {
  
        target = table.gameObject;
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            LookUpTarget();
        }
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
        if (t>1)
        {
            animator.SetBool("cube", true);
        }
        //sürekli başa sar
        /*if (t>1)
        {
            t = 0;
        }*/
    }
}
