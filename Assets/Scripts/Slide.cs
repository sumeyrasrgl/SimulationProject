using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public float t = 0f;
    public Spline spline;

    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
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
