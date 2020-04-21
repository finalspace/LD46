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
        SceneManager.LoadScene("Title", LoadSceneMode.Additive);
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

    public GameState CurrentState()
    {
        return gameState;
    }

    public void GameStart()
    {
        if (gameState == GameState.Main)
            return;
        
        gameState = GameState.Main;
		SceneManager.LoadScene("MainLevel Art", LoadSceneMode.Additive);
	}

    public void GameLost()
    {
        //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
        gameState = GameState.Lose;
        //PlayerUtils.PlayerDeadOccur();
        Debug.Log("Game set to Lost in MainGameManager");
        HandleInput_GameOver();
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
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }

    private void HandleInput_GameOver()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SceneManager.UnloadSceneAsync("MainLevel Art");
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
}
