using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> movingPlatform;
    public List<GameObject> cloud;
    public List<GameObject> moth;

    private Transform player;
    private float spawnHeight = 10;

    private void Start()
    {
        player = Player.Instance.transform;
    }

    private void Update()
    {
        if (MainGameManager.Instance.CurrentState() != GameState.Main)
            return;

        if (player.position.y > spawnHeight)
        {
            Spawn();
            spawnHeight += 10;
        }
    }

    void Spawn()
    {
        int num = Random.Range(0, 2);
        if (num == 0)
            SpawnCloud();
        else if (num == 1)
            SpawnMoth();
        else SpawnMovingPlatform();
    }

    void SpawnMovingPlatform()
    {
        //Instantiate(footEffect, pos, Quaternion.identity);
        int idx = Random.Range(0, movingPlatform.Count);
        Vector3 pos = player.position + new Vector3(0, 10, 0);
        Instantiate(movingPlatform[idx], pos, Quaternion.identity);
    }

    void SpawnCloud()
    {
        //Instantiate(footEffect, pos, Quaternion.identity);
        int idx = Random.Range(0, cloud.Count);
        Vector3 pos = player.position + new Vector3(0, 10, 0);
        Instantiate(cloud[idx], pos, Quaternion.identity);
    }

    void SpawnMoth()
    {
        //Instantiate(footEffect, pos, Quaternion.identity);
        int idx = Random.Range(0, moth.Count);
        Vector3 pos = player.position + new Vector3(0, 2, 0);
        GameObject mothObj = Instantiate(moth[idx], pos, Quaternion.identity);
        Animator animator = mothObj.GetComponent<Animator>();
        string anim = "ButterFly" + Random.Range(1, 6);
        animator.Play(anim);
    }
}
