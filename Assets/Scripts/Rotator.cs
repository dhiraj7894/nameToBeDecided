using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed1=5;
    public float speed2=5;
    public float speed3=5;
     float angle1;
     float angle2;
     float angle3;
    void FixedUpdate()
    {
        if (speed2 == 0 && speed3 == 0)
        {
            angle1 += Time.deltaTime * speed1;
            transform.localRotation = Quaternion.Euler(angle1, transform.localRotation.y, transform.localRotation.z);
        }

        if (speed1 == 0 && speed3 == 0)
        {
            angle2 += Time.deltaTime * speed2;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, angle2, transform.localRotation.z);
        }

        if (speed1 == 0 && speed2==0)
        {
            angle3 += Time.deltaTime * speed3;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle3);
        }


        //////////////////////////////////////////////////////////////////
        if (speed2 == 90 && speed3 == 0)
        {
            angle1 += Time.deltaTime * speed1;
            transform.localRotation = Quaternion.Euler(angle1, 90, transform.localRotation.z);
        }

        if (speed1 == 0 && speed3 == 90)
        {
            angle2 += Time.deltaTime * speed2;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, angle2, 90);
        }

        if (speed1 == 90 && speed2 == 0)
        {
            angle3 += Time.deltaTime * speed3;
            transform.localRotation = Quaternion.Euler(90, transform.localRotation.y, angle3);
        }


    }
}
