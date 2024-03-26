using System.Collections;
using TMPro;
using UnityEngine;

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
    private FadeText fadeText;

    private Health stressSystem; // Reference to the Health script
    private float nextUpdateTime; // Time for next text update
    private const float updateInterval = 25f; // Time interval to display the text
    private Coroutine textDisappearCoroutine; // Coroutine reference for text disappearance

    private void Start()
    {
        stressSystem = FindObjectOfType<Health>(); // Get reference to Health script
        nextUpdateTime = Time.time + updateInterval; // Set initial update time
        fadeText = thoughtsText.GetComponent<FadeText>(); // Get reference to FadeText script
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

        // Start the fade-in coroutine from FadeText script
        fadeText.FadeInText();

        // If the text disappearance coroutine is already running, don't start a new one
        if (textDisappearCoroutine == null)
        {
            // Start a new coroutine to make the text disappear after 2 seconds
            textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
        }
    }

    // Coroutine to make the text disappear after 2 seconds
    private IEnumerator TextDisappearCoroutine()
    {
        displayText = true;
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        fadeText.FadeOutText(); // Start the fade-out coroutine from FadeText script
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
                Debug.Log("Test");
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

        // Start the fade-in coroutine from FadeText script
        fadeText.FadeInText();

        // Cancel any existing coroutine before starting a new one
        if (textDisappearCoroutine != null)
            StopCoroutine(textDisappearCoroutine);

        // Start a new coroutine to make the text disappear after 2 seconds
        textDisappearCoroutine = StartCoroutine(TextDisappearCoroutine());
    }
}
