using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtCamera : MonoBehaviour
{
    public Transform cameraTransform; // Assign the camera's transform in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform);
    }
}
