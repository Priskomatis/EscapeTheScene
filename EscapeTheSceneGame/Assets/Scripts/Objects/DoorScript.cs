using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource close;
    [SerializeField] private AudioSource open;
    public bool locked;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            if (!locked)
            {
                OpenDoor();

            }
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (locked)
            {
                CloseDoor();
            }
            
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
