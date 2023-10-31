using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{

    public float moveSpeed = 1f;
    public Vector3 moveDirection = Vector3.forward;
    float distance = 0;
    float modifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (distance >= 15f) {
            modifier *= -1f;
            distance = 0;
        }
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime * modifier;

        transform.Translate(movement);
        distance += moveSpeed * Time.deltaTime;
    }
}
