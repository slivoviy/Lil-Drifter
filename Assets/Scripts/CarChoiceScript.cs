using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarChoiceScript : MonoBehaviour {
    public Text money;

    public GameObject tutorialPanel;

    public Text keisukeButtonText;
    public GameObject keisukeCoin;
    public GameObject keisukePrice;

    public Text minagawaButtonText;
    public GameObject minagawaCoin;
    public GameObject minagawaPrice;

    public static byte CurrentCarPanel;

    private int _money;
    private int _keisukeBought;
    private int _minagawaBought;
    private int _currentCar;
    private static readonly int ChosenCar = Animator.StringToHash("chosenCar");

    void Start() {
        _money = PlayerPrefs.GetInt("money", 0);
        money.text = _money.ToString();

        _keisukeBought = PlayerPrefs.GetInt("keisuke", 0);
        if (_keisukeBought == 1) {
            keisukeButtonText.text = "Выбрать";
            keisukeCoin.SetActive(false);
            keisukePrice.SetActive(false);
        }
        else {
            keisukeButtonText.text = "Купить";
        }

        _minagawaBought = PlayerPrefs.GetInt("minagawa", 0);
        if (_minagawaBought == 1) {
            minagawaButtonText.text = "Выбрать";
            minagawaCoin.SetActive(false);
            minagawaPrice.SetActive(false);
        }
        else {
            minagawaButtonText.text = "Купить";
        }

        _currentCar = PlayerPrefs.GetInt("current_car", 0);
        CurrentCarPanel = (byte) _currentCar;

        if (PlayerPrefs.GetInt("car_choice_tutorial", 0) == 0) {
            StartCoroutine(ShowTutorial());
        } 
    }

    public IEnumerator ShowTutorial() {
        tutorialPanel.SetActive(true);
        
        yield return new WaitUntil(() => Input.touchCount > 0);
        
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("car_choice_tutorial", 1);
    }

    public void BuyOrChoose() {
        switch (CurrentCarPanel) {
            case 0:
                Choose();
                break;

            case 1:
                if (_keisukeBought == 1) {
                    Choose();
                }
                else {
                    Buy();
                }

                break;

            case 2:
                if (_minagawaBought == 1) {
                    Choose();
                }
                else {
                    Buy();
                }

                break;
        }
    }

    private void Buy() {
        if (_money >= 25000) {
            Debug.Log(CurrentCarPanel);
            switch (CurrentCarPanel) {
                case 1:
                    _keisukeBought = 1;
                    keisukeButtonText.text = "Выбрать";
                    PlayerPrefs.SetInt("keisuke", 1);

                    keisukeCoin.SetActive(false);
                    keisukePrice.SetActive(false);

                    break;
                case 2:
                    _minagawaBought = 1;
                    minagawaButtonText.text = "Выбрать";
                    PlayerPrefs.SetInt("minagawa", 1);

                    minagawaCoin.SetActive(false);
                    minagawaPrice.SetActive(false);

                    break;
            }
            
            _money -= 25000;
            PlayerPrefs.SetInt("money", _money);
            money.text = _money.ToString();
        }
    }
    
    private void Choose() {
        PlayerPrefs.SetInt("current_car", CurrentCarPanel);
        SceneManager.LoadScene("GameplayScene");
    }

    public void PreviousScene() {
        SceneManager.LoadScene("MainMenuScene");
    }
}