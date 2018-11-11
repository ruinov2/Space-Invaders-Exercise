using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb;
    private readonly float velY = 1f;
    private readonly float velX = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        rb.velocity = new Vector2 (velX, velY) * speed;

    }


}

