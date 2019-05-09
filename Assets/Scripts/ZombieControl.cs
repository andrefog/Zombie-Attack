using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : CharacterControl
{
    
    public float ZombieSpeed = 3;
    public float ZombieMaxLife = 1;
    
    private GameObject goPlayer;

    private Vector3 position;
    private float deadTimeCounter;
    private float waitTimeCounter;
    private AnimationControl anCtrl;

    void Start()
    {
        CharacterSpeed = ZombieSpeed;
        goPlayer = GameObject.FindWithTag("Player");
        anCtrl = GetComponent<AnimationControl>();
        RandomizeSkin();
    }

    void RandomizeSkin()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        int zombieType = Random.Range(1, 28);
        transform.GetChild(zombieType).gameObject.SetActive(true);
    }

    public void SetDead()
    {
        life = 0;

        anCtrl.Dead();

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;
        AudioControl.playZombie();
    }

    void FixedUpdate()
    {
        if (IsDead())
        {
            deadTimeCounter += Time.deltaTime;

            if (deadTimeCounter > 5)
                Destroy(this.gameObject);
        }
        else
        {
            float distance = Vector3.Distance(transform.position, goPlayer.transform.position);

            if (distance > 15)
                RandomMove();
            else if (distance > 2.5)
                FollowPlayer();
            else if (GameControl.GameOver)
                anCtrl.Eat();
            else
                anCtrl.Attack();
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
            
            waitTimeCounter = 4;
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

    void FollowPlayer()
    {
        waitTimeCounter = 0;
        Vector3 direction = goPlayer.transform.position - transform.position;

        Move(direction);
        Rotation(direction);
        anCtrl.Move(direction.magnitude);
    }

    void HitPlayer()
    {
        GameControl.HitPlayer();
    }
}
