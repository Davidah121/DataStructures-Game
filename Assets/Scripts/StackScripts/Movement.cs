﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    [SerializeField] private float speed = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Controller.c.playing)
        {
            Vector2 MoveForce = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.A))
            {
                MoveForce.x = -speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveForce.x = speed;
            }

            if (Input.GetKey(KeyCode.W))
            {
                MoveForce.y = speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveForce.y = -speed;
            }

            rb2d.velocity = MoveForce;
        }
    }
}
