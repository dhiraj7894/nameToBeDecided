using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roket : MonoBehaviour
{
    Rigidbody rb;
    public float sp;
    public bool up=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sp >= 1)
        {
            up = true;
        }
        if (sp <= 0)
        {
            up = false;
        }
        if (!up)
        {
            sp += 0.01f;
            transform.Translate(Vector3.up * sp * Time.deltaTime);
        }
        if(up)
        {
            sp -= 0.01f;
            transform.Translate(Vector3.down * sp * Time.deltaTime);
        }
    }
}
