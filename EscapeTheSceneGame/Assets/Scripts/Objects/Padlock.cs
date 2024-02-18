using System.Collections;
using UnityEngine;

public class Padlock : MonoBehaviour
{

    private HighlightEffect[] highlights;

    [SerializeField] Animator anim;
    [SerializeField] Animator unlock;

    private bool allowRoate;

    private int[][] numbers; // Array of arrays for each padlock combination;
    private int[] currentNumbers; // Array to hold the current values of each number;

    [SerializeField] private GameObject[] transformLocks; // Array of padlock GameObjects;

    private void Start()
    {
        highlights = GetComponentsInChildren<HighlightEffect>(true);

        numbers = new int[3][];
        currentNumbers = new int[3];

        //Fills each array of padlock with 0-9;
        for (int i = 0; i < 3; i++)
        {
            numbers[i] = new int[10];
            for (int j = 0; j < 10; j++)
            {
                numbers[i][j] = j;
            }
            currentNumbers[i] = numbers[i][0];
        }
    }

    private void Update()
    {
        if(allowRoate)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                IncreaseNumber(0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                IncreaseNumber(1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                IncreaseNumber(2);
        }
        

        if (currentNumbers[0] == 1 && currentNumbers[1] == 1 && currentNumbers[2] == 1)
        {
            anim.SetBool("Open", true);
            unlock.SetTrigger("Unlock");
        }



    }

    void IncreaseNumber(int padlockType)
    {
        currentNumbers[padlockType] = (currentNumbers[padlockType] + 1) % 10;
        Debug.Log(currentNumbers[padlockType]);
        RotateNumber(transformLocks[padlockType]);
    }

    private void RotateNumber(GameObject padlock)
    {
        padlock.transform.Rotate(0f, 0f, -36f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            allowRoate = true;
            Debug.Log("Press 'E' to enter padlock code");
            foreach (HighlightEffect highlight in highlights)
            {
                highlight.ToggleEmission();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        

        allowRoate = false;

        foreach (HighlightEffect highlight in highlights)
            {
                highlight.ToggleEmission();
            }
        
    }


}
