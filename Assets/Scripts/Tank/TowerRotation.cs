using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPartRotation : MonoBehaviour
{
    //C'est useless

    private Vector3 mousePos;
    private Camera cam; 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
      //Get Mouse position on screen
        mousePos = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

        //Calculate the angle 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //Rotate Canon to mouse direction
        transform.rotation = Quaternion.AngleAxis(-angle + 90f, Vector3.up);
    }
}
