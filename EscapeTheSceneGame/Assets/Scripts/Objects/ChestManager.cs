using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void OpenChest()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Open");

        }
    }

}
