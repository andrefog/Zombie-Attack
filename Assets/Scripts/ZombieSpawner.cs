using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Spawner
{
    public GameObject goZombie;
    private GameObject goPlayer;

    private void Start()
    {
        goPlayer = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!GameControl.GameOver)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= SpawnTime)
            {
                if (Vector3.Distance(goPlayer.transform.position, transform.position) > 15)
                {
                    if (GameControl.QuantityOfZombies < GameControl.MaxZombies)
                    {
                        
                        StartCoroutine(RandomSpawnObject(goZombie));
                        GameControl.QuantityOfZombies++;

                        if (SpawnTime > 0.5)
                            SpawnTime -= (float)0.25;
                    }
                }

                timeCounter = 0;
            }
        }
    }
}
