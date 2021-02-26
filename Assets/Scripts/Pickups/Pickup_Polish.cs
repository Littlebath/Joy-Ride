using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Polish : MonoBehaviour
{
    public GameObject exitRoom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Add new polish");
            exitRoom.SetActive(true);
            Destroy(gameObject);
        }
    }
}
