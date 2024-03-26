using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookObject : MonoBehaviour, IInteractable
{

    private BookManager bookManager;
    private HighlightEffect highlight;
    private bool emissionToggled = false;

    [HideInInspector] public bool isOpen;


    [SerializeField] private string textToDisplay;

    private TextAppear textAppear;

    private Quest quest;

    public void Start()
    {
        highlight = GetComponent<HighlightEffect>();
        bookManager = FindObjectOfType<BookManager>();
        textAppear = GetComponent<TextAppear>();
        isOpen = false;
        quest = FindObjectOfType<Quest>();
    }
    public void ToggleEmmision()
    {
        if (!emissionToggled) // Check if emission has not been toggled yet
        {
            highlight.ToggleEmission();
            emissionToggled = !emissionToggled; // Set the flag to true
        }
    }
    public void OnInteractExit()
    {
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }
    public void OnInteractEnter()
    {
        ToggleEmmision();
        emissionToggled = !emissionToggled;
    }

    public void Interact()
    {
        textAppear.SetText(textToDisplay);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                OpenBook();
                quest.CompleteQuest();
                isOpen = true;
            }else
            {
                CloseBook();

                isOpen = false;
            }
        }
        
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
    
}