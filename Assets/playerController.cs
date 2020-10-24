using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //public Rigidbody rb;
    public Animator anime;
    public float speed=5;
    public float speedR=40;

    float x, z,rot;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        rot += x * speedR * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)&&speed != 5)
        {
            speed -= 5f;  
        }
        if (Input.GetKey(KeyCode.W) && speed != 15)
        {
            speed += 5f;
        }
        else
        {
            z = 15;
            z = Input.GetAxis("Vertical");
        }

        anime.SetFloat("vertical",z);

        movement();
    }
    void movement()
    {
        transform.Translate(Vector3.forward * speed * z * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, rot, 0);
    }
}
