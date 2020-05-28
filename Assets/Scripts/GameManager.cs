using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] cars;
    public GameObject[] tutorialPanels;

    public ScoreCounter scoreCounter;
    public CameraScript mainCamera;
    
    void Start() {
        var car = PlayerPrefs.GetInt("current_car", 0);
        GameObject go = Instantiate(cars[car], 
            new Vector3(-0.2f, -1.48f),
            Quaternion.Euler(0, 0, 0)
        );

        scoreCounter.car = go.transform;
        mainCamera.target = go.transform;

        if (PlayerPrefs.GetInt("gameplay_tutorial", 0) == 0) {
            StartCoroutine(ShowTutorial());
        }
    }

    private IEnumerator ShowTutorial() {
        Time.timeScale = 0f;
        tutorialPanels[0].SetActive(true);
        
        yield return new WaitUntil(() => Input.touchCount > 0);
        
        tutorialPanels[0].SetActive(false);
        tutorialPanels[1].SetActive(true);
        
        yield return new WaitForSecondsRealtime(0.2f);
        yield return new WaitUntil(() => Input.touchCount > 0);
        
        tutorialPanels[1].SetActive(false);
        tutorialPanels[2].SetActive(true);
        
        yield return new WaitForSecondsRealtime(0.2f);
        yield return new WaitUntil(() => Input.touchCount > 0);
        
        tutorialPanels[2].SetActive(false);
        PlayerPrefs.SetInt("gameplay_tutorial", 1);
        Time.timeScale = 1f;
    }
}