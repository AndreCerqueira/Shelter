using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The player game object that the camera should follow
    public GameObject player;

    // The maximum and minimum x positions that the camera should be allowed to have
    public float minX = 0;
    public float maxX = 10;

    void Update()
    {
        // Set the camera's position to the player's y position, plus an offset
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
