using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool canOpen;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool closeDoorAfter;

    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("Open", true);
                audioSource.Play();
                anim.SetBool("Close", false);


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
            if (closeDoorAfter)
            {
                anim.SetBool("Open", false);
                anim.SetBool("Close", true);
            }
            


        }
    }
}
