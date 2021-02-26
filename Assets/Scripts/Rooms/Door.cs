using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room room;
    private GameObject doorObj;

    // Start is called before the first frame update
    void Start()
    {
        doorObj = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoors ()
    {
        doorObj.GetComponent<SpriteRenderer>().enabled = true;
        doorObj.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OpenDoors()
    {
        doorObj.GetComponent<SpriteRenderer>().enabled = false;
        doorObj.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (room.roomType == Room.RoomType.Enemy)
        {
            if (collision.CompareTag("Player"))
            {
                Debug.Log("Close Door");
                room.CloseAllDoors();
            }
        }
    }
}
