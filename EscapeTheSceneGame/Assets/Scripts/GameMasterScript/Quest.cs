using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI questText;
    public string activeQuest;
    private QuestTextScript questTextAnim;

    private void Start()
    {
        questTextAnim = FindObjectOfType<QuestTextScript>();
    }

    public void ActivateQuest(string quest)
    {
        questText.gameObject.SetActive(true);
        questText.text = quest;
        questTextAnim.FadeIn();
    }

    public void CompleteQuest()
    {
        
        activeQuest = "";
        questTextAnim.FadeOut();
        StartCoroutine(WaitForText());
        
    }

    IEnumerator WaitForText()
    {
        yield return new WaitForSeconds(2f);
        questText.text = "";
        questText.gameObject.SetActive(false);


    }
    
    
}
