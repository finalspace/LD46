using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : SingletonBehaviour<TitleManager>
{
    public string titleSceneName;
    public void OnStartGameClicked()
	{
        MainGameManager.Instance.GameStart();
        Exit();
    }

    public void OnCreditsClicked()
	{

	}

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(titleSceneName);
    }
}
