using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{
    public PlayerMovement player;
    public Rigidbody2D rb;

    public float speed = 3f;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the background in the opposite direction of the camera
        rb.velocity = new Vector2(-player.horizontalInput * speed, rb.velocity.y);
    }

}