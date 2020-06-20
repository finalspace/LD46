using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : SingletonBehaviour<TitleManager>
{
    public string titleSceneName;
    public GameObject credits;
    public GameObject tutorial;

    public void OnStartGameClicked()
	{
        MainGameManager.Instance.GameStart();
        Exit();
    }

    public void OnCreditsClicked()
	{
        credits.SetActive(true);
    }

    public void DismissCredits()
    {
        credits.SetActive(false);
    }

    public void OnTutorialClicked()
    {
        tutorial.SetActive(true);
    }

    public void DismissTutorial()
    {
        tutorial.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("main"));
        SceneManager.UnloadSceneAsync(titleSceneName);
    }
}
