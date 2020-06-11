using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test_1 : MonoBehaviour
{
    public float speed;
    public float F1, F2;
    public Transform W1, W2, W3;

    public bool activate=false ;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (F1 < F2)
        {
            transform.position = Vector3.Lerp(transform.position, W1.position, speed*Time.fixedDeltaTime);
        }
        if (F1 > F2)
        {
            transform.position = Vector3.Lerp(transform.position, W2.position, speed*Time.fixedDeltaTime);
        }

        if (activate)
        {
            transform.position = Vector3.Lerp(transform.position, W3.position, speed * Time.fixedDeltaTime);
        }
    }
}
