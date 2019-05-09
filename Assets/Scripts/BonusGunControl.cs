using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGunControl : MonoBehaviour
{
    private float time2Destroy;

    private void Update()
    {
        time2Destroy += Time.deltaTime;

        if (time2Destroy >= 20)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider objCollision)
    {
        if (objCollision.tag == "Player")
        {
            GameControl.ActivateBonus();
            Destroy(gameObject);
        }
    }
}
