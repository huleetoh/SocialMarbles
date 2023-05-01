using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Variables
    public Rigidbody rb;
    public float moveSpeed = 10f;
    private float xInput;
    private float zInput;

    void Awake() // While Loading 
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update() {
        // Handle inputs    
        ProcessInputs();
    }

    private void FixedUpdate(){
        Move();
    }

    private void ProcessInputs(){
        if(AndroidGyro.isGyroAlive){
        xInput = Input.acceleration.normalized.x; 
        zInput = Input.acceleration.normalized.y; 
        }
        else{
            xInput = Input.GetAxis("Horizontal"); 
            zInput = Input.GetAxis("Vertical"); 
        }
    }

    private void Move(){
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }





    

        
    

}
