using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Variables
    public GameObject aCameraObj;
    public Vector3 camPosition, displacement, ballPosition;
    public Vector3 camAngle, camOffset;

    public float speed = 1;
    private Vector3 fwdVector;
    private Vector3 camRotOrigin;
    private bool isRotating = false;
    public Vector3 oldVector, newVector;
    private float camSwingAngle;
    public float camRotAngle;
    private float yCam, zCam;
    public Quaternion camRotation;
    public float camRotSpeed, camPosSpeed;
    


    void Start(){
        camPosition = aCameraObj.GetComponent<Transform>().position;    // Getting the Camera's position in the beginning
        ballPosition = transform.position;                              // Getting the marbles position in the beginning
        displacement = ballPosition - camPosition;                      // Calculating the difference in position between cam and marble
        camRotOrigin = aCameraObj.GetComponent<Transform>().rotation.eulerAngles;
        yCam = 5;
        zCam = -20;
        camRotSpeed = 2f;
        camPosSpeed = 3f;
        camRotAngle = 30;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the camera's current rotation
        camRotation = aCameraObj.transform.rotation;
        camPosition = aCameraObj.transform.position;
        

        
        //aCameraObj.transform.position = Vector3.Lerp(aCameraObj.transform.position, transform.position-displacement, Time.deltaTime * speed);
        

        switch(UserInput.moveDirection){
            case "FWD":
                newVector = Vector3.forward;
                camAngle = new Vector3(0, 0, -1*camRotAngle).normalized;
                rotateTo(newVector);
            break;
            case "BACK":
                newVector = Vector3.back;
                camAngle = new Vector3(0, 0, camRotAngle).normalized;
                rotateTo(newVector);  
            break;
            case "LEFT":
                newVector = Vector3.left;
                camAngle = new Vector3(camRotAngle, 0, 0).normalized;
                rotateTo(newVector);
            break;
            case "RIGHT":
                newVector = Vector3.right;
                camAngle = new Vector3(-1*camRotAngle, 0, 0).normalized;
                rotateTo(newVector);
            break;
            
        }
        camOffset = camAngle;
        aCameraObj.transform.LookAt(transform.position); // This keeps the camera looking at the marble
        

    }

    void rotateTo(Vector3 aVector){
        if(aVector != oldVector){   // This prevents this function from repeating every frame
            //aCameraObj.transform.rotation = Quaternion.Euler(aVector);
            aCameraObj.transform.RotateAround(transform.position, Vector3.up, camRotSpeed * Time.deltaTime);
            
            //aCameraObj.transform.rotation = Quaternion.LookRotation(aVector, Vector3.up); // This is a sharp rotation, needs smoothing
            //Quaternion targetRotation = Quaternion.LookRotation(aVector, Vector3.up);
            //aCameraObj.transform.rotation = Quaternion.RotateTowards(camRotation, targetRotation, camRotSpeed * Time.deltaTime); // Smoothly rotate to targetRotation
            //aCameraObj.transform.rotation = Quaternion.Slerp(camRotation, targetRotation, camRotSpeed * Time.deltaTime);
            oldVector = aVector;    // Save this vector for next update **Keep at the bottom of this code**
        }
        // Push camera behind the ball depending on the ball direction
        aCameraObj.transform.position = Vector3.Slerp(camPosition, (transform.position + camOffset), camPosSpeed * Time.deltaTime); 
        
    }

    float getCameraSwingAngle(){
        float dotProduct = Vector3.Dot(oldVector.normalized, newVector); // The angle between the oldVector and this Vector
        camSwingAngle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        return camSwingAngle;
    }
}
