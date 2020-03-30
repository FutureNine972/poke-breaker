using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBump : MonoBehaviour
{
    [SerializeField] AudioClip wallSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(wallSound, Camera.main.transform.position);
    }
}
