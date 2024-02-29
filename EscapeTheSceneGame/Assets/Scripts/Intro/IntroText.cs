using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    public float letterDelay = 0.1f;
    public string fullText;
    private string currentText = "";
    [SerializeField] private TextMeshProUGUI textComponent;

    private void Start()
    {
        fullText = textComponent.text.ToString();
        //textComponent.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;
            yield return new WaitForSeconds(letterDelay);
        }
    }
}

