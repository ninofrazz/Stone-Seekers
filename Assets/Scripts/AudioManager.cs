using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;                // Name of the sound
    public AudioClip clip;             // The actual audio clip

    [Range(0f, 1f)]
    public float volume = 0.7f;        // Volume control for the sound
    [Range(0.1f, 3f)]
    public float pitch = 1f;           // Pitch control for the sound

    public bool loop = false;          // Whether the sound should loop

    [HideInInspector]
    public AudioSource source;         // AudioSource that will play the sound (hidden in the Inspector)
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;             // Array of sounds

    private void Awake()
    {
        // Loop through all sounds and attach an AudioSource to this gameObject for each
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Method to play a sound by its name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    // Method to stop a sound by its name
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
