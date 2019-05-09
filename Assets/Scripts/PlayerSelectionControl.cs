using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelectionControl : MonoBehaviour
{
    public Slider PlayerSkinSlider;
    public Button StartButton;
    public int MaxSkins = 22;

    private int skin = 1;
    private bool right = true;
    private float changeTime;

    private void Start()
    {
        PlayerSkinSlider.maxValue = MaxSkins;
    }

    void FixedUpdate()
    {
        if (skin != PlayerSkinSlider.value)
        {
            transform.GetChild(skin).gameObject.SetActive(false);
            skin = (int)PlayerSkinSlider.value;
            transform.GetChild(skin).gameObject.SetActive(true);
        }

        changeTime += Time.deltaTime;
        if (changeTime > 5)
        {
            GetComponent<Animator>().SetFloat("Animation", Random.Range(1, 100));
            changeTime = 0;
        }
        else
            GetComponent<Animator>().SetFloat("Animation", 0);

        if (right)
            transform.Rotate(Vector3.up * Time.deltaTime * 15);
        else
            transform.Rotate(Vector3.up * Time.deltaTime * -15);

        if (transform.rotation.y < 0.9)
            right = !right;
    }

    public void Next()
    {
        if (PlayerSkinSlider.value < MaxSkins)
            PlayerSkinSlider.value++;
    }

    public void Previous()
    {
        if (PlayerSkinSlider.value > 1)
            PlayerSkinSlider.value--;
    }

    public void SelectPlayer()
    {
        PlayerControl.Skin = skin;
        SceneManager.LoadScene("Game");
    }  
}
