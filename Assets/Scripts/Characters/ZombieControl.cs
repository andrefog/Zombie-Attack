using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : EnemyControl
{
    public float ZombieSpeed = 3;
    public int ZombieMaxLife = 1;
    public int ZombieDamage = 1;
    public bool Blind = false;

    private Vector3 position;
    private float waitTimeCounter;

    new void Awake()
    {
        MovimentSpeed = ZombieSpeed;
        MaxLife = ZombieMaxLife;
        Damage = ZombieDamage;
        base.Awake();
    }

    new void Start()
    {
        RandomizeSkin();
        base.Start();
    }

    void RandomizeSkin()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        int zombieType = Random.Range(1, 27);
        transform.GetChild(zombieType).gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        if (!IsDead())
        {
            float distance = Vector3.Distance(transform.position, goPlayer.transform.position);

            if (distance > 15 || Blind)
                RandomMove();
            else if (distance > 2.5)
            {
                waitTimeCounter = 0;
                FollowPlayer();
            }
            else if (GameControl.GetInstance().GameOver)
                anCtrl.Eat();
            else
            {

                anCtrl.Attack();
            }
        }
    }

    void RandomMove()
    {
        waitTimeCounter -= Time.deltaTime;
        if (waitTimeCounter <= 0)
        {
            position = Random.insideUnitSphere * 10;
            position += transform.position;
            position.y = transform.position.y;
            
            waitTimeCounter = Random.Range(3, 6);
        }

        if (Vector3.Distance(position, transform.position) > 0.5)
        {
            Vector3 direction = position - transform.position;
            Move(direction);
            Rotation(direction);

            anCtrl.Move(1);
        }
        else
            anCtrl.Move(0);
    }
}
