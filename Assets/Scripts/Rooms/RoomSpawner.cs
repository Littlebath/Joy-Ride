using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{/*
    public enum OpenDirection
    {
        Left,
        Up,
        Right,
        Down
    };
    public OpenDirection openDirection;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("RoomGenerator", 0.1f);
    }

    private void Update()
    {
        RoomGenerator();
    }

    private void RoomGenerator ()
    {
        if (!spawned)
        {
            switch (openDirection)
            {
                case OpenDirection.Left:
                    //Spawn a room with left door
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;

                case OpenDirection.Up:
                    //Spawn a room with up door
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;

                case OpenDirection.Right:
                    //Spawn a room with right door
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;

                case OpenDirection.Down:
                    //Spawn a room with down door
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;

                default:
                    Debug.Log("Missing an exit point");
                    break;
            }

            spawned = true;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //Spawn walls blocking off
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }*/

}
