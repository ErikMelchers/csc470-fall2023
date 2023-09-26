using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform launcherTransform;
    public int score = 100;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            GameObject ball = Instantiate (ballPrefab, launcherTransform.position, launcherTransform.rotation);
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            ballRB.AddForce(launcherTransform.forward * 1000);
        }
    }
    public void intScore(int howMuch){
        
    }
}

