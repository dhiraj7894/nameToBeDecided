using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundBall : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public Vector3 rotation;

    void Update()
    {
        OrbitAround();

    }

    void OrbitAround()
    {
        transform.RotateAround(target.transform.position, rotation, speed * Time.deltaTime);
    }
}
