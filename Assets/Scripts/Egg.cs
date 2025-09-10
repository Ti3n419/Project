using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : TI3NMono
{
    [SerializeField] private GameObject player;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    protected virtual void LoadPlayer() 
    {
        if(this.player!= null) return;
        this.player = GameObject.Find("Player");
    }
    public void HideEggShowPlayer() 
    {
        AudioManager.Instance.PlayCrackEggClip();
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
