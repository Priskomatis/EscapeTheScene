using TMPro;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    private HighlightEffect highlight;
    private bool emissionToggled = false;

    [SerializeField] GameObject panel;
    [SerializeField] private TextMeshProUGUI text;

    private PickUpItem pickUpItem;
    private void Start()
    {
        // Initialize highlight effect
        highlight = GetComponent<HighlightEffect>();
        pickUpItem = FindObjectOfType<PickUpItem>();
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
        panel.SetActive(true);
        text.text = "Press E to PickUp the Candle";
        if (Input.GetKeyDown(KeyCode.E))
        {
            //highlight.ToggleEmission();
            pickUpItem.PickUp(this.gameObject);

            gameObject.SetActive(false);
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
