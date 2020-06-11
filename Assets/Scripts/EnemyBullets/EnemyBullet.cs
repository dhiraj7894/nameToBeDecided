using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.player.takePlayerDamage(10);
        }
        if (EnemyController.enemy.hitMuzzel != null)
        {
            var hitVFX = Instantiate(EnemyController.enemy.hitMuzzel, transform.position, Quaternion.identity);
            Destroy(hitVFX, 0.5f);
        }
        Destroy(gameObject, 0.1f);
    }
}
