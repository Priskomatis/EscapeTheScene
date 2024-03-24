using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerThoughts : MonoBehaviour
{
    [SerializeField] private string[] doorLockedTexts;



    [SerializeField] private TextMeshProUGUI thoughtsText;

    public void DoorLockedText()
    {
        int textIndex = Random.Range(0, doorLockedTexts.Length);
        thoughtsText.gameObject.SetActive(true);
        thoughtsText.text = doorLockedTexts[textIndex];
    }
}
