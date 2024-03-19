using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool canOpen;

    [SerializeField] private bool closeDoorAfter;

    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorClose;

    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Open");
                doorOpen.Play();
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            anim.SetTrigger("Close");
            doorClose.Play();
        }
    }
}
