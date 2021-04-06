using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHead : MonoBehaviour
{
    public int characterID;
    public Sprite[] characterHeads;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = characterHeads[characterID];
    }

}
