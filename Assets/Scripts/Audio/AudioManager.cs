using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] private bool muteAtStart;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlaySound("Theme");
        FindObjectOfType<Fade>().SetFade(true);
        MuteVolume(muteAtStart);
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void MuteVolume (bool mute)
    {
        if (mute == true)
        {
            AudioListener.volume = 0.0f;

        }

        else
        {
            AudioListener.volume = 1.0f;

        }
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip Clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;
}



