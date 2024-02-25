using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInEffect : MonoBehaviour
{

    [SerializeField] GameObject displayPanel;


    
    public void ActivatePannel()
    {
        displayPanel.SetActive(true);

    }
    public void DisablePannel()
    {
        displayPanel.SetActive(false);
    }
}
