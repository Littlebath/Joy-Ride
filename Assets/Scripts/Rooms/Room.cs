using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Room : MonoBehaviour
{
    public enum RoomType 
    {
        Enemy,
        Empty,
        Boss
    }
    public RoomType roomType;
    public Door[] door;
    public GameObject enemies;
    public GameObject exitContainer;

    private void Update()
    {
        if (roomType == RoomType.Enemy)
        {
            if (enemies.transform.childCount <= 0)
            {
                OpenAllDoors();
            }
        }

        else if (roomType == RoomType.Boss)
        {
            if (enemies.transform.childCount <= 0)
            {
                OpenAllDoors();
                //Activate escape room.
                exitContainer.SetActive(true);
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
            //cam.SetActive(true);
            //Stop Layer from hiding

            if (roomType == RoomType.Enemy)
            {
                enemies.SetActive(true);
            }

            else if (roomType == RoomType.Boss)
            {
                enemies.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //cam.SetActive(false);
        }
    }
}
