using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameLogic : MonoBehaviour
{
    public Transform playerTransform;
    public static int heartsLeft = 3;
    int currentHearts = heartsLeft;
    public static bool gameContinue = false;
    private float second = 0;
    private int timer2 = 0;
    public GameObject rockObject; 
    public float spawnInterval = 0.1f; 
    private float timer = 0f;

    public GameObject birdObject; 
    public float spawnRadius = 35f;


    private static int difficulty = 3;
    static int loops = 0;
    int modifier = 5;
    // Start is called before the first frame update

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public TextMeshProUGUI canvasText;
    public Button startButton;
    public Button restartButton;
    public TextMeshProUGUI score;
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        second += Time.deltaTime;
        if (second >= 1f && gameContinue) {
            second = 0;
            timer2 += 1;
            canvasText.text = timer2.ToString();
        }
        if (gameContinue)
        {
            checkGameOver();
            checkHeartChange();
            if (timer >= spawnInterval)
            {
                int randomInt = Mathf.FloorToInt(Random.Range(0, difficulty));
                    for (int i = 0; i < randomInt; i++) {
                            SpawnBoulderObject();
                    }
                        
                    timer = 0f; 
                    loops++;
                    increaseDiff();
                    if (Random.Range(1f,10f) > 2f)
                    {
                        SpawnBirdObject();
                    }
            }
            
        }
        CheckHearts();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restartGGame();
        }
    }

    void checkGameOver()
    {
        if (heartsLeft <= 0)
        {
            Debug.Log("GameOver");
            gameContinue = false;
            restartButton.gameObject.SetActive(true);
            displayScore();

        }
    }
    void checkHeartChange()
    {
        if (heartsLeft != currentHearts) {
            Debug.Log("Lost A heart");
            currentHearts = heartsLeft;
        }
    }

    void SpawnBoulderObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-30f, 30f), Random.Range(-200f, -10f), Random.Range(-30f, 30f));

        Quaternion spawnRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

        Instantiate(rockObject, spawnPosition, spawnRotation);
    }

    void SpawnBirdObject()
    {
        Vector3 center = new Vector3(0f, 181f, 0f); 

        float angle = Random.Range(0f, Mathf.PI * 2f); 
        float x = center.x + Mathf.Cos(angle) * spawnRadius;
        float z = center.z + Mathf.Sin(angle) * spawnRadius;

        Vector3 spawnPosition = new Vector3(x, center.y, z);
        Quaternion spawnRotation = Quaternion.LookRotation(center - spawnPosition);
        spawnRotation *= Quaternion.Euler(0, Random.Range(-45f, 45f), 0);

        Instantiate(birdObject, spawnPosition, spawnRotation);
    }


    void increaseDiff()
    {
        if (loops == modifier)
        {
            difficulty += 3;
            loops = 0;
        }
        
    }
    void CheckHearts()
    {
        if (heartsLeft == 3)
        {
            heart1.enabled = true; heart2.enabled = true; heart3.enabled = true;
        }
        else if (heartsLeft == 2)
        {
            heart1.enabled = false;
        }
        else if (heartsLeft == 1)
        {
            heart2.enabled = false;
        }
        else { heart3.enabled= false; }
    }
    
    public void startGame()
    {
        gameContinue = true;
        Debug.Log("start");
    }
    public void HideButton()
    {
        startButton.gameObject.SetActive(false);
    }
    public void restartGGame()
    {
        score.gameObject.SetActive(false);
        heartsLeft = 3;
        gameContinue = true;
        timer2 = 0;
        timer = 0;
        restartButton.gameObject.SetActive(false);
        playerTransform.position = new Vector3(0f,181.45f,0f);
    }
    private void displayScore()
    {
        score.gameObject.SetActive(true);
        score.text = "Score: " + timer2;

    }
}
