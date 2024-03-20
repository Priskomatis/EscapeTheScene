using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TalkingPaiting : MonoBehaviour, IInteractable
{
    [SerializeField] private VideoPlayer video;
    private TextAppear textAppear;
    [SerializeField] private string textToDisplay;

    private bool canInteract = false;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            video.Play();
            textAppear.RemoveText();
        }
    }

    public void OnInteractEnter()
    {
        textAppear.SetText(textToDisplay);
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }

    private void Start()
    {
        textAppear = FindObjectOfType<TextAppear>();
    }

}
