using System.Collections;
using UnityEngine;

public class Padlock : MonoBehaviour
{

    private bool prefab;
    private ZoomInEffect zoomIn;

    //We use an array of HighlightEffects because the padlock gameObject has 4 children that make the model;
    //We want each model (each child) to highlight at the same time to create the effect;
    private HighlightEffect[] highlights;
    private HighlightEffect highlight;

    [SerializeField] Animator anim;
    [SerializeField] Animator unlock;

    private bool allowRoate;
    private bool canOpenPanel;
    private bool showHighlight = true;

    private int[][] numbers; // Array of arrays for each padlock combination;
    private int[] currentNumbers; // Array to hold the current values of each number;

    [SerializeField] int[] magicNumbers;

    [SerializeField] private GameObject[] transformLocks; // Array of padlock GameObjects;

    private void Start()
    {
        highlights = GetComponentsInChildren<HighlightEffect>(true);
        zoomIn = FindObjectOfType<ZoomInEffect>();

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
        if(Input.GetKeyDown(KeyCode.E) && canOpenPanel)
        {
            zoomIn.ActivatePannel();
            allowRoate = true;
        }

        if (allowRoate)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                IncreaseNumber(0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                IncreaseNumber(1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                IncreaseNumber(2);

            if (currentNumbers[0] == magicNumbers[0] && currentNumbers[1] == magicNumbers[1] && currentNumbers[2] == magicNumbers[2])
            {
                zoomIn.DisablePannel();
                anim.SetBool("Open", true);
                unlock.SetTrigger("Unlock");
                showHighlight = false;

            }
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
            canOpenPanel = true;
            //Debug.Log("Press 'E' to enter padlock code");
            if(showHighlight)
            {
                foreach (HighlightEffect highlight in highlights)
                {
                    highlight.ToggleEmission();

                    //If player presses "E" to interact with the padlock a zoom in effect with blur background should emerge;

                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canOpenPanel = false;
        zoomIn.DisablePannel();

        if (other.CompareTag("Player"))
        {
            if (showHighlight)
            {
                foreach (HighlightEffect highlight in highlights)
                {
                    highlight.ToggleEmission();
                }

            }
        }
        

    }


}
