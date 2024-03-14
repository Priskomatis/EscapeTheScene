using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private Canvas bookCanvas;

    private UIController stateController;
    private bool canRead;

    private void Start()
    {
        stateController = FindObjectOfType<UIController>();
    }

  
    public void ReadBook()
    {
        bookCanvas.gameObject.SetActive(true);
        stateController.EnterReadingBookState();
    }

    public void CloseBook()
    {
        bookCanvas.gameObject.SetActive(false);
        stateController.ExitReadingBookState();
    }

    
}

