using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCandle : MonoBehaviour
{
    [SerializeField] private GameObject candle;
    private TextAppear textAppear;

    private void Start()
    {
        candle.SetActive(false);
        textAppear = FindObjectOfType<TextAppear>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textAppear.SetText("Press 'E' to pick up the candle.");
            if (Input.GetKey(KeyCode.E))
            {
                textAppear.RemoveText();
                this.gameObject.SetActive(false);
                candle.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textAppear.RemoveText();
    }

}
