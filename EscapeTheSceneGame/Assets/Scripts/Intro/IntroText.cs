using System.Collections;
using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] textList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI continueText;
    [SerializeField] private float letterDisplaySpeed = 0.075f;
    [SerializeField] private float continueTextOpacityDuringDisplay = 0.5f;
    private Color originalContinueTextColor;

    private void Start()
    {
        textComponent.text = "";
        originalContinueTextColor = continueText.color;
        StartCoroutine(DisplayTextSequence());
    }

    private IEnumerator DisplayTextSequence()
    {
        for (int i = 0; i < textList.Length; i++)
        {
            continueText.color = new Color(originalContinueTextColor.r, originalContinueTextColor.g, originalContinueTextColor.b, continueTextOpacityDuringDisplay);
            yield return StartCoroutine(DisplayText(textList[i]));

            continueText.color = originalContinueTextColor;

            yield return WaitForInput(KeyCode.Space); // Wait for the "space" key press;
            textComponent.text = "";
        }
        audioSource.Stop(); // Stop the audio after displaying all texts;
    }

    private IEnumerator DisplayText(string text)
    {
        audioSource.Play(); // Start playing the audio when displaying text;
        for (int j = 0; j < text.Length; j++)
        {
            textComponent.text += text[j];
            yield return new WaitForSeconds(letterDisplaySpeed);
        }
        audioSource.Stop(); // Stop the audio after displaying the last letter of the text;
    }

    private IEnumerator WaitForInput(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }
    }
}
