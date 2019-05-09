using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitSpawner : Spawner
{
    public GameObject goMedkit;

    void Start()
    {
        SpawnTime = Random.Range(15, 25);
    }

    void Update()
    {
        if (!GameObject.FindWithTag("Medkit"))
        {
            RandomSpawn(goMedkit, 15, 25);
        }
        else
            timeCounter = 0;
    }
}
