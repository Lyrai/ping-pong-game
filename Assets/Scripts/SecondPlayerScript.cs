using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerScript : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    void Update()
    {
        int direction = GetDirection();
        transform.Translate(Vector2.up * speed * direction * Time.deltaTime);
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3f, 3f));
    }

    int GetDirection()
    {
        if (Input.GetKey("up"))
            return 1;
        else if (Input.GetKey("down"))
            return -1;
        else
            return 0;

    }
}
