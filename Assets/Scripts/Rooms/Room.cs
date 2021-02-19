using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    public enum RoomType 
    {
        Enemy,
        Empty
    }
    public RoomType roomType;
    public GameObject cam;
    public Door[] door;
    public GameObject enemies;

    private void Update()
    {
        if (roomType == RoomType.Enemy)
        {
            if (enemies.transform.childCount <= 0)
            {
                OpenAllDoors();
            }
        }
    }

    public void CloseAllDoors ()
    {
        for (int i = 0; i < door.Length; i++)
        {
            door[i].CloseDoors();
        }
    }

    public void OpenAllDoors ()
    {
        for (int i = 0; i < door.Length; i++)
        {
            door[i].OpenDoors();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.SetActive(true);

            if (roomType == RoomType.Enemy)
            {
                enemies.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam.SetActive(false);
        }
    }
}
