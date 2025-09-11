using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public virtual void LoadGame() 
    {
        SceneManager.LoadScene("Game");
    }
    public virtual void ExitGame() 
    {
        Application.Quit();
    } 
}
