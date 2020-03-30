using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoserCollider : MonoBehaviour
{
    Ball ball;

    [SerializeField] byte extraLives = 4;
    [SerializeField] TextMeshProUGUI extraLivesText;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        var loserColliderCount = FindObjectsOfType<LoserCollider>().Length;
        if (loserColliderCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SetExtraLivesText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (extraLives == 0)
        {
            SceneManager.LoadScene("Game Over");
            Destroy(gameObject);
        }
        else
        {
            extraLives--;
            ball.ResetPosition();
            SetExtraLivesText();
        }
    }

    public void SetExtraLivesText()
    {
        extraLivesText.text = $"Extra Lives: {extraLives}";
    }

    public void GiveExtraLife()
    {
        extraLives++;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}