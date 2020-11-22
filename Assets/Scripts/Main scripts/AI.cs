using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D ball;
    float speed;
    void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
        speed = GameObject.FindWithTag("Player").GetComponent<PlayerController>().speed;
    }


    void Update()
    {
        
    }
}
