using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Player's health will be based on a stress system, the higher it is the more obscure the vision is, louder heartbeat and slower movement speed;
 * There will be ways to reduce stress throughout the game;
 * Player can go from any state to any other state, as jumpscares for example can make you go from calm to panic;
 */
public class Health : MonoBehaviour
{

    public static Health Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    PlayerThoughts playerThoughts;
    public enum StressState
    {
        Calm,
        MildStress,
        HighStress,
        Panic
    }
    private StressState currentState;


    private void Start()
    {
        playerThoughts = FindObjectOfType<PlayerThoughts>();
    }

    // Customizable behaviors for each stress state
    public void OnCalmState()
    {
        Debug.Log("Player is calm.");
        playerThoughts.UpdateThoughtsText();
        // Add custom behaviors for Calm state
    }

    public void OnMildStressState()
    {
        Debug.Log("Player is experiencing mild stress.");
        playerThoughts.UpdateThoughtsText();

        // Add custom behaviors for MildStress state
    }

    public void OnHighStressState()
    {
        Debug.Log("Player is experiencing high stress.");
        playerThoughts.UpdateThoughtsText();

        // Add custom behaviors for HighStress state
    }

    public void OnPanicState()
    {
        Debug.Log("Player is in panic mode!");
        playerThoughts.UpdateThoughtsText();

        // Add custom behaviors for Panic state
    }

    // Get current stress state
    public StressState GetState()
    {
        Debug.Log(currentState);
        return currentState;
    }

    // Set new stress state and trigger corresponding behavior
    public void SetState(StressState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case StressState.Calm:
                OnCalmState();
                break;
            case StressState.MildStress:
                OnMildStressState();
                break;
            case StressState.HighStress:
                OnHighStressState();
                break;
            case StressState.Panic:
                OnPanicState();
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetState(StressState.Calm);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetState(StressState.MildStress);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SetState(StressState.HighStress);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetState(StressState.Panic);
        }
    }
}
