using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManagerCtrl : TI3NMono
{
    [SerializeField] protected GameObject scoreTextObject;
    [SerializeField] protected GameObject gameStartMess;
    [SerializeField] protected GameObject gameOverMess;
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStartGameMess();
        this.LoadGameOverMess();
        this.LoadScoreText();
    }

    protected virtual void LoadStartGameMess()
    {
        if (this.scoreTextObject != null) return;
        this.scoreTextObject = GameObject.Find("Score");
    }
    protected virtual void LoadScoreText()
    {
        if (this.gameStartMess != null) return;
        this.gameStartMess = GameObject.Find("StartGameMess");
    }
    protected virtual void LoadGameOverMess()
    {
        if (this.gameOverMess != null) return;
        this.gameOverMess = GameObject.Find("GameOverMess");
    }
}
