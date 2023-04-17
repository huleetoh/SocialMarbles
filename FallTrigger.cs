using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour
{
    public float threshold = -0.01f;
    public AudioSource fallAudio;
    private Vector3 lastCheckPoint;
    public float heightDrop;
   
    void Start(){
        lastCheckPoint = transform.position;
        heightDrop = 5;
    }

    void Update(){
        if(transform.position.y < threshold){
            fallAudio.Play();
            transform.position = lastCheckPoint + new Vector3(0, heightDrop, 0);
            
        }
    }
    
    
    
    /**
    // Use the code below when switching to a new scenelevel
    void Update(){
        if(transform.position.y < threshold && !audioLock){
            StartCoroutine(DelayedNextScene());
            audioLock = true;
        }    
    }

    IEnumerator DelayedNextScene()
     {
         //Play the clip once
         fallAudio.Play();
 
         //Wait until clip finish playing
         yield return new WaitForSeconds (fallAudio.clip.length - 0.82f);    
 
         //Load scene here
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }
     */
}
