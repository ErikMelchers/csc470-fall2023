using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{   
    // Start is called before the first frame update

    public GameObject schoolbusPrefab;
    public GameObject stopSignPrefab;
    void Start()
    {
        generateBus();
        for (int i = 0; i < 100; i++){
            generateStopSign();
        }
    }

    void generateBus(){
        float x = 0;
        float y = 20;
        float z = -50;
        for (int i = 0; i < 10; i++){
            Vector3 pos = new Vector3(x,y,z);
            GameObject schoolBusObj = Instantiate(schoolbusPrefab, pos, Quaternion.identity);
            z += 10;
        }
    }

    void generateStopSign(){
        float x = genOutside();
        float y = 0;
        float z = genOutside();

        Vector3 pos = new Vector3(x,y,z);
        GameObject stopSignObj = Instantiate(stopSignPrefab, pos, Quaternion.identity);

    }
    float Inside(){
            float x = Random.Range(-50,50);

            while (true){
                x = Random.Range(-50,50);
                if(x > 10 && x < -10)
                {

                }
                else{
                    break;
                }
                
            }
            return x;
        }
    float genOutside(){
        float x = Random.Range(-50,50);

        while (true){
            x = Random.Range(-50,50);
            if(x < 10 && x > -10)
            {

            }
            else{
                break;
            }
            
        }
        return x;
    }
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            genOneBus();
        }
    }
    void genOneBus(){
        float x = Inside();
        float y = 50;
        float z = Inside();

        Vector3 pos = new Vector3(x,y,z);
        GameObject schoolBusObject = Instantiate(schoolbusPrefab, pos, Quaternion.identity);
    }

}
