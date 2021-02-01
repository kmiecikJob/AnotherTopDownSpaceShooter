using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private int backgroundIndex = 0;
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.playOnAwake = false;
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
        PlayList();
    }

    public void PlayRandomVolumeAndPitch(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.volume = (UnityEngine.Random.Range(0.1f, .3f));
            s.pitch = (UnityEngine.Random.Range(1f, 3f));
            s.source.Play();
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            s.source.Play();
        }
    }

    private void PlayList()
    {
        Sound s = sounds[backgroundIndex];
        s.source.Play();
        ++backgroundIndex;
        if(backgroundIndex > 8)
        {
            backgroundIndex = 0;
        }
        Invoke("PlayList", s.clip.length);
    }

    public bool CheckIfContain(string name)
    {
        foreach(Sound s in sounds)
        {
            if(s.name == name)
            {
                return true;
            }
        }
        return false;
    }

}
