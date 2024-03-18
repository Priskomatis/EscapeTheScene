using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    public string activeQuest;

    public void ActivateQuest(string quest)
    {
        questText.gameObject.SetActive(true);
        questText.text = quest;
    }

    public void CompleteQuest()
    {
        questText.text = "";
        activeQuest = "";
        questText.gameObject.SetActive(false);
    }
}
