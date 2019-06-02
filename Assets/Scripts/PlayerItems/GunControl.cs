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
    public static readonly int MaxRounds = 20;

    private UserInterfaceControl uiCtrl;
    private float timeFire;
    private float timeReloading;
    private int rounds;

    private void Start()
    {
        rounds = MaxRounds;
        uiCtrl = GameObject.FindObjectOfType(typeof(UserInterfaceControl)) as UserInterfaceControl;
    }
    
    void Update()
    {
        ShotLight.SetActive(false);
        if (!GameControl.GetInstance().GameOver)
        {
            if (Input.GetButton("Fire1") && GameControl.GetInstance().GunBonus())
            {
                timeFire += Time.deltaTime;
                if (timeFire > 0.05)
                {
                    Shot();
                    timeFire = 0;
                    Reload();
                }
            }
            else if (rounds == 0)
            {
                bool realoding = true;
                timeReloading += Time.deltaTime;
                if (timeReloading > 3)
                {
                    realoding = false;
                    Reload();
                }

                uiCtrl.BlinkRealoadingText(realoding, timeReloading);
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Shot();
            }
        }
    }

    private void Reload()
    {
        rounds = MaxRounds;
        uiCtrl.ReloadBullets();
        timeReloading = 0;
    }

    void Shot()
    {
        uiCtrl.RemoveBullet(rounds);
        rounds--;
        AudioControl.playGunShot();
        ShotLight.SetActive(true);
        Instantiate(goBullet, BarrelExitPosition.transform.position, BarrelExitPosition.transform.rotation);
        Instantiate(goShell, ChamberExitPosition.transform.position, ChamberExitPosition.transform.rotation);
    }


}
