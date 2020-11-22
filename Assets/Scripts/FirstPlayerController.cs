using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = GetDirection();
        rb.velocity = Vector2.up * speed * direction * Time.deltaTime;

        transform.Translate(Vector2.up * speed * direction * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3f, 3f));
    }

    [SerializeField]
    string posDirectionButton;
    [SerializeField]
    string negDirectionButton;
    float t = 0;
    const float accelerationConst = 1 / 0.2f;
    const float decelerationConst = 1 / 0.1f;
    float GetDirection()
    {

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
