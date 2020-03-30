using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameStatus gamestatus;
    LoserCollider lives;
    Ball ball;

    private void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
        lives = FindObjectOfType<LoserCollider>();
        ball = FindObjectOfType<Ball>();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (lives != null) 
        {
            lives.GiveExtraLife();
            
            lives.SetExtraLivesText();
        }

        if (ball != null)
        {
            ball.ResetPosition();
        }
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        gamestatus.GameReset();
        lives.Destroy();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        ball.ResetPosition();
    }

}