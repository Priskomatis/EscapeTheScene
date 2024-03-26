using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private PlayerThoughts playerThoughts;

    private void Start()
    {
        playerThoughts = FindObjectOfType<PlayerThoughts>();
    }

    public void SetText(string textToPut)
    {
        text.text = textToPut;
        text.gameObject.SetActive(true);

    }
    public void RemoveText()
    {
        text.gameObject.SetActive(false);
    }
}
