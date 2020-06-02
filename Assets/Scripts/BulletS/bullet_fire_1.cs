using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fire_1 : MonoBehaviour
{
    
    public static bullet_fire_1 bullet;

    public Rigidbody rb;

    private void Start()
    {
        bullet = this;
        rb = GetComponent<Rigidbody>();


    }
    // Update is called once per frame

    /*private void OnTriggerEnter(Collider other)
    {
        speed = 0;
        if (Player.player.muzzelHit != null)
        {
            var hitVFX = Instantiate(Player.player.muzzelHit, transform.position, Quaternion.identity);
            Destroy(hitVFX, 0.5f);
        }
        Destroy(gameObject);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerBulletShoot.instance._getMuzzelData() != null)
        {
            var hitVFX = Instantiate(PlayerBulletShoot.instance._getMuzzelData(), transform.position, Quaternion.identity);
            Destroy(hitVFX, 0.5f);
        }
        Destroy(gameObject,0.1f);
    }


}
