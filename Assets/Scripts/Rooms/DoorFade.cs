using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;


public class DoorFade : MonoBehaviour
{
    [SerializeField] private Animator tilemapAnim;
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject[] doors;

    private void Start()
    {
        enemies.SetActive(false);

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i] != null)
            {
                doors[i].SetActive(false);
            }
        }


    }

    private void Fade()
    {
        tilemapAnim.SetTrigger("Fade");
        enemies.SetActive(true);

        for (int i = 0; i < doors.Length; i++)
        {
            if (doors != null)
            {
                doors[i].SetActive(true);

            }
        }

    }

    private void ActivateLights()
    {
        Light2D[] lights = FindObjectsOfType<Light2D>();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Close Door");
            //Do hiding stuff
            Fade();

            if (FindObjectOfType<LightManager>().lightsOn)
            {
                ActivateLights();

            }
        }
    }
}
