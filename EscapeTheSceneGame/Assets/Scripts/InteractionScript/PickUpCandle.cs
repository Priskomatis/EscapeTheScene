using UnityEngine;

public class PickUpCandle : MonoBehaviour
{
    private TextAppear textAppear;
    private HighlightEffect highlight;
    private bool playerInRange = false;

    private PickUpItem pickUpItem;
    private void Start()
    {
        // Initialize highlight effect
        highlight = GetComponent<HighlightEffect>();
        textAppear = FindObjectOfType<TextAppear>();

        pickUpItem = FindObjectOfType<PickUpItem>();
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerInRange)
        {
            playerInRange = true;
            textAppear.SetText("Press 'E' to pick up the candle.");
            highlight.ToggleEmission(); // Enable highlight only if player just entered the range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerInRange)
        {
            playerInRange = false;
            textAppear.RemoveText();
            highlight.ToggleEmission(); // Disable highlight only if player just exited the range
        }
    }

    private void PickUp()
    {
        //candle.SetActive(true);
        highlight.ToggleEmission();
        pickUpItem.PickUp(this.gameObject);

        gameObject.SetActive(false);

        textAppear.RemoveText();
    }
}
