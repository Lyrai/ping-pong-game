using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWallController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            Score();
    }

    void Score()
    {
        Debug.Log("Score");
    }
}
