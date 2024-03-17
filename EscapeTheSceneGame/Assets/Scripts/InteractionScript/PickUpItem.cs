using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private GameObject placeHolder;
    [SerializeField] private Transform parentObject;

    public void PickUp(GameObject item)
    {
        Debug.Log("Picking up Item");
        GameObject pickedUpItem = Instantiate(item, placeHolder.transform.position, placeHolder.transform.rotation);
        pickedUpItem.transform.parent = parentObject;

        RemoveAllScripts(pickedUpItem);
    }

    private void RemoveAllScripts(GameObject gameObject)
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            // Check if the script is not this script itself
            if (script != this)
            {
                Destroy(script);
            }
        }
    }
}
