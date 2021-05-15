using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Pickup_Polish : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject particles;

    [SerializeField] private GameObject[] text;
    public enum PolishType
    {
        Lights,
        CameraShake,
        Audio
    }

    public PolishType polishType;

    private void Start()
    {
        gameObject.GetComponent<Light2D>().enabled = true;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed);
    }

    private IEnumerator ActivatePolish()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        FindObjectOfType<AudioManager>().PlaySound("Polish");

        Instantiate(particles, transform.position, Quaternion.identity);
        FindObjectOfType<Fade>().SetFade(false);

        Time.timeScale = 0.5f;
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<Fade>().SetFade(true);

        if (polishType == PolishType.Lights)
        {
            //Enable Lights
            FindObjectOfType<LightManager>().ActivateLights();
            text[0].SetActive(true);

        }

        else if (polishType == PolishType.Audio)
        {
            //Enable Audio
            FindObjectOfType<AudioManager>().MuteVolume(false);
            text[1].SetActive(true);

        }

        else if (polishType == PolishType.CameraShake)
        {
            //Enable Camera Shake
            FindObjectOfType<CameraController>().canShake = true;
            text[2].SetActive(true);

        }

        Time.timeScale = 1f;
        FindObjectOfType<PlayerController>().colorChange++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivatePolish());
        }
    }
}
