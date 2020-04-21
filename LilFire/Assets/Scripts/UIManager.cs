using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>
{
    public Text score;
    public Text finalscore;
    public Image healthbar;

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
        Debug.Log(MainGameManager.Instance.gameState);
        if (MainGameManager.Instance.gameState == GameState.Lose ||
            MainGameManager.Instance.gameState == GameState.Win)
        {
            finalscore.gameObject.SetActive(true);
            finalscore.enabled = true;
            finalscore.text = "" + PlayerStats.Instance.score;
            //GameObject.Destroy(Player.Instance);
        }
        if (MainGameManager.Instance.gameState != GameState.Main)
            return;

        playerEnergy = PlayerStats.Instance.energy;
        energyPercentage = playerEnergy / 100.0f;
        healthbar.rectTransform.sizeDelta = new Vector2(lifebarWidth * energyPercentage, lifebarHeight);

        score.text = "" + PlayerStats.Instance.score;
    }
}
