using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Text score;
    //public Text finalscore;
    public Image healthbar;
    public GameObject GameOver;
    public TMPro.TextMeshProUGUI FinalScore;
    

    private float lifebarWidth, lifebarHeight;
    private float playerEnergy;
    private float energyPercentage;

    void Start()
    {
        lifebarWidth = healthbar.rectTransform.sizeDelta.x;
        lifebarHeight = healthbar.rectTransform.sizeDelta.y;
    }

    void Update()
    {
        if (MainGameManager.Instance.CurrentState() == GameState.Lose ||
            MainGameManager.Instance.CurrentState() == GameState.Win)
        {
            GameOver.SetActive(true);
            FinalScore.text = "" + PlayerStats.Instance.score;
            //Debug.Break();
            gameObject.SetActive(false); // freezes text on screen
            LevelManager.Instance.Exit();
        }
        if (MainGameManager.Instance.gameState != GameState.Main)
            return;

        playerEnergy = PlayerStats.Instance.energy;
        energyPercentage = playerEnergy / 100.0f;
        healthbar.rectTransform.sizeDelta = new Vector2(lifebarWidth * energyPercentage, lifebarHeight);

        score.text = "" + PlayerStats.Instance.score;

     
    }
}
