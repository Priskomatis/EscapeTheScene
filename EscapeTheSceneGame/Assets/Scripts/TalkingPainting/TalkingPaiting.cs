using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TalkingPaiting : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    private TextAppear textAppear;

    private bool canInteract = false;

    private void Start()
    {
        textAppear = FindObjectOfType<TextAppear>();
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            textAppear.RemoveText();
            video.Play();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            textAppear.SetText("Press 'E' to interact");
            canInteract = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textAppear.RemoveText();
            canInteract = false;

        }
    }
}
