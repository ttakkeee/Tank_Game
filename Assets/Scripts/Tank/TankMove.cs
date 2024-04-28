using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMove : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed = 120.0f; 
    public GameObject[] leftwheels;
    public GameObject[] rightwheels;

    public float wheelRotationSpeed = 200.0f; 

    private Rigidbody rb;
    private float moveInput; 
    private float rotationInput; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateWheels(moveInput, rotationInput);
        
    }
    void FixedUpdate()
    {
        MoveTankObj();
        RotateTank();
    }

    // move tank float de type input 
    void MoveTankObj()
    {
        // objet bouge à la même vitesse tout le temps 
        Vector3 moveDirection = transform.forward * (moveInput * moveSpeed);
        rb.MovePosition(rb.position + moveDirection);
    }

    void RotateTank()
    {
        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        // quaternion formule de maths qui comprend toutes les directions mais x et z à 0 car on veut bouger que gauche et droite 
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    public void HandleRotate(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<float>();
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.fixedDeltaTime;

        //move left wheels 
        foreach(GameObject wheel in leftwheels)
        {
            //wheel exists the it rotates 
            if(wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        //move rigth wheels 
        foreach(GameObject wheel in rightwheels)
        {
            //wheel exists the it rotates 
            if(wheel != null)
            {
                //change - to + bc when we rotate, wheels goes opposite direction
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        } 
    }

}
