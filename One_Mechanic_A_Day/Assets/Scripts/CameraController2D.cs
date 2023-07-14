using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// // The value you set for cameraOffset depends on how you want the camera to be positioned relative to the player. It determines the initial distance and angle between the player and the camera.

// Here's a breakdown of the cameraOffset vector:

// The x component controls the horizontal distance between the player and the camera.
// The y component controls the vertical distance between the player and the camera.
// The z component controls the depth or forward/backward offset from the player.
// You can experiment with different values to achieve the desired camera position. Here are a few examples:

// To have the camera directly behind the player, you can set cameraOffset to (0, 0, -10) or any other negative value for the z component.
// If you want the camera to be slightly above the player, you can set cameraOffset to (0, 2, -10) or adjust the y component as needed.
// For a side-scrolling game, you may want to set cameraOffset to (10, 0, -10) or adjust the x component to position the camera to the right of the player.
// Play around with different values until you achieve the desired camera position and adjust them to fit your game's specific requirements.
/// </summary>

public class CameraController2D : MonoBehaviour
{

    //player is going to be the positional component of your player GameObject.
    public Transform player;
    //cameraOffset is going to be the positional offset vector (the distance and angle) between your player and the camera.
    public Vector3 cameraOffset;
    // cameraSpeed is going to be the movement speed of the camera.
    public float cameraSpeed;
    public GameObject objectPoolManager;
    // private EnemyPool enemyPool;
    void Start()
    {
        // enemyPool = objectPoolManager.GetComponent<EnemyPool>();
        transform.position = player.position + cameraOffset;
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Vector3 finalPosition = player.position + cameraOffset;
        //Lerp = (final position = (lerpposition - playerposition) * cameraSpeed)
        Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
        transform.position = lerpPosition;
    }

    // private void CheckEnemyVisibileInCamera()
    // {
    //     Plane[] frustrumPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    //     foreach (GameObject obj in enemyPool.getObjectPool())
    //     {
    //         if (obj != null)
    //         {
    //             Bounds enemyBounds = obj.GetComponent<SpriteRenderer>().bounds;
    //             if (GeometryUtility.TestPlanesAABB(frustrumPlanes, enemyBounds))
    //             {
    //                 obj.GetComponent<SpriteRenderer>().enabled = true;
    //             }
    //             else
    //             {
    //                 obj.GetComponent<SpriteRenderer>().enabled = false;
    //             }
    //         }
    //     }
    // }

}
