using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound()
    {
        audioSource.Play();
    }

    public static void assignSound(AudioClip sound)
    {
        audioSource.clip = sound;
    }

    public static void setPitch(float value)
    {
        audioSource.pitch = value;
    }
    public static void setVolume(float value)
    {
        audioSource.volume = value;
    }

    public static bool isPlaying()
    {
        return audioSource.isPlaying;
    }
    public static void pauseSound()
    {
        audioSource.Pause();
    }

    public static void playOneShot(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
