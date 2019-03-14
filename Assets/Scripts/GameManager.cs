using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int currentGold = 0;
    public Text goldDisplay;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddGold(int amount) {
        currentGold += amount;
        goldDisplay.text = "Gold: " + currentGold.ToString();
    }
}
