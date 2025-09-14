using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreText : TI3NMono
{
    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected TextMeshProUGUI highScoreText;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScoreText();
        this.LoadHighScoreText();
    }
    protected virtual void LoadScoreText()
    {
        if (this.scoreText != null) return;
        this.scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadHighScoreText()
    {
        if (this.highScoreText != null) return;
        this.highScoreText = transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void FixedUpdate()
    {
        Debug.Log(GameManager.Instance.Score);
        if (this.scoreText != null)
            scoreText.text = "Score:" + Mathf.FloorToInt(GameManager.Instance.Score);

        this.UpdateHighScore();
    }
    public void UpdateHighScore()  // Hàm cập nhật hiển thị high score trên UI
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + Mathf.FloorToInt(GameManager.Instance.HighScore);
        }
    }
}
