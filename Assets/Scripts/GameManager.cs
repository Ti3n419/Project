using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : GameManagerCtrl
{
    public static System.Action OnGameStarted;//ds
    private static GameManager instance;
    public static GameManager Instance => instance;
    
    private float gameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    
    private float score = 0;
    public float Score => score;
    
    private float highScore = 0;
    public float HighScore => highScore;
    
    private bool isGameOver = false;
    public bool IsGameOver => isGameOver;// gameover flag

    private bool isStarting = false;

    
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
        LoadHighScore();// Tải high score khi khởi tạo
        //ResetHighScore();
    }
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    void Start()
    {
        StartGame();
    }
    void Update()
    {
        
        if (gameStartMess.activeSelf)
        {
            HandleStartInput();
        }
        if (!isGameOver && !isStarting)
        {
            UpdateGameSpeed();
            UpdateScore();
        }
    }
    protected virtual void LoadHighScore()  // Hàm tải high score từ PlayerPrefs
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
    }
    protected virtual void SaveHighScore()   // Hàm lưu high score vào PlayerPrefs
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void CheckAndUpdateHighScore()// Hàm kiểm tra và cập nhật high score
    {
        int currentScore = Mathf.FloorToInt(score);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();            
        }
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    private void UpdateScore()
    {
        score += Time.deltaTime * 15;         
    }
    private void StartGame()
    {
        Time.timeScale = 0;
        scoreTextObject.SetActive(false);
        gameStartMess.SetActive(true);
        gameOverMess.SetActive(false);
    }
    private void HandleStartInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStarting)
        {
            isStarting = true;
            StartCoroutine(DelayedStart());
        }
    }
    private IEnumerator DelayedStart()
    {
        OnGameStarted?.Invoke();//ds
        yield return new WaitForSecondsRealtime(0f);
        //ready mess...
        Time.timeScale = 1;
        scoreTextObject.SetActive(true);
        gameStartMess.SetActive(false);
        this.isStarting = false;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        isGameOver = true;
        gameOverMess.SetActive(true);
        CheckAndUpdateHighScore();// Kiểm tra và cập nhật high score khi game kết thúc
        //StartCoroutine(ReloadScene());
    }
    //private IEnumerator ReloadScene()
    //{
    //    yield return new WaitForSecondsRealtime(2f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
    public virtual void LoadMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        scoreText.UpdateHighScore();
    }


}
