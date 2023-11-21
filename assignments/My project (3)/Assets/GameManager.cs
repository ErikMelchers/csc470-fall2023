using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //List<UnitScript> list;
    public GameObject enemies;
    public TextMeshProUGUI gameOverText;

    private bool ended = false;
    public static bool endGame = false;
    private float timeCount = 0f;
    public int numberOfEnemies = 10;
    private float radius = 20f;
    public Vector3 centerPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!endGame)
        {
            spawnEnemies();
        }
        
        endCheck();
    }

    void spawnEnemies()
    {
        if (timeCount > 5f)
        {
            timeCount = 0f;

            float angleDifference = 360f / numberOfEnemies;

            for (int i = 0; i < numberOfEnemies; i++)
            {
                float angle = i * angleDifference * Mathf.Deg2Rad;
                float x = centerPoint.x + Mathf.Cos(angle) * radius;
                float z = centerPoint.z + Mathf.Sin(angle) * radius;
                Vector3 spawnPosition = new Vector3(x, centerPoint.y, z);

                Instantiate(enemies, spawnPosition, Quaternion.identity);
            }


            numberOfEnemies += 1;
        }
        else
        {
            timeCount += (1 * Time.deltaTime);
        }
    }


    void endCheck()
    {
        if (endGame == true)
        {
            Debug.Log("wow");
            if (!ended)
            {
                gameOverText.enabled = true;
                ended = true;
            }
        }
        
    }
}


