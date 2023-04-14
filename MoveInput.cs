using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    //Global Variables
    public float zSpeed = 1;
    public float xSpeed = 1;
    private float pitch = 0;
    private float roll = 0;
    private float azimuth = 0;
    

    // Update is called once per frame
    void Update()
    {
        // Get Gyro data from AndroidGryo.cs to influence movement here
        pitch = AndroidGyro.pitch;      // Update gyro data - Used for z Movement
        roll = AndroidGyro.roll;        // Update gyro data - Used for x Movement
        azimuth = AndroidGyro.azimuth;  // Update gyro data - Probabaly not needed
    

        // Moving forward in 3D, depends if Time exist, the player speed, and the Game World Space
        //transform.Translate(Vector3.forward * Time.deltaTime * zSpeed, Space.World) ;
        
        if(this.gameObject.transform.position.x > LevelBoundary.leftBoundary)                               // Sideways Movement with floor boundary limit
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || (roll > 0 && roll <60)){       // Keyboard Movement Controls 
                transform.Translate(Vector3.left * Time.deltaTime * xSpeed);                                // Movement
            }

        if(this.gameObject.transform.position.x < LevelBoundary.rightBoundary)                              // Sideways Movement with floor boundary limit
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || (roll > 300 && roll < 360)){  // Keyboard Movement Controls 
                transform.Translate(Vector3.right * Time.deltaTime * xSpeed);                               // Movement
            }

        if(this.gameObject.transform.position.z < LevelBoundary.frontBoundary)
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || (pitch > 0 && pitch < 60) )      // Keyboard Movement Controls 
                transform.Translate(Vector3.forward * Time.deltaTime * zSpeed);                             // Movement

        if(this.gameObject.transform.position.z > LevelBoundary.rearBoundary)
            if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.DownArrow) || (pitch > 300 && pitch < 360))   // Keyboard Movement Controls 
                transform.Translate(Vector3.back * Time.deltaTime * zSpeed);                                 // Movement
    }

   
}
