using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = GetDirection();
        rb.velocity = Vector2.up * speed * direction;
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.9f, 3.9f));
    }


    //Кнопки задаются в инспекторе для управления двумя игроками одновременно
    [SerializeField]
    //Кнопка положительного направления
    string posDirectionButton;
    [SerializeField]
    //Кнопка отрицательного направления
    string negDirectionButton;
    float t = 0;

    //Смотри AI.GetDirection
    float GetDirection()
    {
        const float accelerationConst = 10f;
        const float decelerationConst = 20f;
        if (Input.GetKey(posDirectionButton) && t >= 0)
            t += Time.deltaTime * accelerationConst;
        else if (Input.GetKey(negDirectionButton) && t <= 0)
            t -= Time.deltaTime * accelerationConst;
        else if (Mathf.Abs(t) > 0.1f)
            t -= Mathf.Sign(t) * Time.deltaTime * decelerationConst;
        else 
            t = 0;
        Mathf.Clamp(t, -1, 1);
        return t;
    }
}
