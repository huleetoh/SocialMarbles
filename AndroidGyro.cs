using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidGyro : MonoBehaviour
{
   Gyroscope gyro;
	
	
	// Game Variables with initialized values
	public static float azimuth = 0;
	public static float pitch = 0;
	public static float roll = 0;
	public static bool isGyroAlive = false;

	
    // Start is called before the first frame update
    void Start()
    {
		// Lock screen orientation to landscape
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		// Disable rotation to portrait modes
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		
		
		//Gyro Section
        if (SystemInfo.supportsGyroscope)
		{	
			//Set up & enable the gyro
			gyro = Input.gyro;
			gyro.enabled = true;
			Debug.Log("Gyroscope support found.");
			isGyroAlive = true;
		}
		else
			Debug.Log("Gyroscope support not found!");
    }

    // Update is called once per frame
    void Update()
    {
		if(isGyroAlive){
		pitch = gyro.attitude.eulerAngles.x;
		roll = gyro.attitude.eulerAngles.y;
        azimuth = gyro.attitude.eulerAngles.z;
		}
		
    }
}
