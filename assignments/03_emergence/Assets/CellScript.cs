using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{

    public bool alive = false;
    public GameObject cell;
    public GameObject cube;
    public GameObject player;
    public Renderer rend;
    public int touchingTrigger = 0;
  

    
    // Start is called before the first frame update
    void Start()
    {
     rend = cube.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (alive == false)
        {
            rend.material.color = Color.white;
        }
        else
        {
            rend.material.color = Color.black;

        }


    }
    
    private void OnTriggerEnter(Collider other){
      
        if (other.CompareTag("player"))
        {
            Debug.Log("Player Touch");
            touchingTrigger++;
        }
    }
    private void OnTriggerExit(Collider other){
         if(other.CompareTag("player")){
            touchingTrigger--;
        }
    }
}
