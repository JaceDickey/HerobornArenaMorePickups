using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 5.0f;
    public bool isGrounded;

    public float moveSpeed = 30f;
    public float rotateSpeed = 75f;

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public bool bulletShoot;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if(Input.GetMouseButtonDown(0))
        {
            bulletShoot = true;
        }

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
}