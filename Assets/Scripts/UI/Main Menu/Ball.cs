using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    float x;
    float y;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        x = Random.Range(-1f, 1f);
        y = Random.Range(-1f, 1f);
        direction = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -1 * direction.y;
        }

        else if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -1 * direction.x;
        }

    }
}
