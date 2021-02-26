using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : MonoBehaviour
{
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().health += health;
            Destroy(gameObject);
        }
    }
}
