using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGAudioScript : MonoBehaviour
{
    
    public AudioClip track1;
    public AudioClip track2;
    private AudioSource audioSource;
    private bool isPlayingTrack1 = true;

    void Start()
    {
        // Get the AudioSource component from the parent GameObject
        audioSource = GetComponentInParent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found in parent GameObject!");
            return;
        }
        // Start playing track 1 initially
        audioSource.clip = track1;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Change the audio track when player enters the trigger zone
            if (isPlayingTrack1)
            {
                audioSource.clip = track2;
            }
            else
            {
                audioSource.clip = track1;
            }
            audioSource.Play();
            isPlayingTrack1 = !isPlayingTrack1; // Toggle the track flag
        }
    }
}