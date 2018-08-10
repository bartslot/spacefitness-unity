using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        
public class CameraMovement : MonoBehaviour 
{
    Transform playerTransform;
         
    Vector3 cameraOrientationVector = new Vector3 (0.0f, 1.8f, -5f);
             
 
	void Start () 
    {
    	playerTransform = GameObject.Find ("Player").transform;
    }
            
    void LateUpdate () 
    {
    	transform.position = playerTransform.position + cameraOrientationVector;        
    }
}
