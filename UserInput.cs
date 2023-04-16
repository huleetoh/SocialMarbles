/**
*   This script takes all user input and broadcasts them out publicly
*   Take out LevelBoundry and put it in another script - it has nothing to do with taking User Input
*/

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    //Global Variables
    private float pitch, roll, azimuth;
    public static string moveDirection; // (0, 0, 0) = No movement in any direction
    public enum MOVEDIR{
        FWD,
        BACK,
        LEFT,
        RIGHT
    }
    

    // Update is called once per frame
    void Update()
    {
        // Get Gyro data from AndroidGryo.cs to influence movement here
        pitch = AndroidGyro.pitch;      // Update gyro data - Used for z Movement
        roll = AndroidGyro.roll;        // Update gyro data - Used for x Movement
        azimuth = AndroidGyro.azimuth;  // Update gyro data - Probabaly not needed
    
        
        if(this.gameObject.transform.position.x > LevelBoundary.leftBoundary)                               // Sideways Movement with floor boundary limit
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || (roll > 0 && roll <60))        // Keyboard Movement Controls 
                moveDirection = MOVEDIR.LEFT.ToString();
            
        if(this.gameObject.transform.position.x < LevelBoundary.rightBoundary)                              // Sideways Movement with floor boundary limit
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || (roll > 300 && roll < 360))   // Keyboard Movement Controls 
                moveDirection = MOVEDIR.RIGHT.ToString(); 
            
        if(this.gameObject.transform.position.z < LevelBoundary.frontBoundary)
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || (pitch > 0 && pitch < 60) )      // Keyboard Movement Controls 
                moveDirection = MOVEDIR.FWD.ToString();
                
        if(this.gameObject.transform.position.z > LevelBoundary.rearBoundary)
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || (pitch > 300 && pitch < 360))  // Keyboard Movement Controls 
                moveDirection = MOVEDIR.BACK.ToString();
                              
    }
}
