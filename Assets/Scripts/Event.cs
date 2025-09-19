using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : TI3NMono
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            AudioManager.Instance.PlayHurtClip();
            GameManager.Instance.GameOver();
        }
    }
}
