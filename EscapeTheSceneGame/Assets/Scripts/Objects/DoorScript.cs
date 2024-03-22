using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource close;
    [SerializeField] private AudioSource open;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            OpenDoor();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            CloseDoor();
        }
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
}
