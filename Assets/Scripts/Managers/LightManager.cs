using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    public bool lightsOn;
    public GameObject globalLight;
    public Light2D[] lights;

    private void Awake()
    {
        lights = FindObjectsOfType<Light2D>();

        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = false;
        }

        globalLight.GetComponent<Light2D>().enabled = true;
        globalLight.GetComponent<Light2D>().intensity = 1f;
    }

    public void ActivateLights()
    {
        globalLight.GetComponent<Light2D>().intensity = 0.1f;
        lights = FindObjectsOfType<Light2D>();


        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = true;
            lightsOn = true;
        }

    }

}
