using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitControl : MonoBehaviour
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
            objCollision.GetComponent<PlayerControl>().Cure(2);
            Destroy(gameObject);
        }
    }
}
