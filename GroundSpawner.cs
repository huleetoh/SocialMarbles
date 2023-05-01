using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GroundSpawner : MonoBehaviour
{
    public GameObject player;
    private Rigidbody rb;
    public GameObject groundTile;                              // This is associated with the Prefab "GroundTiles"
    private Vector3 nextSpawnPoint;
    private Vector3 checkpoint = new Vector3(0,0,0);
    private int genNumTiles = 2;
    private List<GameObject> tileList = new List<GameObject>();
    private AudioSource aSRC;
    
   


    private void Start(){
        rb = player.GetComponent<Rigidbody>();
        aSRC = GetComponent<AudioSource>();
        generateInitGroundTiles();
    }
    
    
    public void SpawnTile(){
        GameObject temp;   
        temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);       // Create a gameObject using a the GroundPlane prefab @ nextSpawnPoint
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;            // Update the next spawnpoint with this gameobject's child's location 
        tileList.Add(temp);
    }

    private void generateInitGroundTiles(){
        GameObject temp;   
        temp = Instantiate(groundTile, checkpoint, Quaternion.identity);  
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;   
        tileList.Add(temp);
        for(int i = 0; i < genNumTiles; i++)
            SpawnTile();  
    }

    public void FallTrigger(){
        Debug.Log("Player Fell");
        // Move the ball to the checkpoint position
        player.transform.position = checkpoint + new Vector3(0, 2, 2);
        // Stop the background music
        // Delete all of the created tiles
        deleteGroundTiles();
        // Play a quick depressing tune
        aSRC.Play();
        // Freeze the ball's physics for movement
        FreezeBallPhysicsForNSeconds(1f);
        // Initiate the starting tiles at checkpoint
        generateInitGroundTiles();
        
        // Play the background music
    }

    private void deleteGroundTiles(){
        foreach(GameObject obj in tileList){
            if(obj != null){
                Destroy(obj);       // remove it from the scene
            }
        }
        tileList.Clear();           // remove it from this list
    }



    void FreezeBallPhysicsForNSeconds(float n)
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        StartCoroutine(UnfreezeBallPhysicsAfterNSeconds(n/2));
    }

    IEnumerator UnfreezeBallPhysicsAfterNSeconds(float n)
    {
        yield return new WaitForSeconds(n);
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }


    


}
