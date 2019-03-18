using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public int currentGold = 0;

    public TextMeshProUGUI goldDisplay;
    public GameObject gameUI;


    public GameObject deathMenu;
    public TextMeshProUGUI deathScore;

    public TextMeshProUGUI finishScoreText;
    public GameObject finishPanel;

    void Start() {
        gameUI.SetActive(true);
        deathMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update() { }

    public void AddGold(int amount) {
        currentGold += amount;
        goldDisplay.text = "Gold: " + currentGold.ToString();
    }

    private void pause() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;
    }

    public void GameOver() {

        pause();
        deathMenu.SetActive(true);
        gameUI.SetActive(false);

        deathScore.text = "Score: " + currentGold.ToString();
    }

    public void Finish() {
        pause();
        finishScoreText.text = "Final score: " + currentGold.ToString() + "!";

        finishPanel.SetActive(true);
        gameUI.SetActive(false);
    }
}
