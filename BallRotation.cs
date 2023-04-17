using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
  //Variables
  public float marbleRadius;
  private Rigidbody body;
  private float mass = 1;


  private void Start(){
    marbleRadius = transform.localScale.x / 2;  //  This gets the radius of a ball at the beginning of the level
  }

    
  void Update(){
    Vector3 momentum = body.velocity * mass * Time.deltaTime;
    float distance = momentum.magnitude;
    float angle = distance * (180f / Mathf.PI) / marbleRadius; 
    transform.localRotation = Quaternion.Euler(Vector3.right * angle) * transform.localRotation;
  }

  void Awake () {
  body = GetComponent<Rigidbody>();
  body.useGravity = false;
	}
  
}
