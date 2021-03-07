using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Designer values")]
    public float health = 1;

    Vector2 playerPos;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateToPlayer();
    }

    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void RotateToPlayer ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 lookDir = playerPos - rb2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2D.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Player"))
        {
            TakeDamage(1f);
            //Debug.Log("Hit by bullet");
        }
    }


}
