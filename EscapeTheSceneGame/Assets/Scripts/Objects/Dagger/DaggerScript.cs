using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour, IInteractable
{

    private PickUpItem pickUp;
    private TextAppear textAppear;
    private void Start()
    {
        pickUp = FindObjectOfType<PickUpItem>();
        textAppear = FindObjectOfType<TextAppear>();
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pickUp.PickUp(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void OnInteractEnter()
    {
        textAppear.SetText("Pickup the Dagger");
    }

    public void OnInteractExit()
    {
        textAppear.RemoveText();
    }
}
