using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    private int _money;

    public Text moneyText;
    
    public void Start() {
        _money = PlayerPrefs.GetInt("money", 0);
        moneyText.text = _money.ToString();
    }

    public void Play() {
        SceneManager.LoadScene("CarChoiceScene");
    }

    public void Tutorial() {
    }

    public void Money() {
        PlayerPrefs.SetInt("money", _money + 25000);
        moneyText.text = (_money + 25000).ToString();
    }

    public void NoKeisuke() {
        PlayerPrefs.SetInt("car_choice_tutorial", 0);
    }

    public void NoMinagawa() {
        PlayerPrefs.SetInt("minagawa", 0);
    }
}