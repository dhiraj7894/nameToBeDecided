using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletShoot : MonoBehaviour
{
    public static PlayerBulletShoot instance;

    public bullet_bl_1 bullet_bl;
    public bullet_or_1 bullet_or;
    public bullet_fire_1 bullet_fire;
    public Player player;
    public Animator anime;

    public float speed;
    public float fireRate;
    public float fireCooldown;

    private float _timeToFire;
    private GameObject _effectToSpwan;
    private GameObject _muzzel;
    private GameObject _muzzelHit;
   // private Vector3 _position;
    public Transform shootPoint;

    public List<GameObject> BulletVFX = new List<GameObject>();
    public List<GameObject> MuzzelVFX = new List<GameObject>();
    public List<GameObject> MuzzelVFXHit = new List<GameObject>();


    private void Awake()
    {
        instance = this;

        _effectToSpwan = BulletVFX[0];
        _muzzel = MuzzelVFX[0];
        _muzzelHit = MuzzelVFXHit[0];
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        switchBullet();

        if (Input.GetMouseButton(0) && fireCooldown <= 0)
        {
            StartCoroutine(GunForceAnime(0.2f));
            SpwanVFX();
            fireCooldown = 1f / fireRate;
        }
    }

    void switchBullet()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _effectToSpwan = BulletVFX[0];
            _muzzel = MuzzelVFX[0];
            _muzzelHit = MuzzelVFXHit[0];

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _effectToSpwan = BulletVFX[1];
            _muzzel = MuzzelVFX[1];
            _muzzelHit = MuzzelVFXHit[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _effectToSpwan = BulletVFX[2];
            _muzzel = MuzzelVFX[2];
            _muzzelHit = MuzzelVFXHit[2];
        }
    }

    void SpwanVFX()
    {
        if (shootPoint != null)
        {
            StartCoroutine(bulletShooted(0.1f));
        }
        else
        {
            Debug.LogError("No FirePoint");
        }
    }
    public GameObject _getMuzzelData()
    {
        return _muzzelHit;
    }
    IEnumerator bulletShooted(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject Bullet = Instantiate(_effectToSpwan, shootPoint.transform.position, shootPoint.transform.rotation);
        Rigidbody bulletRb = Bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(shootPoint.forward * speed, ForceMode.Impulse);

        GameObject muzzelObj = Instantiate(_muzzel, shootPoint.transform.position, shootPoint.transform.rotation);
        Destroy(muzzelObj, 0.5f);
        Destroy(Bullet, 1f);
    }
    IEnumerator GunForceAnime(float time)
    {
        anime.SetBool("Fire", true);
        yield return new WaitForSeconds(time);
        anime.SetBool("Fire", false);
    }
}
