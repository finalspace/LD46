using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Title, Intro, Main, Win, Lose
}


public class MainGameManager : SingletonBehaviour<MainGameManager> {
    
    public GameState gameState = GameState.Title;

	private void Start()
	{
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Additive);
	}

	private void Update()
	{
        if (gameState == GameState.Main)
        {
            HandleInput_MainGame();
        }
        else if (gameState == GameState.Win || gameState == GameState.Lose)
        {
            HandleInput_GameOver();
        }
	}



    private void GameStart()
    {
        if (gameState == GameState.Main)
            return;
        
        gameState = GameState.Main;


    }

    private void GameLost()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
    }

    private void HandleInput_Title()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }

    private void HandleInput_MainGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    private void HandleInput_GameOver()
    {

    }
}
