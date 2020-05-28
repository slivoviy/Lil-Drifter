using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public Animator pauseAnim;

    public GameObject pauseMenuUI;
    private static readonly int IsOpened = Animator.StringToHash("IsOpened");


    public void Resume() {
        StartCoroutine(CloseMenu());
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        
        Time.timeScale = 0f;
        
        pauseAnim.SetBool(IsOpened, true);
    }

    public void Again() {
        StartCoroutine(LoadScene("GameplayScene"));
    }

    public void GoToMainMenu() {
        StartCoroutine(LoadScene("MainMenuScene"));
    }

    private IEnumerator CloseMenu() {
        pauseAnim.SetBool(IsOpened, false);
        
        yield return new WaitForSecondsRealtime(0.667f);
        
        Time.timeScale = 1f;
        
        pauseMenuUI.SetActive(false);
    }

    private IEnumerator LoadScene(String scene) {
        pauseAnim.SetBool(IsOpened, false);
        
        yield return new WaitForSecondsRealtime(0.667f);
        
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(scene);
    }
    
}