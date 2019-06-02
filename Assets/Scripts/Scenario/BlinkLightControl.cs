using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLightControl : MonoBehaviour
{

    public GameObject Light;
    private float time;
    private float timeOn;
    private float timeOff;
    private bool flash;

    void Update()
    {
        time += Time.deltaTime;

        if ( Light.activeSelf == false && timeOff <= time )
        {
            Light.SetActive(flash = true);
            time = 0;
            timeOn = Random.Range(0.1f, 0.5f);
        }if (Light.activeSelf == true && timeOn <= time)
        {
            Light.SetActive(flash = false);
            time = 0;
            timeOff = Random.Range(0.5f, 5);
        }
    }
}
