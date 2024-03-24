using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        // Set initial alpha to 0
        Color startColor = textMeshPro.color;
        startColor.a = 0f;
        textMeshPro.color = startColor;

        // Start the fade-in coroutine
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color startColor = textMeshPro.color;

        while (timer < fadeDuration)
        {
            // Calculate the lerp value based on the time passed
            float progress = timer / fadeDuration;

            // Interpolate the alpha value
            float alpha = Mathf.Lerp(0f, 1f, progress);

            // Update the text color with the new alpha value
            Color newColor = startColor;
            newColor.a = alpha;
            textMeshPro.color = newColor;

            // Wait for the next frame
            yield return null;

            // Update the timer
            timer += Time.deltaTime;
        }

        // Ensure the text is fully visible at the end
        Color finalColor = startColor;
        finalColor.a = 1f;
        textMeshPro.color = finalColor;
    }
}