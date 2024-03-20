using TMPro;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    private HighlightEffect highlight;
    private bool emissionToggled = false;

    [SerializeField] private string textToDisplay;

    private TextAppear textAppear;
    private PickUpItem pickUpItem;

    private void Start()
    {
        // Initialize highlight effect
        highlight = GetComponent<HighlightEffect>();
        pickUpItem = FindObjectOfType<PickUpItem>();
        textAppear = GetComponent<TextAppear>();
    }


    public void ToggleEmmision()
    {
        if (!emissionToggled) // Check if emission has not been toggled yet
        {
            highlight.ToggleEmission();
            emissionToggled = !emissionToggled; // Set the flag to true
        }
    }


    public void Interact()
    {
        textAppear.SetText(textToDisplay);
        if (Input.GetKeyDown(KeyCode.E))
        {
            //highlight.ToggleEmission();
            pickUpItem.PickUp(this.gameObject);

            textAppear.RemoveText();
            Destroy(gameObject);
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
}
