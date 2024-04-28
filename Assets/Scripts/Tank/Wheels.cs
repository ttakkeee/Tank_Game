using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    
    public GameObject[] leftwheels;
    public GameObject[] rightwheels;
    
    public float wheelRotationSpeed = 200.0f; 
    
    private float moveInput; 
    private float rotationInput; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vertcial axis refer to w and s keys 
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
        
        RotateWheels(moveInput, rotationInput);
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
        //move right wheels 
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
