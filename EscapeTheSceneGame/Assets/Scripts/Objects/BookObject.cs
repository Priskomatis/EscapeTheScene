using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObject : MonoBehaviour
{

    private BookManager bookManager;
    private bool canRead;
    private bool isOpen;

    private TextAppear textAppear;

    private HighlightEffect highlight;

    private bool emissionToggled = false;

    private QuestManager quest;


    public void Start()
    {
        highlight = GetComponent<HighlightEffect>();
        bookManager = FindObjectOfType<BookManager>();
        textAppear = FindObjectOfType<TextAppear>();
        quest = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        // Check if player can read and has pressed the interaction key (E)
        if (canRead && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                bookManager.CloseBook();
            }
            else
            {
                bookManager.ReadBook();
                quest.CompleteQuest();

                textAppear.RemoveText();
            }
            isOpen = !isOpen; // Toggle the state of the book
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!emissionToggled) // Check if emission has not been toggled yet
            {
                highlight.ToggleEmission();
                emissionToggled = true; // Set the flag to true
            }
            canRead = true;
            textAppear.SetText("Press 'E' to read the Book.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (emissionToggled) // Check if emission has been toggled
            {
                highlight.ToggleEmission();
                emissionToggled = false; // Reset the flag
            }
            canRead = false;
            if (isOpen) // If the player exits the trigger while the book is open, close it
            {
                bookManager.CloseBook();
                textAppear.RemoveText();
                isOpen = false;
            }
            textAppear.RemoveText();
        }
    }
}