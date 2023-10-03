using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject cellPrefab;
    CellScript[,] cells;

    float timer = 2f;
    bool[,] tempCellMatrix;

    void Start()
    {
        GenerateCells();
        //setGraph(option1());

    }

    void GenerateCells() {
        cells = new CellScript[20, 20];
        tempCellMatrix = new bool[20, 20];
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                tempCellMatrix[x, y] = false;
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

                if (Random.Range(0, 2) >= 1) {
                    cells[x, y].alive = true;
                }
            }
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = 2f;
            //  Debug.Log("Did it");
            Game2();
        }
        // Game2();s
    }


    void Game() {
        for (int x = 0; x < 20; x++) {
            for (int y = 0; y < 20; y++) {
                if (cells[x, y].alive && (cells[x, y].touchingTrigger == 1)) {
                    Debug.Log("x" + x + " y " + y + " is touching 1 other cell");
                }
                else if (cells[x, y].alive && (cells[x, y].touchingTrigger == 2)) {
                    // Debug.Log("x" + x +" y " + y +" is touching 2 other cells");
                }
                else if (cells[x, y].alive && (cells[x, y].touchingTrigger == 3)) {
                    // Debug.Log("x" + x +" y " + y +" is touching 3 other cells");
                }
                else if (cells[x, y].alive && (cells[x, y].touchingTrigger == 4)) {
                    // Debug.Log("x" + x +" y " + y +" is touching 4 other cells");
                }
                else if (cells[x, y].alive && (cells[x, y].touchingTrigger > 4)) {
                    // Debug.Log("x" + x +" y " + y +" is touching more thatn 4 other cells");
                }
                else if (cells[x, y].alive) {
                    // Debug.Log("x" + x +" y " + y +" is not touching any cells");
                }
            }
        }
    }

    void Game2() {
        for (int l = 0; l < 20; l++) {
            for (int m = 0; m < 20; m++) {
                int aliveNeighbors = 0;

                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        // Debug.Log("|---|around cell: ("+  i+", "+ j +")  looking at (" +(l + i) + ", " +( m+j)+")");

                        if (i + l >= 0 && i + l <= 19 && j + m >= 0 && j + m <= 19) {
                            if (cells[l + i, m + j].GetComponent<CellScript>().alive) {
                                //Debug.Log((i + l) + ", " + (j + m) + " is alive");
                                aliveNeighbors += 1;
                            }
                            else
                            {
                                //Debug.Log((i + l) + ", " + (j + m) + " is dead");

                            }
                        }
                    }
                }
                if (cells[l, m].alive) {
                    aliveNeighbors -= 1;
                   // Debug.Log(l + ", " + m + " : aliveNeighbors = " + aliveNeighbors);
                }
                //Debug.Log("------------------------------------------");
                // Debug.Log("x" + l +" y " + m +" is touching " + aliveNeighbors + " cells");

                if (cells[l, m].alive && (aliveNeighbors < 2)) {
                    tempCellMatrix[l, m] = false;
                    // cells[l,m].alive = false;
                }
                else if (cells[l, m].alive && (aliveNeighbors > 3)) {
                    tempCellMatrix[l, m] = false;
                    // cells[l,m].alive = false;
                }
                else if ((cells[l, m].GetComponent<CellScript>().alive == false) && (aliveNeighbors == 3)) {
                    tempCellMatrix[l, m] = true;
                    // cells[l,m].alive = true;
                }
                else if ((cells[l,m].alive && aliveNeighbors == 2) || (cells[l, m].alive && aliveNeighbors == 3))
                {
                    tempCellMatrix[l,m] = true;
                }
                
                // else {
                //     tempCellMatrix[l, m] = cells[l, m];
                // }

            }
        }

        for (int i = 0; i < 20; i++) {
            for (int j = 0; j < 20; j++) {
                if (tempCellMatrix[i, j]) {
                    cells[i, j].alive = true;
                }
                else {
                    cells[i, j].alive = false;
                }
            }
        }



    }

    bool[,] option1()
    {
        bool[,] returnBool;
        returnBool = new bool[20,20];
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                if((x == 5 || x==6|| x == 7) && (y ==9 || y==10 || y ==8)){
                    returnBool[x,y] = true;
                }
                else
                {
                    returnBool[x,y] = false;
                }
            }
        }
        return returnBool;
    }

    void setGraph(bool[,] newGraph)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (newGraph[i, j])
                {
                    cells[i, j].alive = true;
                }
                else
                {
                    cells[i, j].alive = false;
                }
            }
        }
    }
    // private int numAliveNeighbors(){

    // }

    // bool isNeighbor(x,y){
    //     if(cell[x,y])
    // }

}