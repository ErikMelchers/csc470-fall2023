using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private bool isHidden = false;
    private float timer = 1f;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer component not found!");
            enabled = false; 
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            if (isHidden)
            {
                ShowMesh();
            }
            else
            {
                HideMesh();
            }

            isHidden = !isHidden;
            timer = .15f; 
        }
    }

    void HideMesh()
    {
        meshRenderer.enabled = false; 
    }

    void ShowMesh()
    {
        meshRenderer.enabled = true; 
    }
}
