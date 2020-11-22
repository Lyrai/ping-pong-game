using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    float angle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        angle = Random.Range(-25, 25) * Mathf.Deg2Rad;
        SetDirection(angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(, rb.velocity.y);
        }
        if(collision.gameObject.CompareTag("Wall"))
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
    }

    private void SetDirection(float an)
    {
        float y = Mathf.Sin(an);
        float x = Mathf.Cos(an);
        rb.velocity = new Vector2(x, y) * speed;
    }
}
