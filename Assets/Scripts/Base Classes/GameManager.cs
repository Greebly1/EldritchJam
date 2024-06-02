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
        Credits
    }
    private GameStates currentState;

    public GameObject currentMap;

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
    }

    public void ChangeState(GameStates changeToState)
    {
        switch (changeToState)
        {
            case GameStates.MainMenu:

                break;
            case GameStates.MapSelect:
                
                break;
            case GameStates.Game:

                break;
            case GameStates.Credits:

                break;
            default: // Credits state
                
                break;
        }
    }
}
