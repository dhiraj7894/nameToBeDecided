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
    void Update()
    {
        angle1 += Time.deltaTime * speed1;
        angle2 += Time.deltaTime * speed2;
        angle3 += Time.deltaTime * speed3;
        transform.localRotation = Quaternion.Euler(angle1,angle2, angle3);
    }
}
