using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float y = Random.Range(-0.35f, 0.35f);
        float x = Mathf.Sqrt(1 - y * y);
        rb.velocity = new Vector2(x, y) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        if(collision.gameObject.CompareTag("Wall"))
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
    }
}
