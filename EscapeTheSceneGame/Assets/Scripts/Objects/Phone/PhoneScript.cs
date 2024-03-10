using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool canRing;

    private void Start()
    {
        canRing = false;
    }

    private void Update()
    {
        if (canRing && Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canRing=true;
        }
    }
}
