using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : SingletonBehaviour<HealthManager>
{
    public Text score;
    public Image healthbar;

    private float lifebarWidth, lifebarHeight;
    private bool playerStats;
    private float playerlife;
    private float lifepercentage;

    void Start()
    {
        lifebarWidth = healthbar.rectTransform.sizeDelta.x;
        lifebarHeight = healthbar.rectTransform.sizeDelta.y;
    }

    void Update()
    {
        playerlife -= Time.deltaTime * 1;
        lifepercentage = playerlife / 100.0f;
        //healthbar.rectTransform.sizeDelta = new Vector2(800 * lifepercentage, )


    }
}
