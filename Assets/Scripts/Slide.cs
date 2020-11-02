using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float t = 0f;
    public Spline spline;
    public GameObject door;
    public GameObject npcPlayer;
    Animator animator;
    private GameObject target;
    public GameObject table;
    public GameObject hand;
    public GameObject cube;


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
    
    void Update()
    {
        
        if (door.GetComponent<DoorController>().isOpen==true)
        {
            animator.SetBool("walk", true); 
            NpcMovement();
        }

    }

    private IEnumerator cubeCoroutine()
    {
        yield return new WaitForSeconds(1.3f);
        cube.transform.parent = hand.transform;
        cube.transform.localPosition = Vector3.zero;
        cube.transform.localRotation = Quaternion.identity;
    }

    public void NpcMovement()
    {
        this.transform.position = spline.getSplinePosition(t);
        Vector3 newPos = spline.getSplinePosition(t + 0.00001f);
        this.transform.LookAt(newPos);
        
        t += Time.deltaTime / 10f;
        if (t>1)
        {
            
            
            animator.SetBool("cube", true);
            StartCoroutine(cubeCoroutine());
            
            
        }
        
        /*if (t>1)
        {
            t = 0;
        }*/
    }
}
