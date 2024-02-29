using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRainScript : MonoBehaviour
{
    [SerializeField] private AudioSource rainAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Yes");
            StartCoroutine(FadeAudio.StartFade(rainAudio, 3f, 0f));
        }
    }
}
