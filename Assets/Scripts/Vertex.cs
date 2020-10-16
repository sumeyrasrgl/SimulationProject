using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex : MonoBehaviour
{
    public float magnitudeForward = 1f, magnitudeBack = 1f;
    public GameObject capsule;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            capsule.transform.position = new Vector3(transform.position.x + 2,transform.position.y,transform.position.z+0.2f);
        }
    }
}
