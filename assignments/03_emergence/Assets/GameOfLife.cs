using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    CellScript[,] cells;

    void Start()
    {
        GenerateCells();
        // Game();
    }
    
    void GenerateCells(){
         cells = new CellScript[20,20];
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                // Create a position based on x, y
                Vector3 pos = transform.position;
                float cellWidth = 1f;
                float spacing = 0.1f;
                pos.x = pos.x + x * (cellWidth + spacing);
                pos.z = pos.z + y * (cellWidth + spacing);
                GameObject cellObj = Instantiate(cellPrefab, pos, transform.rotation);

                
                // (x,y) is the index in the 2D array. Store a reference to the
                // CellScript of the instantiated object because that is the
                // object that contains the information we will be intereated in
                // (the 'alive' variable.
                cells[x, y] = cellObj.GetComponent<CellScript>();

                if (Random.Range(0,2) >= 1){
                    cells[x,y].alive = true;
                }
            }
        }
    }

    void Update()
    {
        Game();
    }


    void Game(){
        for(int x = 0; x < 20; x++){
            for(int y = 0; y < 20; y++){
                if (cells[x,y].alive && (cells[x,y].touchingTrigger == 1)){
                    Debug.Log("x" + x +" y " + y +" is touching 1 other cell");
                }
                else if (cells[x,y].alive && (cells[x,y].touchingTrigger == 2)){
                    // Debug.Log("x" + x +" y " + y +" is touching 2 other cells");
                }
                else if (cells[x,y].alive && (cells[x,y].touchingTrigger == 3)){
                    // Debug.Log("x" + x +" y " + y +" is touching 3 other cells");
                }
                else if (cells[x,y].alive && (cells[x,y].touchingTrigger == 4)){
                    // Debug.Log("x" + x +" y " + y +" is touching 4 other cells");
                }
                else if (cells[x,y].alive && (cells[x,y].touchingTrigger > 4)){
                    // Debug.Log("x" + x +" y " + y +" is touching more thatn 4 other cells");
                }
                else if (cells[x,y].alive){
                    // Debug.Log("x" + x +" y " + y +" is not touching any cells");
                }
            }
        }
    }

    void Game2(){
         


    }


    // bool isNeighbor(x,y){
    //     if(cell[x,y])
    // }

}