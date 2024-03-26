using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    private Animator anim;
    [SerializeField] private AudioSource close;
    [SerializeField] private AudioSource open;
    [SerializeField] private AudioSource lockedAudio;
    public bool locked;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        open.Play();
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");

    }
    public void CloseAudio()
    {
        close.Play();
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!locked)
            {
                OpenDoor();
            }
            else
            {
                PlayerThoughts.FindObjectOfType<PlayerThoughts>().DoorLockedText();
                lockedAudio.Play();
            }
        }
    }

    public void OnInteractEnter()
    {
        Debug.Log("Can Open door");
    }

    public void OnInteractExit()
    {
        Debug.Log("Cannot Open door");
    }
}
