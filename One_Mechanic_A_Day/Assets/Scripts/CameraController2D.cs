using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles updates to the camera
/// </summary>
public class CameraController2D : MonoBehaviour
{
    //player is going to be the positional component of your player GameObject.
public Transform player;
   //cameraOffset is going to be the positional offset vector (the distance and angle) between your player and the camera.
public Vector3 cameraOffset;
// cameraSpeed is going to be the movement speed of the camera.
public float cameraSpeed;
void Start()
{
    // cameraSpeed = 0.1f;
    // cameraOffset =  new Vector3(0, 0, -1);
    transform.position = player.position + cameraOffset;
}

private void FixedUpdate() {
Vector3 finalPosition = player.position + cameraOffset;
//Lerp = (final position = (lerpposition - playerposition) * cameraSpeed)
Vector3 lerpPosition = Vector3.Lerp(transform.position,finalPosition,cameraSpeed);
transform.position = lerpPosition;
}

   
}
