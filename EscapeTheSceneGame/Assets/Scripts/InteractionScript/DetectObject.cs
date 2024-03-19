using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float distance;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text;

    private Transform lastHitTransform;
    private BookObject lastHitBookObject;

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, objectLayer))
        {
            if (hit.collider != null)
            {
                Transform hitTransform = hit.transform;

                if (hitTransform.CompareTag("Book"))
                {
                    HandleBook(hitTransform.GetComponent<BookObject>());
                }
            }
        }
        else
        {
            ResetEmission();
            EraseText();
        }
    }

    private void HandleBook(BookObject book)
    {
        Debug.Log("Detected Book!");

        // Highlight the book if it's not already highlighted
        if (book != lastHitBookObject)
        {
            ResetEmission();
            book.ToggleEmmision(true);
            lastHitBookObject = book;
        }

        // Check if the book is already open
        if (book.GetComponent<BookObject>().isOpen)
        {
            
            book.GetComponent<BookObject>().CloseBook();
        }
        else
        {
            // Open the book if it's closed
            IndicatorText("Press E to Read the Book");
            book.GetComponent<BookObject>().OpenBook();
        }
    }

    private void ResetEmission()
    {
        if (lastHitBookObject != null)
        {
            lastHitBookObject.ToggleEmmision(false);
            lastHitBookObject = null;
        }
    }

    private void IndicatorText(string indicator)
    {
        panel.SetActive(true);
        text.text = indicator;
    }

    private void EraseText()
    {
        panel.SetActive(false);
    }
}
