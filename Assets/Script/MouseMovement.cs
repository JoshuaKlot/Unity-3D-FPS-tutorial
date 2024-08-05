using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 600f;
    [SerializeField] private float keySensitivity = 200f;
    float xRotation = 0f;
    float yRotation = 0f;
    [SerializeField] float topClamp = -90f;
    [SerializeField] float bottomClamp = 90f;
    // Start is called before the first frame update
    void Start()
    {
        //Locking crusor at the start
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;


        Debug.Log(mouseX);
        //The if statement has the left and right keys move the camera unless the player is strafing
        if (!Input.GetKey(KeyCode.LeftShift))
             mouseX += Input.GetAxis("Horizontal") * keySensitivity * Time.deltaTime;
        
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //Rotation around the Y axis( Look left and right)
        yRotation += mouseX;
        //Rotation around the X axis( Look up and down)
        xRotation -= mouseY;
        
        //Constraining the mouse movement to either directly up or directly down
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

    

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
