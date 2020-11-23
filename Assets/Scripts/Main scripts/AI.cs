using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D ball;
    float speed;
    Rigidbody2D rb;
    Transform ballTransform;

    //Перечисление возможных направлений движения для симуляции ввода
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
        if(PlayerInfo.player == 1)
        {
            if (ball.velocity.x > 0)
                SetVelocity();
            else if (rb.velocity != Vector2.zero)
            {
                dir = Direction.Zero;
                GetDirection(dir);
            }
        }
        else
        {
            if (ball.velocity.x < 0)
                SetVelocity();
            else if (rb.velocity != Vector2.zero)
            {
                dir = Direction.Zero;
                GetDirection(dir);
            }
        }
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.9f, 3.9f));
    }

    //Получает направление, попытка сделать симуляцию ввода для физического поведения такого же, как у игрока
    float t = 0;
    float GetDirection(Direction dir)
    {
        //Константа = 1/0.1f, 0.1 - время разгона в секундах
        const float accelerationConst = 10f;
        //Константа = 1/0.05f, 0.05 - время торможения в секундах
        const float decelerationConst = 20f;
        //Константы для плавности движения платформы

        if (dir == Direction.Positive && t >= 0)
            t += Time.deltaTime * accelerationConst;
        else if (dir == Direction.Negative && t <= 0)
            t -= Time.deltaTime * accelerationConst;
        else if (Mathf.Abs(t) > 0.1f)
            t -= Mathf.Sign(t) * Time.deltaTime * decelerationConst;
        else
            t = 0;
        Mathf.Clamp(t, -1, 1);
        return t;
    }

    //Установить скорость
    void SetVelocity()
    {
        Direction dir;
        if (ballTransform.position.y > transform.position.y)
            dir = Direction.Positive;
        else
            dir = Direction.Negative;
        float direction = GetDirection(dir);
        rb.velocity = Vector2.up * speed * direction;
    }
}
