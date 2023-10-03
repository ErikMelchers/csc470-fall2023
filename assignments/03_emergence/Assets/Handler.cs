using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Handler : MonoBehaviour
{
    public GameObject player;
    public GameObject cell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void check()
    {
        if (player.GetComponent<Player>().touch == false && cell.GetComponent<CellScript>().touchingTrigger == 1 && cell.GetComponent<CellScript>().alive)
        {
            Debug.Log("Here");
            player.GetComponent<Player>().touchAlive = true;
        }
    }
}
