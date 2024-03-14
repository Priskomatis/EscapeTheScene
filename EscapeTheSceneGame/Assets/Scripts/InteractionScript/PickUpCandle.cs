using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCandle : MonoBehaviour
{
    [SerializeField] private GameObject candle;
    private TextAppear textAppear;
    private HighlightEffect highlight;

    private bool emissionToggled = false;

    private void Start()
    {
        //Highlight effect;
        highlight = GetComponent<HighlightEffect>();


        candle.SetActive(false);
        textAppear = FindObjectOfType<TextAppear>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!emissionToggled) // Check if emission has not been toggled yet
            {
                highlight.ToggleEmission();
                emissionToggled = true; // Set the flag to true
            }

            textAppear.SetText("Press 'E' to pick up the candle.");
            if (Input.GetKeyDown(KeyCode.E))
            {
                textAppear.RemoveText();
                this.gameObject.SetActive(false);
                candle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (emissionToggled) // Check if emission has been toggled
        {
            textAppear.RemoveText();
            highlight.ToggleEmission();
            emissionToggled = false; // Reset the flag
        }
    }
}