using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public CharacterController controller;
    public GameManager _manager;

    public Transform cam;
    public Transform Gun;



    public float verticalVelocity;
    public float jumpForce = 10f;
    public float speed = 6f;
    public float rotationSmoothness = 0.5f;

    private float _Health = 100;
    [SerializeField]
    private float _CurrentHealth = 0;

    public Animator anime;

    private float _targetAngle;
    public float _angle;

    private float _gravity = 9.8f;
    float turnSmoothVelocity;


    private void Start()
    {
        _CurrentHealth = _Health;

        player = this;

        //_effectToSpwan = vfx[0];
    }



    

    // Update is called once per frame
    void Update()
    {
        movement();
        playerDie();
    }
    void movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        if (controller.isGrounded)
        {
            verticalVelocity = -_gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= _gravity * Time.deltaTime;
        }

        Vector3 Jump = new Vector3(0, verticalVelocity, 0);
        controller.Move(Jump * Time.deltaTime);
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            _targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmoothVelocity, rotationSmoothness);
            transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
   public void takePlayerDamage(float value)
    {
        _CurrentHealth = _CurrentHealth - value;
    }
    public void playerDie()
    {
        if (_CurrentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

}
