using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : TI3NMono
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayHurtClip();
            GameManager.Instance.GameOver();
        }
    }
}
