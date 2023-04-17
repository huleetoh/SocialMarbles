/**
*   This script listens to UserInput's movement and then moves the ball accordingly
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTranslation : MonoBehaviour
{
   public float horzSpeed;
    
    private void Start(){
        horzSpeed = 1 * Time.deltaTime;
    }
    
    private void Update()
    {
        switch(UserInput.moveDirection){    // Get the user's input
            case "FWD":
                move(Vector3.forward);      
            break;
            case "BACK":
                move(Vector3.back);  
            break;
            case "LEFT":
                move(Vector3.left);
            break;
            case "RIGHT":
                move(Vector3.right);
            break;
        }
        
    }

    private void move(Vector3 direction){
        transform.Translate(direction * horzSpeed);    
    }
    
}
