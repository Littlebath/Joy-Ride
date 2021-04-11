using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_KeyHold : MonoBehaviour
{
    private List<Pickup_Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Pickup_Key.KeyType>(); 
    }

    public void AddKey (Pickup_Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }

    public void RemoveKey(Pickup_Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Pickup_Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup_Key key = collision.GetComponent<Pickup_Key>();

        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }
    }
}
