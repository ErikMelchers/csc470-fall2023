using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLogic : MonoBehaviour
{
    float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        checkDistance();
    }


    void checkDistance()
    {
        float xPosition = transform.position.x;
        float zPosition = transform.position.z;

        if (xPosition > 45 || zPosition > 45 || xPosition < -45 || zPosition < -45)
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
            Destroy(gameObject);
        }
    }
}
