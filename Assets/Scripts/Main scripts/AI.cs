﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D ball;
    float speed;
    Rigidbody2D rb;
    Transform ballTransform;

    enum Direction
    {
        Positive,
        Negative,
        Zero
    }

    void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        speed = GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed;
        rb = GetComponent<Rigidbody2D>();
        ballTransform = ball.gameObject.transform;
    }


    void Update()
    {
        Direction dir;
        if (ball.velocity.x > 0)
        {
            if (ballTransform.position.y > transform.position.y)
                dir = Direction.Positive;
            else
                dir = Direction.Negative;
            float direction = GetDirection(dir);
            rb.velocity = Vector2.up * speed * direction;
        }
        else if(rb.velocity != Vector2.zero)
        {
            dir = Direction.Zero;
            GetDirection(dir);
        }
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.9f, 3.9f));
    }

    float t = 0;
    float GetDirection(Direction dir)
    {
        const float accelerationConst = 10f;
        const float decelerationConst = 20f;

        if (dir == Direction.Positive && t >= 0)
            t += Time.deltaTime * accelerationConst;
        else if (dir == Direction.Negative && t <= 0)
            t -= Time.deltaTime * accelerationConst;
        else if (Mathf.Abs(t) > 0.1f)
            t -= Mathf.Sign(t) * Time.deltaTime * decelerationConst;
        else
            t = 0;
        Mathf.Clamp(t, -1, 1);
        Debug.Log(t);
        return t;
    }
}
