using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent(gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("score")){
            gm.score++;
            Debug.Log(gm.score);
        }
    }
}
