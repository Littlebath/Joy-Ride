using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletCollisionParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletCollisionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
