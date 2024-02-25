using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string textToPut)
    {
        panel.SetActive(true);
        text.text = textToPut;
    }
    public void RemoveText()
    {
        panel.SetActive(false);
    }
}
