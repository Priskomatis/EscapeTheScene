using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool canRing;

    private QuestManager quest;
    private void Start()
    {
        canRing = false;
        quest = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        if (canRing && Input.GetKeyDown(KeyCode.R))
        {
            audioSource.Play();
            quest.ActivateQuest("Read the Book");

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canRing=true;
        }
    }
}
