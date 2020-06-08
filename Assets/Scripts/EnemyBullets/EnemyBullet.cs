using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (EnemyController.enemy.hitMuzzel[0] != null)
        {
            var hitVFX = Instantiate(EnemyController.enemy.hitMuzzel[0], transform.position, Quaternion.identity);
            Destroy(hitVFX, 0.5f);
        }
        Destroy(gameObject, 0.1f);
    }
}
