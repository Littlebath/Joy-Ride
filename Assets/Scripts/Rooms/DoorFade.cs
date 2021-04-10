using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorFade : MonoBehaviour
{
    [SerializeField] private Animator tilemapAnim;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject doors;

    private void Start()
    {
        enemies.SetActive(false);

        if (doors != null)
        {
            doors.SetActive(false);

        }
    }

    private void Fade()
    {
        tilemapAnim.SetTrigger("Fade");
        enemies.SetActive(true);

        if (doors != null)
        {
            doors.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Close Door");
            //Do hiding stuff
            Fade();
        }
    }
}
