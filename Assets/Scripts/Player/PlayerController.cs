using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Designer Values")]
    public float speed;
    public float bulletSpeed;
    public float bulletTime;
    public GameObject firePoint;

    [Header("Vectors")]
    private Vector2 moveVelocity;
    private Vector2 mousePos;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Aim();
        ps.ShootBullet();
    }

    private void FixedUpdate()
    {
        //Movement
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);

        //Turn to face cursor
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
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

}
