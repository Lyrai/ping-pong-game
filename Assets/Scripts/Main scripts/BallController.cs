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
        angle = Random.Range(-25, 25);
        SetDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Скорость игрока в момент удара влияет на угол отскока мяча
            angle = 180 - (angle - collision.gameObject.GetComponent<Rigidbody2D>().velocity.y * 3);
            SetDirection(angle * Mathf.Deg2Rad);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            angle = 360 - angle;
            SetDirection(angle * Mathf.Deg2Rad);
        }
    }

    //Устанавливает случайное направление в начале раунда
    private void SetDirection()
    {
        angle = Random.Range(-25, 25);
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        rb.velocity = new Vector2(x, y) * speed;
    }

    //Устанавливает направление по заданному углу
    private void SetDirection(float an)
    {
        float y = Mathf.Sin(an);
        float x = Mathf.Cos(an);
        rb.velocity = new Vector2(x, y) * speed;
    }

    private void Score ()
    {
        transform.position = Vector2.zero;
        SetDirection();
    }
}
