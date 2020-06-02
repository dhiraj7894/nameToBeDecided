using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject player;
    public GameObject bullet;
    public Transform shootPoint;

    public float MobDistanceRun = 4f;
    public float shootArea = 1f;
    public float bulletSpeed = 10f;
    public float attackRate = 1;
    public float attackCooldown = 0;
    public float enemyRotation = 2;
    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);
            facePlayer();
        }
        if (distance <= shootArea)
        {
            if(attackCooldown <= 0f)
            {
                StartCoroutine(shoot(0.01f));
                attackCooldown = 1f / attackRate;
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, MobDistanceRun);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootArea);
        
    }

    void facePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotation*Time.deltaTime);
    }
    IEnumerator shoot(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject Bullet = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
        bullet.transform.LookAt(player.transform);
        Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * bulletSpeed, ForceMode.Impulse);
        //GameObject muzzelObj = Instantiate(_muzzel, shootPoint.transform.position, Quaternion.identity);
        //Destroy(muzzelObj, 0.5f);
        Destroy(Bullet, 1f);
    }
}
