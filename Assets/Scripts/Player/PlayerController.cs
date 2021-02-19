using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Designer Values")]
    public float speed;
    public float bulletSpeed;
    public float bulletTime;
    public GameObject firePoint;
    public float dashSpeed;
    public float startDashTime;
    public float health;

    [Header("Bools")]
    private bool isDashing;

    [Header("Floats")]
    private float dashTime;

    [Header("Integers")]
    private int direction;

    [Header("Vectors")]
    private Vector2 moveVelocity;
    private Vector2 mousePos;
    private Vector2 dashDir;

    [Header("References")]
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerInput pi;
    [SerializeField] private PlayerShooting ps;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Collider2D coll;


    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Aim();
        ps.ShootBullet();

        CalculateDashDirection();
    }

    private void FixedUpdate()
    {
        //Movement
        if (!isDashing)
        {
            rb2d.velocity = moveVelocity;
        }

        //Turn to face cursor
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;

        //Dashing
        if (isDashing)
        {
            if (dashTime <= 0)
            {
                direction = 0;
                rb2d.velocity = Vector2.zero;
                isDashing = false;
            }

            else
            {
                dashTime -= Time.fixedDeltaTime;
                rb2d.velocity = dashDir * dashSpeed;
            }
        }
    }


    private void Movement()
    {
        Vector2 moveInput = new Vector2(pi.horizontalInput, pi.verticalInput);
        moveVelocity = moveInput.normalized * speed;
    }
    private void Aim()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void CalculateDashDirection()
    {
        if (pi.dash)
        {
            isDashing = true;
            dashTime = startDashTime;
            dashDir = new Vector2(pi.horizontalInput, pi.verticalInput);
        }
    }

    private void DamageTaken (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamageTaken(1);
        }
    }
}
