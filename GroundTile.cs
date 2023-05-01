
using UnityEngine;

public class GroundTile : MonoBehaviour
{

    // Variables
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    private void Start()
    {
        // Find a File named GroundSpawner
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other){  // Default code when anything leaves the trigger
        
        // Check if we need to reset the next spawn point...
        // Just tell the GroundSpawner that the player exited and destroy this gameobject in 2 seconds
        //groundSpawner.triggerInformer();
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2); // Destroy the object 2 seconds after player leaves the trigger
    }
    

    

    
}
