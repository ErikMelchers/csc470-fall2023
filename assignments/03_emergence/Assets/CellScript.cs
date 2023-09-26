using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{

    public bool alive;
    public GameObject cell;

    public int touchingTrigger = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == false){
            cell.SetActive(false);
        }
    }
    
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("cell")){
            touchingTrigger++;
            Debug.Log("touched");
        }
    }
    private void OnTriggerExit(Collider other){
         if(other.CompareTag("cell")){
            touchingTrigger--;
        }
    }
}
