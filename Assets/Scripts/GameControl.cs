using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    [HideInInspector]
    public static bool GameOver = false;

    [HideInInspector]
    public readonly static float GunBonusMaxTime = 5;

    public static int MaxZombies = 500;
    public static int QuantityOfZombies;

    private static PlayerControl playerCtrl;
    private static UserInterfaceControl uiCtrl;
    private static int kills;
    private static bool gunBonusFlag;
    private static float gunBonusTime;

    void Awake()
    {
        playerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        uiCtrl = GameObject.FindWithTag("UI").GetComponent<UserInterfaceControl>();
    }

    private void Start()
    {
        kills = 0;
        gunBonusFlag = false;
        gunBonusTime = 0;
        QuantityOfZombies = 0;
        GameOver = false;
    }

    public static void HitPlayer()
    {
        playerCtrl.Hit();
        uiCtrl.SetLifeGauge(playerCtrl.GetLife());

        if (playerCtrl.IsDead())
        {
            EndOfGame();
        }
    }

    static void EndOfGame()
    {
        GameOver = true;

        float actualTime = Time.timeSinceLevelLoad;
        CheckResults(actualTime);

        uiCtrl.ShowEndGamePanel(actualTime);
    }

    static void CheckResults(float actualTime)
    {
        if (PlayerPrefs.GetInt("BestScore") < kills)
            PlayerPrefs.SetInt("BestScore", kills);

        if (PlayerPrefs.GetFloat("BestTime") < actualTime)
            PlayerPrefs.SetFloat("BestTime", actualTime);
    }

    public static void KillZombie()
    {
        kills++;
        uiCtrl.SetScore(kills);
        QuantityOfZombies--;
    }

    public static int GetKills()
    {
        return kills;
    }

    public static void ActivateBonus()
    {
        gunBonusFlag = true;
        gunBonusTime = 0;
        uiCtrl.ShowBonusGunPanel();
    }

    public static bool GunBonus()
    {
        return gunBonusFlag;
    }

    void Update()
    {
        if (gunBonusFlag)
        {
            gunBonusTime += Time.deltaTime;
            if (gunBonusTime > GunBonusMaxTime)
                gunBonusFlag = false;

            uiCtrl.UpdateBonusPanel(gunBonusFlag, gunBonusTime);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
