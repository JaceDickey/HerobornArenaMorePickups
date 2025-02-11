using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 50.0f;
    public bool isGrounded;
    public static int jumpCost = 200;

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public bool bulletShoot;
    public static int bullets = 10;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;

    public bool sprinting = false;
    public static int sprint = 0;
    public static int sprintMax = 1000;
    public int sprintMin = 0;

    public EnemyBehavior enemy;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (sprint > jumpCost)
            {
                _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                sprint = sprint - jumpCost;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (bullets > 0)
            {
                bulletShoot = true;
                bullets--;
                GameBehavior.bullets = bullets;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }

        if (sprinting == true)
        {
            if (sprint > sprintMin)
            {
                moveSpeed = 30.0f;
                sprint--;
            }
            else
            {
                moveSpeed = 10.0f;
            }
        }
        else
        {
            moveSpeed = 10.0f;
            if (sprint < sprintMax)
            {
                sprint++;
            }
        }
        GameBehavior.staminaText = sprint;
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation *
            Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position +
            this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if (bulletShoot)
        {
            // 3
            GameObject newBullet = Instantiate(bullet,
               this.transform.position + new Vector3(1, 0, 0),
                  this.transform.rotation) as GameObject;

            // 4
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();

            // 5
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            bulletShoot = false;
        }
    }

        void OnCollisionStay()
    {
        isGrounded = true;
    }
        void OnCollisionExit()
    {
        isGrounded = false;
    }
        public static void redStaminaPickedUp()
    {
        sprintMax = 2000;
        Debug.Log("Run Stamina Doubled!");
    }
        public static void greenJumpPickedUp()
    {
        jumpCost = 100;
        Debug.Log("Jump Stamina Cost Halved!");
    }
}