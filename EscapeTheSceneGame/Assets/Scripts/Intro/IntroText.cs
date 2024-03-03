using System.Collections;
using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] textList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI continueText;



    private void Start()
    {
        textComponent.text = "";
        StartCoroutine(DisplayTextSequence());


    }

    private IEnumerator DisplayTextSequence()
    {
        for (int i = 0; i < textList.Length; i++)
        {
            yield return StartCoroutine(DisplayText(textList[i]));
            yield return WaitForInput(KeyCode.Space); //Wait for the "space" key press;
            textComponent.text = "";
            
        }
        audioSource.Stop(); //Stop the audio after displaying all texts;


    }

    private IEnumerator DisplayText(string text)
    {
        audioSource.Play(); //Start playing the audio when displaying text;
        for (int j = 0; j < text.Length; j++)
        {
            textComponent.text += text[j];
            yield return new WaitForSeconds(0.075f);
        }
        audioSource.Stop(); //Stop the audio after displaying the last letter of the text;
    }

    private IEnumerator WaitForInput(KeyCode key)
    {
        while (!Input.GetKeyDown(key))
        {
            yield return null;
        }
    }
}
