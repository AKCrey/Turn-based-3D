using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Transform currentGun;

    public int playerID;
    public float maxRelativeVelocity = 6f;
    public float misileForce = 5f;

    /*[Header("BulletData")]
    [SerializeField] private BulletMover bullet;
    public Transform bulletSpawnPoint;*/

    private Camera mainCam;

    [Header("Movement")]
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public string EnemyTag = "Enemy";

    private HealthController health = null;


    public bool IsTurn { get { return TurnManager.instance.IsMyTurn(playerID); } }

    Gun[] guns; //Array of guns

    // Start is called before the first frame update
    void Start()
    {
        //GetHealth

        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsTurn) //the wormID is equal to the TurnManager
        {
            return;
        }

        Move();
        Shoot();   
    }

    void Shoot()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))//wasPressedThisFrame to shoot once per press
        {
            /*foreach (Gun gun in guns)
            {
                if (gun.gameObject.activeSelf)
                {
                    gun.Shoot();
                }
            }*/

            if (IsTurn)
            {
                TurnManager.instance.NextPlayer();
            }
        }
    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(EnemyTag))
        {
            /*if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
                Destroy(gameObject);*/
            health.RecieveDamage(health.GetCurrentHealth());
            //Goodbye player
            //}
        }



    }
}
