using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHeight = -1000;
    public int lives = 3;
    public int score = 0;
    public GameObject player;
    public BoardManager lvl;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lvl = GameObject.FindObjectOfType<LevelManager>().GetComponent<BoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > maxHeight)
        {
            maxHeight = player.transform.position.y;
            score = Mathf.FloorToInt(maxHeight - lvl.bottomLeft.y);
        }
    }
}
