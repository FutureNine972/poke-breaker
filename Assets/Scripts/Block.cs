using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gamestatus;
    Rigidbody2D myRigidBody2D;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gamestatus = FindObjectOfType<GameStatus>();
        
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
        
        if (tag == "Ending")
        {
            myRigidBody2D = GetComponent<Rigidbody2D>();
        }

    }

    private void Update()
    {
        if (tag == "Ending")
        {
            myRigidBody2D.velocity = new Vector2(0, -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (tag == "Breakable")
        {
            level.BlockDestroyed();
            gamestatus.AddToScore();
        }
        Destroy(gameObject);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

}