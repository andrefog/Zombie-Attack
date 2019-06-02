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
        for (int i = 0; i < 20; i++)
        {
            if (GameControl.GetInstance().QuantityOfZombies < GameControl.GetInstance().MaxZombies)
            {

                StartCoroutine(RandomSpawnObject(goZombie));
                GameControl.GetInstance().QuantityOfZombies++;
            }
        }
    }

    void Update()
    {
        if (!GameControl.GetInstance().GameOver)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= SpawnTime)
            {
                if (Vector3.Distance(goPlayer.transform.position, transform.position) > 15)
                {
                    if (GameControl.GetInstance().QuantityOfZombies < GameControl.GetInstance().MaxZombies)
                    {
                        
                        StartCoroutine(RandomSpawnObject(goZombie));
                        GameControl.GetInstance().QuantityOfZombies++;

                        if (SpawnTime > 0.5)
                            SpawnTime -= (float)0.25;
                    }
                }

                timeCounter = 0;
            }
        }
    }
}
