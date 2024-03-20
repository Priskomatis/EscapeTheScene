using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    [SerializeField] Transform InteractorSource;
    [SerializeField] float InteractRange;

    [SerializeField] GameObject panel;
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
        else
        {
            panel.SetActive(false);
            text.text = "";
        }

    }
}
