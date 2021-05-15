using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private bool isVisible;
    private RawImage fadeItem;
    [SerializeField] private float fadeSpeed;

    private bool startFade;
    private bool fadeIn;

    private float timer;
    private void Start()
    {
        SetVisiblity(isVisible);
        fadeItem = gameObject.GetComponent<RawImage>();
        fadeItem.enabled = true;
    }

    private void Update()
    {
        if (startFade)
        {
            if (fadeIn)
            {
                fadeItem.color = Color.Lerp(Color.black, Color.clear, Mathf.Lerp(0f, fadeSpeed, timer));
                timer += Time.deltaTime;
            }

            else
            {
                fadeItem.color = Color.Lerp(Color.clear, Color.black, Mathf.Lerp(0f, fadeSpeed, timer));
                timer += Time.deltaTime;
            }
        }
    }

    public void SetFade (bool fadeType)
    {
        timer = 0f;
        fadeIn = fadeType;
        startFade = true;
    }

    private void SetVisiblity(bool isVisible)
    {
        if (isVisible == true)
        {
            gameObject.GetComponent<RawImage>().color = Color.black;
            //fadeIn = false;
        }

        else
        {
            gameObject.GetComponent<RawImage>().color = Color.clear;
            //fadeIn = true;
        }
    }
}
