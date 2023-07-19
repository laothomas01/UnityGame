using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// We will have camera follow the player with interpolated movement
/// </summary>
public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Vector3 offsetPositon;
    [SerializeField] private float cameraMoveSpeed;
    void Start()
    {
        transform.position = playerPrefab.transform.position + offsetPositon;
    }

   
    // Update is called once per frame
    void Update()
    {
        followPlayer(Time.deltaTime);   
    }
    private void followPlayer(float dt)
    {
        Vector3 finalPosition = playerPrefab.transform.position + offsetPositon;
        Vector3 lerpPosition = Vector3.Lerp(transform.position,finalPosition,cameraMoveSpeed * dt);
        transform.position = lerpPosition;
    }
}
