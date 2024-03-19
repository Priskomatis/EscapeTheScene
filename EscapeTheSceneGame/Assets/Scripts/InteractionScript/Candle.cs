using UnityEngine;

public class Candle : MonoBehaviour
{
    private HighlightEffect highlight;
    private bool emissionToggled = false;

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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            highlight.ToggleEmission(); // Enable highlight only if player just entered the range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            highlight.ToggleEmission(); // Disable highlight only if player just exited the range
        }
    }*/

    public void PickUp()
    {
        //candle.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            highlight.ToggleEmission();
            pickUpItem.PickUp(this.gameObject);

            gameObject.SetActive(false);
        }
    }
}
