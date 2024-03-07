using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAudioScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float fadeDuration = 10.0f;
    private bool isFadingIn = false;


    private void Start()
    {
        if(audioSource == null)
        {
            return;
        }

        FadeIn();
    }

    void Update()
    {
        // Check if fading in and update the volume accordingly
        if (isFadingIn)
        {
            // Calculate the progress of the fade
            float progress = Mathf.Clamp01(Time.time / fadeDuration);

            // Increase the volume over time
            audioSource.volume = Mathf.Lerp(0f, 0.6f, progress);

            // Check if fade is complete
            if (progress >= 1.0f)
            {
                isFadingIn = false;
            }
        }
    }

    void FadeIn()
    {
        audioSource.volume = 0f;
        isFadingIn = true;
    }

}
