using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    [SerializeField] private float distance;
    private Dictionary<string, System.Action> objectActions = new Dictionary<string, System.Action>();
    private Transform lastHitTransform;


    [SerializeField] GameObject panel;
    [SerializeField] private TextMeshProUGUI text;


    //private ChestManager chestManager;
    private bool emissionToggled = false;


    private void Start()
    {
        
        // Populate the dictionary with object names and corresponding actions
        objectActions.Add("Book", HandleBook);
        objectActions.Add("Chest", HandleChest);
        objectActions.Add("Door", HandleDoor);
        objectActions.Add("Candle", HandleCandle);

        //chestManager = FindObjectOfType<ChestManager>();
    }

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, objectLayer))
        {
            if (hit.collider.transform != null)
            {
                lastHitTransform = hit.transform;
                string objectTag = lastHitTransform.gameObject.tag;

                // Check if the object has an action associated with it
                if (objectActions.ContainsKey(objectTag))
                {
                    // Perform the action associated with the object
                    objectActions[objectTag].Invoke();
                }

            }
        }
        else
        {
            EraseText();
            
        }
    }


    //Here we handle each function for when we are close to the gameobject;
    private void HandleBook()
    {
        Debug.Log("Detected Book!");


        // Check if the book is already open
        if (lastHitTransform.GetComponent<BookObject>().isOpen)
        {
            lastHitTransform.GetComponent<BookObject>().CloseBook();
        }
        else
        {
            // Open the book if it's closed
            IndicatorText("Press E to Read the Book");
            lastHitTransform.GetComponent<BookObject>().OpenBook();
        }
    }

    private void HandleChest()
    {
        
        Debug.Log("Detected Chest!");
        IndicatorText("Press E to Open Chest");
        lastHitTransform.GetComponent<ChestManager>().OpenChest();
    }

    private void HandleCandle()
    {
        Debug.Log("Detected Candle!");

        IndicatorText("Press E to Pickup the Candle");
        lastHitTransform.GetComponent<Candle>().PickUp();
        lastHitTransform.GetComponent<Candle>().ToggleEmmision();
    }
    private void HandleDoor()
    {
        Debug.Log("Detected Door!");
        // Example: lastHitTransform.GetComponent<DoorScript>().DoSomething();
        
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
