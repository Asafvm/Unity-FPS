using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainScreen, Game, Win, Lose }

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerTeam = true;
    public int redTeamNumber = 2;
    public int blueTeamNumber = 2;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        
        else
            Destroy(gameObject);
        
    }

    public void MainMenu()
    {
        SoundManager.instance.StopSound();
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayGame()
    {
        SoundManager.instance.StopSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public int Humanoids { get => redTeamNumber+blueTeamNumber;  }


    internal void SetOptions(bool playerTeam, int redTeamNumber, int blueTeamNumber)
    {
        this.playerTeam = playerTeam;
        this.redTeamNumber = redTeamNumber;
        this.blueTeamNumber = blueTeamNumber;
    }

}


