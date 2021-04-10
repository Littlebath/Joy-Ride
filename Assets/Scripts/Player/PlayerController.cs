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
    [HideInInspector] public float health;
    public float maxHealth;

    [Header("Bools")]
    private bool isDashing;
    private bool isMoving;

    [Header("Floats")]
    private float dashTime;
    private float nextSpawnDirtTime;

    [Header("Integers")]

    [Header("Vectors")]
    private Vector2 moveVelocity;
    [HideInInspector] public Vector2 mousePos;
    private Vector2 dashDir;
    private Vector3 direction;

    [Header("References")]
    [SerializeField] private GameObject damagePopup;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerInput pi;
    [SerializeField] private PlayerShooting ps;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Collider2D coll;
    [SerializeField] private GameObject crossHair;
    [SerializeField] private GameObject gameoverUI;


    // Start is called before the first frame update
    void Start()
    {
        dashTime = startDashTime;
        health = maxHealth;
        healthBar.SetSize(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (pi.enabled)
        {
            Movement();

            Aim();
            ps.ShootBullet();

            CalculateDashDirection();
        }
    }

    private void FixedUpdate()
    {
        //Movement
        if (!isDashing)
        {
            rb2d.velocity = moveVelocity;
        }


        //Dashing
        if (isDashing)
        {
            if (dashTime <= 0)
            {
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

        if (moveInput == Vector2.zero)
        {
            isMoving = false;
        }

        else
        {
            isMoving = true;
        }
    }
    private void Aim()
    {
        //Turn to face cursor
        /*Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;*/

        FaceMouse();
    }

    void FaceMouse ()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;

        crossHair.transform.position = mousePos;
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

    public IEnumerator FlashRed ()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    private void knockBack(GameObject target, Vector3 direction, float length, float overTime)
    {
        direction = direction.normalized;
        StartCoroutine(knockBackCoroutine(target, direction, length, overTime));
    }

    IEnumerator knockBackCoroutine(GameObject target, Vector3 direction, float length, float overTime)
    {
        float timeleft = overTime;
        while (timeleft > 0)
        {

            if (timeleft > Time.deltaTime)
                target.transform.Translate(direction * Time.deltaTime / overTime * length);
            else
                target.transform.Translate(direction * timeleft / overTime * length);
            timeleft -= Time.deltaTime;

            yield return null;
        }

    }


    public void DamageTaken (float damage)
    {
        health -= damage;
        healthBar.SetSize(health, maxHealth);
        StartCoroutine(FlashRed());

        CameraController.Instance.ShakeCamera(6f, 0.1f);
        DamagePopup.Create(damagePopup, transform.position, damage);
        BloodParticleSystemHandler.Instance.SpawnBlood(transform.position, -direction);


        if (health <= 0)
        {
            PlayerDeathScreen();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void PlayerDeathScreen()
    {
        //Disable colliders and controls
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        coll.enabled = false;
        pi.enabled = false;
        rb2d.velocity = Vector2.zero;
        crossHair.SetActive(false);

        //Play Death Animation

        //Pull up gane over screen
        gameoverUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            DamageTaken(UnityEngine.Random.Range(50, 100));
            Vector3 direction = Vector3.Normalize(gameObject.transform.position - collision.gameObject.transform.position);
            knockBack(gameObject, direction, 0f, 0.2f);
        }
    }
}
