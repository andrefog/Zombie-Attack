using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightControl : MonoBehaviour {

    public GameObject Light;
    private float timeFlash;
    private bool flash;

	void Update () {
        timeFlash += Time.deltaTime;

        if (timeFlash >= 1)
        {
            Light.SetActive(flash = !flash);
            timeFlash = 0;
        }
	}
}
