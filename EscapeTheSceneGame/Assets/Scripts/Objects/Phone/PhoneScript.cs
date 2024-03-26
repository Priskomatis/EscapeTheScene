using System.Collections;
using UnityEngine;

public class PhoneScript : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource currentCall;
    [SerializeField] private AudioSource pickUpCall;

    private TextAppear textAppear;



    private Quest quest;
    private void Start()
    {
        quest = FindObjectOfType<Quest>();
        textAppear = FindObjectOfType<TextAppear>();
        audioSource.Play();

    }




    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Stop();
            PlayCall();
            
            quest.ActivateQuest("Read the Book");

        }
    }
    private void PlayCall()
    {
        pickUpCall.Play();
        StartCoroutine(waitForPhonecall());
    }

    IEnumerator waitForPhonecall()
    {
        while (pickUpCall.isPlaying)
        {
            yield return null;
        }
        currentCall.Play();
    }

    public void OnInteractEnter()
    {
        textAppear.SetText("Pick up the phone");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
