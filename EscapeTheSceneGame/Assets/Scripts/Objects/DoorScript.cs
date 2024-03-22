using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;

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
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");
    }
}
