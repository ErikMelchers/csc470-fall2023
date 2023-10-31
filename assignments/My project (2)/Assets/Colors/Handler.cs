using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handler : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI winText;


    public static Handler SharedInstance;
    public static int coinCount = 0;
    int coinsToWIn = 12;

    float timePassed = 0;
    int secondsPassed = 0;
    bool won = false;
    bool x = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Coins: " + coinCount.ToString();

        timePassed += Time.deltaTime;
        if (secondsPassed >= 2 && !x) {
            winText.text = "";
            x = true;
        }
        if (timePassed >= 1f)
        {
            timePassed = 0f;
            secondsPassed += 1;
            timeText.text = "Time: " + secondsPassed.ToString();

        }

        endGame();

    }

    public void UpdateScore(int amount)
    {
        Debug.Log("called");
        coinCount += amount;
        scoreText.text = "Coins: " + coinCount.ToString();
    }

    public void endGame()
    {
        if (coinCount >= coinsToWIn && !won)
        {
            winText.text = "YOU WIN!\nScore: " + secondsPassed.ToString() + " Seconds";
            won = true;
        }
    }


}
