using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public float degreesPerSecond = 70.0f;
    public float amplitude = .2f;
    public float frequency = 2f;


    private bool isCollected = false;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private MeshRenderer childMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        Transform child = transform.Find("coin"); // Replace "ChildObjectName" with the actual name of the child GameObject.
        childMeshRenderer = child.GetComponent<MeshRenderer>();

    
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CoinFloat();
    }

    void CoinFloat()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected == false)
        {
            Debug.Log("Coin Collected");
            isCollected = true;
            childMeshRenderer.enabled = false;
            Handler.coinCount += 1;

            
        }
    }
}
