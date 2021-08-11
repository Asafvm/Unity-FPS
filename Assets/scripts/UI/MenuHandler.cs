using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] bool playerTeam = true;
    [SerializeField] TextMeshProUGUI blueTeam;
    [SerializeField] TextMeshProUGUI redTeam;
    [SerializeField] Button redButton;
    [SerializeField] Button blueButton;
    private int redTeamNumber = 2;
    private int blueTeamNumber = 2;


    private void Start()
    {
        SetTeam(playerTeam);
            
    }

    private void SetTeam(bool playerTeam)
    {
        if (playerTeam)
        {
            blueButton.interactable = false;
            redButton.interactable = true;
        }
        else
        {
            blueButton.interactable = true;
            redButton.interactable = false;
        }
    }

    public void SaveOptions()
    {
        FindObjectOfType<GameManager>().SetOptions(playerTeam, redTeamNumber, blueTeamNumber);
    }

    public void StartGame()
    {
        FindObjectOfType<GameManager>().PlayGame();
    }
    public void ChooseTeam(bool team)
    {
        playerTeam = team;
        SetTeam(team);

    }

    public void IncreaseRedTeamMembers()
    {
        redTeamNumber = (Mathf.Clamp(int.Parse(redTeam.text) + 1, 2, 5));
        redTeam.text = redTeamNumber.ToString();
    }

    public void IncreaseBlueTeamMembers()
    {
        blueTeamNumber = (Mathf.Clamp(int.Parse(blueTeam.text) + 1, 2, 5));
        blueTeam.text = blueTeamNumber.ToString();
    }

    public void DecreaseRedTeamMembers()
    {
        redTeamNumber = (Mathf.Clamp(int.Parse(redTeam.text) - 1, 2, 5));
        redTeam.text = redTeamNumber.ToString();
    }

    public void DecreaseBlueTeamMembers()
    {
        blueTeamNumber = (Mathf.Clamp(int.Parse(blueTeam.text) - 1, 2, 5));
        blueTeam.text = blueTeamNumber.ToString();
    }
}
