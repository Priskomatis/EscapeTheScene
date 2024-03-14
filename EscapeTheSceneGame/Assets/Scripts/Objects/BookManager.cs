using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] private Canvas bookCanvas;

    private UIController stateController;

    private void Start()
    {
        stateController = FindObjectOfType<UIController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            bookCanvas.gameObject.SetActive(true);
            stateController.EnterReadingBookState();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bookCanvas.gameObject.SetActive(false);
            stateController.ExitReadingBookState();
        }
    }
}
