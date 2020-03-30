using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCollider : MonoBehaviour
{

    Ball ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ball = FindObjectOfType<Ball>();
        SceneManager.LoadScene("Continue");
        ball.ResetPosition();

    }
}
