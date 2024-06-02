using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameStates
    {
        MainMenu,
        MapSelect,
        Game,
        Options,
        Credits
    }
    public GameStates currentState;

    public GameObject currentMap;
    public GameObject mainMenu;
    public GameObject mapSelect;
    public GameObject gameScreen;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    public LevelManager currentLevel;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameStates.MainMenu;
        ChangeState((int)currentState);
    }

    public void ChangeState(int changeToState) // This needs to be an int so the buttons can access the function
    {
        currentState = (GameStates)changeToState;
        switch (currentState)
        {
            case GameStates.MainMenu:
                mainMenu.SetActive(true);
                mapSelect.SetActive(false);
                gameScreen.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                currentMap.SetActive(false);
                break;
            case GameStates.MapSelect:
                mainMenu.SetActive(false);
                mapSelect.SetActive(true);
                gameScreen.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                currentMap.SetActive(false);
                break;
            case GameStates.Game:
                mainMenu.SetActive(false);
                mapSelect.SetActive(false);
                gameScreen.SetActive(true);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                currentMap.SetActive(true);
                break;
            case GameStates.Options:
                mainMenu.SetActive(false);
                mapSelect.SetActive(false);
                gameScreen.SetActive(false);
                optionsMenu.SetActive(true);
                creditsMenu.SetActive(false);
                currentMap.SetActive(false);
                break;
            case GameStates.Credits:
                mainMenu.SetActive(false);
                mapSelect.SetActive(false);
                gameScreen.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(true);
                currentMap.SetActive(false);
                break;
            default: // Main Menu state
                mainMenu.SetActive(true);
                mapSelect.SetActive(false);
                gameScreen.SetActive(false);
                optionsMenu.SetActive(false);
                creditsMenu.SetActive(false);
                currentMap.SetActive(false);
                break;
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
