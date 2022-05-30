using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    public AudioMixerGroup audioMixer;
    
    
    private void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = audioMixer;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialblend;
            s.source.rolloffMode = s.rolloffMode;
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        //if (PauseMenu.GameIsPaused)
        //{
        //    s.source.pitch*= .5f;
        //}
        s.source.Play();
    }

    public void Pause (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Pause();

    }
}
