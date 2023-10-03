using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public bool touch = false;
    public Renderer rend;
    public GameObject sphere;
    public bool touchAlive = false;


    // Start is called before the first frame update
    void Start()
    {
        rend = sphere.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Control();
       
        if (touchAlive)
        {
            rend.material.color = Color.yellow;
        }
    }

    void Control()
    {
        if(Input.GetKeyDown(KeyCode.W)) { 
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward *100);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.back * 100);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * 100);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.left * 100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lower"))
        {
            Vector3 pos = transform.position;
            Rigidbody rb = GetComponent<Rigidbody>();


            pos.x = 10;
            pos.y = 10;
            pos.z = 10;
            player.transform.position = pos;
            rb.velocity = Vector3.zero;
        }

        if (other.CompareTag("cell"))
        {
            touch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cell"))
        {
            touch = false;
        }
    }
}
