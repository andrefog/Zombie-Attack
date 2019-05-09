using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceControl : MonoBehaviour
{
    public GameObject GoImagesLifeGauge;
    public GameObject GoGameOverPanel;
    public Text TxScore;
    public Text TxBestTime;
    public Text TxBestScore;
    public Text TxActualTime;
    public Text TxActualScore;
    public GameObject GoBonusGunPanel;
    public GameObject GoGameHudPanel;
    public Slider SliderBonusTime;

    private GameObject actualLifeImage;
    private GameObject goBonusGunText;

    private void Start()
    {
        actualLifeImage = GoImagesLifeGauge.transform.GetChild(10).gameObject;
        goBonusGunText = GoBonusGunPanel.transform.GetChild(0).gameObject;
    }

    public void SetLifeGauge(int life)
    {
        if (life < 0)
            life = 0;
        else if (life > 10)
            life = 10;

        actualLifeImage.SetActive(false);
        actualLifeImage = GoImagesLifeGauge.transform.GetChild(life).gameObject;
        actualLifeImage.SetActive(true);
    }

    public void SetScore(int kills)
    {
        TxScore.text = kills.ToString();
    }

    public void ShowEndGamePanel(float actualTime)
    {
        GoGameOverPanel.gameObject.SetActive(true);
        GoGameHudPanel.gameObject.SetActive(false);

        int minutes = (int)actualTime / 60;
        int seconds = (int)actualTime % 60;
        TxActualTime.text = string.Format("{0}m{1}s", minutes, seconds);

        TxActualScore.text = string.Format("Você eliminou {0} zombies e sobreviveu por", GameControl.GetKills());

        minutes = (int)PlayerPrefs.GetFloat("BestTime") / 60;
        seconds = (int)PlayerPrefs.GetFloat("BestTime") % 60;
        TxBestTime.text = string.Format("{0}m{1}s", minutes, seconds);

        TxBestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public void ShowBonusGunPanel()
    {
        GoBonusGunPanel.SetActive(true);
    }

    public void UpdateBonusPanel(bool active, float time)
    {
        if (active)
        {
            bool blink = ((int)(time / 0.5) % 2) == 0;
            goBonusGunText.SetActive(blink);

            int remain = 100 - (int) ((time / GameControl.GunBonusMaxTime) * 100);
            SliderBonusTime.value = remain;
        }
        else
            GoBonusGunPanel.SetActive(false);
    }

}
