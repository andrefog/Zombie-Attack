using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    [HideInInspector]
    public bool GameOver = false;

    [HideInInspector]
    public readonly float GunBonusMaxTime = 5;

    public int MaxZombies = 500;
    public int QuantityOfZombies;

    private static GameControl gameCtrl;
    private PlayerControl playerCtrl;
    private UserInterfaceControl uiCtrl;
    private int kills;
    private bool gunBonusFlag;
    private float gunBonusTime;

    public static GameControl GetInstance()
    {
        if (gameCtrl == null)
            gameCtrl = GameObject.FindObjectOfType(typeof(GameControl)) as GameControl;

        return gameCtrl;
    }

    public void Awake()
    {
        playerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        uiCtrl = GameObject.FindObjectOfType(typeof(UserInterfaceControl)) as UserInterfaceControl;

        kills = 0;
        gunBonusFlag = false;
        gunBonusTime = 0;
        QuantityOfZombies = 0;
        GameOver = false;
    }

    public void UpdateLifeGauge()
    {
        uiCtrl.SetLifeGauge(playerCtrl.GetLife());

        if (playerCtrl.IsDead())
        {
            EndOfGame();
        }
    }

    void EndOfGame()
    {
        GameOver = true;

        float actualTime = Time.timeSinceLevelLoad;
        CheckResults(actualTime);

        uiCtrl.ShowEndGamePanel(actualTime);
    }

    void CheckResults(float actualTime)
    {
        if (PlayerPrefs.GetInt("BestScore") < kills)
            PlayerPrefs.SetInt("BestScore", kills);

        if (PlayerPrefs.GetFloat("BestTime") < actualTime)
            PlayerPrefs.SetFloat("BestTime", actualTime);
    }

    public void KillZombie()
    {
        kills++;
        uiCtrl.SetScore(kills);
        QuantityOfZombies--;
    }

    public int GetKills()
    {
        return kills;
    }

    public void ActivateBonus()
    {
        gunBonusFlag = true;
        gunBonusTime = 0;
        uiCtrl.ShowBonusGunPanel();
    }

    public bool GunBonus()
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
