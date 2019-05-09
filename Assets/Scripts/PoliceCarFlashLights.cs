using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCarFlashLights : MonoBehaviour {
    private float switchLightTime;
    private float timeCounter;
    private bool lightRed;
    private GameObject goLightRed;
    private GameObject goLightBlue;

    // Use this for initialization
    void Start() {
        switchLightTime = Random.Range(1, 4);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "LightBlue")
                goLightBlue = transform.GetChild(i).gameObject;
            else if (transform.GetChild(i).gameObject.name == "LightRed")
                goLightRed = transform.GetChild(i).gameObject;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        timeCounter += Time.deltaTime;

        if( timeCounter > switchLightTime)
        {

            timeCounter = 0;
            switchLightTime = Random.Range((float) 0.5, 1);
            goLightBlue.SetActive(!lightRed);
            goLightRed.SetActive(lightRed);

            lightRed = !lightRed;
        }
	}
}
