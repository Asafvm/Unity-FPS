using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] AudioClip audioWin;
    [SerializeField] AudioClip audioLose;
    // Start is called before the first frame update
    void Start()
    {

        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void OnWinRequest()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        SoundManager.instance.PlaySound(audioWin,.005f);
    }

    public void OnLoseRequest()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        SoundManager.instance.PlaySound(audioLose, .005f);
    }

    public void OnResetRequest()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }
}
