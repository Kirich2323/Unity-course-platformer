using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public int currentGold = 0;

    public Text goldDisplay;
    public GameObject gameUI;


    public GameObject deathMenu;
    public TextMeshProUGUI deathScore;

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

    public void GameOver() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        deathScore.text = "Score: " + currentGold.ToString();

        Time.timeScale = 0;

        deathMenu.SetActive(true);
        gameUI.SetActive(false);
    }
}
