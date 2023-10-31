using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject player;
    float rateForward = 2;
    float forwardSpeed = 10;
    float rotateSpeed = 240;
    float jumpForce = 18;
    float gravityModifier = 4.5f;
    int doubleJump = 2;
    float yVelocity = 0;
    bool jumped = false;
    float airModifier = 0f;
    private bool continueClick = false;
    private Vector3 targetPosition;


    CharacterController cc;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;

        cc = gameObject.GetComponent<CharacterController>();
    }


    void Control()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
        if (!cc.isGrounded)
        {
            vAxis += airModifier;
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        }
        else
        {   
            yVelocity = -10;
            doubleJump = 2;
            airModifier = 0f;

            if (Input.GetKeyDown(KeyCode.Space) && vAxis > 0)
            {
                jumped = true;
                yVelocity = jumpForce;
                airModifier = .5f;
            }
            else if(Input.GetKeyDown(KeyCode.Space) && vAxis < 0)
            {
                jumped = true;
                yVelocity = jumpForce;
                airModifier = -.5f;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
                yVelocity = jumpForce;
            }

            if (vAxis == 0 && hAxis == 0)
            {
                continueClick = false;
            }
            if (vAxis < 0 && continueClick == false)
            {
                Vector3 directionToCamera = Camera.main.transform.position - transform.position;

                Quaternion yRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                continueClick = true;
            }
            if (vAxis > 0 && continueClick == false)
            {
                Vector3 directionToCamera = Camera.main.transform.position - transform.position;

                Quaternion yRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                continueClick = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0)
        {
            yVelocity = jumpForce;
            doubleJump -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = forwardSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 10;

        }

        if (continueClick == true && vAxis < 0)
        {
            vAxis *= -1;
        }

        Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
        
        amountToMove.y = yVelocity;
        
        
        
        cc.Move(amountToMove * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.M))
        {
            airModifier = 1;
            Debug.Log(airModifier);
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        Control();
        
    }

   
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    void Control2() //scrapped Ideas /things I wanted to implement but could not do so cleanly and on time
    {
        bool leftRight = true;

        bool wPressed = false;
        bool sPressed = false;
        bool aPressed = false;
        bool dPressed = false;

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
        if (!cc.isGrounded)
        {
            vAxis += airModifier;
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        }
        else
        {
            yVelocity = -10;
            doubleJump = 2;
            airModifier = 0f;

            if (Input.GetKeyDown(KeyCode.Space) && vAxis > 0)
            {
                jumped = true;
                yVelocity = jumpForce;
                airModifier = .5f;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && vAxis < 0)
            {
                jumped = true;
                yVelocity = jumpForce;
                airModifier = -.5f;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                jumped = true;
                yVelocity = jumpForce;
            }



            //turns player around towards the direction clicked
            if(vAxis == 0 && hAxis == 0)
            {
                continueClick = false;
            }
            if(vAxis < 0 && continueClick == false)
            {
                Vector3 directionToCamera = Camera.main.transform.position - transform.position;

                Quaternion yRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                sPressed = true;
                continueClick = true;
            }
            if (vAxis > 0 && continueClick == false)
            {
                Vector3 directionToCamera = Camera.main.transform.position - transform.position;

                Quaternion yRotation = Quaternion.LookRotation(-directionToCamera, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                wPressed = true;
                continueClick = true;
            }
            if(hAxis < 0 && continueClick == false)
            {
                Vector3 leftDirection = -Camera.main.transform.right;

                Quaternion yRotation = Quaternion.LookRotation(leftDirection, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                aPressed = true;
                continueClick = true;
                leftRight = true;
            }
            if (hAxis > 0 && continueClick == false)
            {
                Vector3 rightDirection = Camera.main.transform.right;

                Quaternion yRotation = Quaternion.LookRotation(rightDirection, Vector3.up);

                yRotation.x = transform.rotation.x;
                yRotation.z = transform.rotation.z;

                transform.rotation = yRotation;
                dPressed = true;
                continueClick = true;
                leftRight = true;
            }
           

        }
        if (Input.GetKeyDown(KeyCode.Space) && doubleJump > 0)
        {
            yVelocity = jumpForce;
            doubleJump -= 1;
        }



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = forwardSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 10;

        }

        if(continueClick == true && vAxis <0)
        {
            vAxis *= -1;
        }
        else if (continueClick == true && hAxis < 0 && cc.isGrounded)
        {
            vAxis = 1;
            
        }
        else if (continueClick == true && hAxis > 0 && cc.isGrounded)
        {
            vAxis = 1;
            
            
        }

       
        Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;

        
            
        amountToMove.y = yVelocity;
        

        cc.Move(amountToMove * Time.deltaTime);
        if (!oneTrueFalse(wPressed,sPressed,aPressed,dPressed) && !leftRight)
        { 
            transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);
            Debug.Log("rotate");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            airModifier = 1;
            Debug.Log(airModifier);
        }

    }

    bool oneTrueFalse(bool firstBool,bool secondBool,bool thirdBool,bool fourthBool)
    {
        bool isOneTrue;
        if(firstBool && !secondBool && !thirdBool && !fourthBool)
        {
            isOneTrue = true;
        }
        else if (!firstBool && !secondBool && thirdBool && !fourthBool)
        {
            isOneTrue = true;
        }
        else if (!firstBool && secondBool && !thirdBool && !fourthBool)
        {
            isOneTrue = true;
        }
        else if (!firstBool && !secondBool && !thirdBool && fourthBool)
        {
            isOneTrue = true;
        }
        else { isOneTrue = false; }
        return isOneTrue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            targetPosition = new Vector3(1.0f, 100.0f, 1.0f);

            transform.position = targetPosition;
            Debug.Log("respawn");
        }
    }
    

}




