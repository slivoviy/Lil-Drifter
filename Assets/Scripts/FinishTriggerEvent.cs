using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishTriggerEvent : MonoBehaviour {
    public ScoreCounter scoreCounter;

    private int _money;

    public Animator finishAnim;

    public Text scoreText;
    public Text moneyText;

    public GameObject finishMenuUI;
    private static readonly int IsOpened = Animator.StringToHash("IsOpened");

    private void Start() {
        _money = PlayerPrefs.GetInt("money", 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Time.timeScale = 0f;
        
        scoreText.text = scoreCounter.score.ToString();

        var gainedMoney = CountMoney(scoreCounter.score);
        moneyText.text = gainedMoney.ToString();
        _money += gainedMoney;
        PlayerPrefs.SetInt("money", _money);
        
        finishMenuUI.SetActive(true);
        finishAnim.SetBool(IsOpened, true);
        
    }

    private int CountMoney(int score) {
        return (int) (score * 0.4);
    }
    
    public void Again() {
        StartCoroutine(LoadScene("GameplayScene"));
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadScene("MainMenuScene"));
    }
    
    private IEnumerator LoadScene(String scene) {
        finishAnim.SetBool(IsOpened, false);
        
        yield return new WaitForSecondsRealtime(0.667f);
        
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(scene);
    }
}