using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource audioSource;
    private bool canRing;

    private TextAppear textAppear;



    private Quest quest;
    private void Start()
    {
        canRing = false;
        quest = FindObjectOfType<Quest>();
        textAppear = FindObjectOfType<TextAppear>();

    }


    public void Interact()
    {
        if (canRing && Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Play();
            quest.ActivateQuest("Read the Book");

        }
    }

    public void OnInteractEnter()
    {
        canRing = true;
        textAppear.SetText("Pick up the phone");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
