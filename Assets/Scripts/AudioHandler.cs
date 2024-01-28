using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance; // Singleton instance

    //public AudioSource backgroundMusic;
    public AudioSource audioSource;

    void Awake()
    {
        // Ensure there is only one instance of AudioHandler
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Play the background music when the script starts
        //backgroundMusic.Play();
    }

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
