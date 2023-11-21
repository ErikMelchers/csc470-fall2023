using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Ray _forwardRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootCheck();
        
    }
    
    void shootCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            _forwardRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward) *10);
            Debug.DrawRay(_forwardRay.origin,_forwardRay.direction * 10, Color.red, 20f);
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("enemy"))
                {
                    GameObject objectHit = hit.collider.gameObject;
                    Destroy(objectHit.gameObject);
                    Debug.Log("hit");
                }
                else
                {
                    Debug.Log("miss");
                }

            }
        }
    }
}
