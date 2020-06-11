using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController enemy;

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

    private float _Health = 100;
    [SerializeField]
    private float _CurrentHealth;
    public GameObject hitMuzzel;

    bool isDied = false;
    // Start is called before the first frame update
    void Start()
    {
        _CurrentHealth = _Health;
        enemy = this;
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();
        movement();
    }

    void movement()
    {
        if (!isDied)
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
                if (attackCooldown <= 0f)
                {
                    StartCoroutine(shoot(0.01f));
                    attackCooldown = 1f / attackRate;
                }

            }
            shootPoint.transform.LookAt(player.transform);
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
        Destroy(Bullet, 1f);
    }

    public void TakeDamage(float value)
    {
        _CurrentHealth = _CurrentHealth-value;
    }
    public void Die()
    {
        if (_CurrentHealth <= 0)
        {
            Destroy(gameObject);
            isDied = true;
        }
    }
}
