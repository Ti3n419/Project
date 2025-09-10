using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : TI3NMono
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
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStartMess;
    [SerializeField] private GameObject gameOverMess;

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
        //scoreText.UpdateHighScore();
        StartGame();
        //UpdateHighScore();// Cập nhật hiển thị high score
        


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
            //UpdateHighScore();
            //scoreText.UpdateHighScore();
        }
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    private void UpdateScore()
    {
        score += Time.deltaTime * 15; 
        //scoreText.text = "Score:" + Mathf.FloorToInt(score);
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
        isGameOver = true;
        gameOverMess.SetActive(true);
        Time.timeScale = 0;
        CheckAndUpdateHighScore();// Kiểm tra và cập nhật high score khi game kết thúc
        StartCoroutine(ReloadScene());
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //public void ResetHighScore()
    //{
    //    PlayerPrefs.DeleteKey("HighScore");
    //    highScore = 0;
    //    scoreText.UpdateHighScore();
    //}
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStartGameMess();
        this.LoadGameOverMess();
        this.LoadScoreText();
        //this.LoadScoreText();
    }
    protected virtual void LoadStartGameMess() 
    {
        if(this.scoreTextObject!= null) return;
        this.scoreTextObject = GameObject.Find("Score");
    }
    protected virtual void LoadScoreText() 
    {
        if(this.gameStartMess!= null) return;
        this.gameStartMess = GameObject.Find("StartGameMess");
    }
    protected virtual void LoadGameOverMess() 
    {
        if(this.gameOverMess!= null) return ;
        this.gameOverMess = GameObject.Find("GameOverMess");
    }
   
}
