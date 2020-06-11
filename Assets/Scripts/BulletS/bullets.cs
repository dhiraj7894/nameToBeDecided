using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    
    public static bullets bullet;

    public Rigidbody rb;

    private void Start()
    {
        bullet = this;
        rb = GetComponent<Rigidbody>();


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CMON"))
        {
            EnemyController.enemy.TakeDamage(10);
        }

        if (PlayerBulletShoot.instance._getMuzzelData() != null)
        {
            var hitVFX = Instantiate(PlayerBulletShoot.instance._getMuzzelData(), transform.position, Quaternion.identity);
            Destroy(hitVFX, 0.5f);
        }
        Destroy(gameObject,0.1f);
    }


}
