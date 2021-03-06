﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float BulletSpeed = 20;
    private float timeCounter;
    private Rigidbody rgBullet;

    void Start()
    {
        rgBullet = GetComponent<Rigidbody>();
    }

    void Update() {
        timeCounter += Time.deltaTime;

        if (timeCounter > 5)
        {
            Destroy(this.gameObject);
        }

    }
    void FixedUpdate()
    {
        rgBullet.MovePosition(rgBullet.position + 
                                 transform.forward * BulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider objCollision)
    {
        if (objCollision.tag == "Zombie" || objCollision.tag == "Boss" || objCollision.tag == "Player")
        {
            objCollision.GetComponent<CharacterControl>().Hit(1);
            objCollision.GetComponent<CharacterControl>().SquirtBlood(transform.position, Quaternion.LookRotation(-transform.forward) );
        }

        Destroy(gameObject);
    }
}
