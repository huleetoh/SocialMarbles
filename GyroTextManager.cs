using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTextManager : MonoBehaviour
{
    
    public GameObject gyroTextObj;
    TextMesh gyroTextMesh;
    
    void Start() {
        gyroTextMesh = gyroTextObj.GetComponent<TextMesh>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(AndroidGyro.isGyroAlive){
            gyroTextMesh.text = AndroidGyro.roll.ToString();
        }
        else
            gyroTextMesh.text = "No Gyro";
        
    }
}
