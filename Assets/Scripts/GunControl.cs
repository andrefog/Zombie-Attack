using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public GameObject goBullet;
    public GameObject goShell;
    public GameObject BarrelExitPosition;
    public GameObject ChamberExitPosition;
    public GameObject ShotLight;
    public GameObject BonusGunText;

    private float timeFire;
    private float timeText;

    void Update()
    {
                ShotLight.SetActive(false);
        if (!GameControl.GameOver)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shot();
            }
            else if (Input.GetButton("Fire1") && GameControl.GunBonus())
            {
                timeFire += Time.deltaTime;
                if (timeFire > 0.05)
                {
                    Shot();
                    timeFire = 0;
                }
            }
        }
    }

    void Shot()
    {
        AudioControl.playGunShot();
        ShotLight.SetActive(true);
        Instantiate(goBullet, BarrelExitPosition.transform.position, BarrelExitPosition.transform.rotation);
        Instantiate(goShell, ChamberExitPosition.transform.position, ChamberExitPosition.transform.rotation);
    }


}
