using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Animator anime;
    public float speed=5;
    public float speedR=40;

    float x, y;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anime.SetFloat("vertical",y);
        anime.SetFloat("horizontal",x);
        movement();
    }
    void movement()
    {
        transform.position += (Vector3.forward * speed) * y * Time.deltaTime;

        transform.localEulerAngles += new Vector3(0,x * speedR * Time.deltaTime,0);
    }
}
