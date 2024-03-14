using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Playing,
    Paused,
    ReadingBook
}

public class UIController : MonoBehaviour
{
    public static UIController instance; // Singleton instance

    private GameState currentState = GameState.Playing;

    public bool canMove;
    void Awake()
    {
        // Ensure only one instance of GameController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PauseGame()
    {
        currentState = GameState.Paused; 
        Time.timeScale = 0f; //Pause the game;
    }

    public void ResumeGame()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f; //Resume normal time scale;
    }

    public void EnterReadingBookState()
    {
        currentState = GameState.ReadingBook;
        canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void ExitReadingBookState()
    {
        currentState = GameState.Playing;
        canMove = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        
    }

    public bool IsGamePaused()
    {
        return currentState == GameState.Paused;
    }

    public bool IsReadingBook()
    {
        return currentState == GameState.ReadingBook;
    }


}
