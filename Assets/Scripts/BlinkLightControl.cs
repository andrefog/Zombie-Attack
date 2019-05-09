using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLightControl : MonoBehaviour
{

    public GameObject Light;
    private float timeFlash;
    private float time2Blink = 1;
    private bool flash;

    void Update()
    {
        timeFlash += Time.deltaTime;

        if ( (flash == false && timeFlash >= 0.1) ||
             (timeFlash >= time2Blink) )
        {
            Light.SetActive(flash = !flash);
            timeFlash = 0;
            time2Blink = Random.Range(0, 3);
        }
    }
}
