using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObject : MonoBehaviour
{

    private BookManager bookManager;
    private bool canRead;
    private bool isOpen;

    private TextAppear textAppear;
    public void Start()
    {
        bookManager = FindObjectOfType<BookManager>();
        textAppear = FindObjectOfType<TextAppear>();
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
                textAppear.RemoveText();
            }
            isOpen = !isOpen; // Toggle the state of the book
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canRead = true;
            textAppear.SetText("Press 'E' to read the Book.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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