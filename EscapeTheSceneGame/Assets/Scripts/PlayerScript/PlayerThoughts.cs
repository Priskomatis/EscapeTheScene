using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerThoughts : MonoBehaviour
{
    public bool displayText;

    [SerializeField] private string[] doorLockedTexts;

    // State Texts
    [SerializeField] private string[] calmTexts;
    [SerializeField] private string[] mildStressTexts;
    [SerializeField] private string[] highStressTexts;
    [SerializeField] private string[] panicTexts;

    [SerializeField] private TextMeshProUGUI thoughtsText;

    private Health stressSystem; // Reference to the Health script
    private float nextUpdateTime; // Time for next text update
    private const float updateInterval = 25f; // Time interval to display the text
    private Coroutine textDisappearCoroutine; // Coroutine reference for text disappearance

    private void Start()
    {
        stressSystem = FindObjectOfType<Health>(); // Get reference to Health script
        nextUpdateTime = Time.time + updateInterval; // Set initial update time
    }

    private void Update()
    {
        // Check if it's time to update the text
        if (Time.time >= nextUpdateTime)
        {
            UpdateThoughtsText();
            nextUpdateTime += updateInterval; // Update next update time
        }
    }

    public void DoorLockedText()
    {
        int textIndex = Random.Range(0, doorLockedTexts.Length);
        thoughtsText.gameObject.SetActive(true);
        thoughtsText.text = doorLockedTexts[textIndex];

        // Cancel any existing coroutine before starting a new one
        if (textDisappearCoroutine != null)
            StopCoroutine(textDisappearCoroutine);

        // Start a new coroutine to make the text disappear after 3 seconds
        textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
    }

    // Coroutine to make the text disappear after 3 seconds
    private IEnumerator TextDisappearCoroutine()
    {
        displayText = true;
        yield return new WaitForSeconds(2f); // Wait for 3 seconds
        thoughtsText.gameObject.SetActive(false); // Deactivate the GameObject
        displayText = false;

    }

    // Update the thoughts text content based on the player's stress state
    public void UpdateThoughtsText()
    {
        // Select random text from the appropriate array based on the current stress state
        string[] selectedTexts;
        switch (stressSystem.GetState())
        {
            case Health.StressState.Calm:
                selectedTexts = calmTexts;
                break;
            case Health.StressState.MildStress:
                selectedTexts = mildStressTexts;
                break;
            case Health.StressState.HighStress:
                selectedTexts = highStressTexts;
                break;
            case Health.StressState.Panic:
                selectedTexts = panicTexts;
                break;
            default:
                selectedTexts = calmTexts; // Default to calm texts if state is unknown
                break;
        }

        // Select a random text from the selected array
        int textIndex = Random.Range(0, selectedTexts.Length);

        // Display the selected text
        thoughtsText.gameObject.SetActive(true);
        thoughtsText.text = selectedTexts[textIndex];

        // Cancel any existing coroutine before starting a new one
        if (textDisappearCoroutine != null)
            StopCoroutine(textDisappearCoroutine);

        // Start a new coroutine to make the text disappear after 3 seconds
        textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
    }
}
