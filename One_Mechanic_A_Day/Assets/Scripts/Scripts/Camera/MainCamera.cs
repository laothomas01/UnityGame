using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// - implement performance enhances, or camera features in this class
/// </summary>
public class MainCamera : MonoBehaviour
{
    [SerializeField]
    // private GameObject playerPrefab;
    Transform player;
    [SerializeField]
    private Vector3 offsetPositon;
    [SerializeField] private float cameraMoveSpeed;

    [SerializeField]
    bool LERP = false;
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().transform;
        transform.position = player.position + offsetPositon;
        // transform.position = playerPrefab.transform.position + offsetPositon;
    }


    // Update is called once per frame
    void Update()
    {
        followPlayer(Time.deltaTime);
    }
    private void followPlayer(float dt)
    {
        Vector3 finalPosition = player.position + offsetPositon;
        if (LERP)
        {
            Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraMoveSpeed * dt);
            transform.position = lerpPosition;
        }
        else
        {
            transform.position = finalPosition;
        }
    }
}
