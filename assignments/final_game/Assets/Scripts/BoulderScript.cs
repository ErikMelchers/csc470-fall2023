using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    private float moveSpeed = 50.0f;


    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        checkHeight();
    }


    void checkHeight() {
        float yPosition = transform.position.y;
        if (yPosition > 180)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameLogic.heartsLeft -= 1;
            Debug.Log("Player Hit");
        }
    }
}
