using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookObject : MonoBehaviour
{

    private BookManager bookManager;

    private HighlightEffect highlight;

    [HideInInspector] public bool emissionToggled = false;
    [HideInInspector] public bool isOpen;

    public void Start()
    {
        highlight = GetComponent<HighlightEffect>();
        bookManager = FindObjectOfType<BookManager>();
        isOpen = false;
    }



    public void OpenBook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bookManager.ReadBook();
            isOpen = true;
        }
    }
    public void CloseBook()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bookManager.CloseBook();
            isOpen = false;
        }
    }

    public void ToggleEmmision(bool toggle)
    {
        if (toggle)
        {
            highlight.ToggleEmission();
        }
        else
        {
            highlight.ToggleEmission();
        }
    }

    /*private void OnTriggerEnter(Collider other)
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
    }*/

    /*private void OnTriggerExit(Collider other)
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
    }*/
}