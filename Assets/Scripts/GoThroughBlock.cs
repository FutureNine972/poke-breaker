using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoThroughBlock : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;

    Level level;
    GameStatus gamestatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gamestatus = FindObjectOfType<GameStatus>();
        level.CountBreakableBlocks();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("It Works");
        DestroyBlock();
    }
    
    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BlockDestroyed();
        gamestatus.AddToScore();
        Destroy(gameObject);
    }

}

