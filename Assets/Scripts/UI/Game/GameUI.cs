using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public GameObject playerHealth;
    public PlayerController pc;

    private void Update()
    {
        playerHealth.GetComponent<Text>().text = "Health: " + pc.health;
    }
}
