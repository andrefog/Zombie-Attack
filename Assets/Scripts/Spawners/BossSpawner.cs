using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    public GameObject goBoss;

    private int nextSpawnKills;
    private int spawnKillsCount = 50;

    private void Start()
    {
        nextSpawnKills = spawnKillsCount;
    }

    void Update()
    {
        if (!GameControl.GetInstance().GameOver &&
            GameControl.GetInstance().GetKills() >= nextSpawnKills &&
            !GameObject.FindWithTag("Boss"))
        {
            StartCoroutine(RandomSpawnObject(goBoss));
            nextSpawnKills = GameControl.GetInstance().GetKills() + spawnKillsCount;
        }
    }
}
