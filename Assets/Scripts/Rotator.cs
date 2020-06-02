using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed=5;
    float angle;
    void Update()
    {
        angle += Time.deltaTime * speed;
        transform.localRotation = Quaternion.Euler(0,0, angle);
    }
}
