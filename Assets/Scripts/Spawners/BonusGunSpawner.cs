using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGunSpawner : Spawner
{
    public GameObject goBonusGun;

    void Start()
    {
        SpawnTime = Random.Range(15, 35);
    }

    void Update()
    {
        if (!GameObject.FindWithTag("BonusGun"))
        {
            RandomSpawn(goBonusGun, 15, 35);
        }
        else
            timeCounter = 0;
    }
}
