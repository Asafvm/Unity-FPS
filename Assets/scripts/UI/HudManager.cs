using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI redTeamText;
    [SerializeField] TextMeshProUGUI blueTeamText;
    [SerializeField] TextMeshProUGUI notifications;
    [SerializeField] GameObject touchUI;
    [SerializeField] private GameObject uiCenter;
    [SerializeField] private GameObject uiGunaim;
    [SerializeField] GameObject weaponButtons;
    private Character character;
    private int redTeam, blueTeam;

    private void Start()
    {
        if (GameManager.instance == null) return;
        character = GetComponentInParent<Character>();
        notifications.text = "";
        weaponButtons.SetActive(false);
        uiGunaim.SetActive(false);
        uiCenter.SetActive(true);
        redTeam = GameManager.instance.redTeamNumber;
        blueTeam = GameManager.instance.blueTeamNumber;
        
        //activate move input if needed
        if(SystemInfo.deviceType == DeviceType.Handheld)
            touchUI.SetActive(true);
        else
            touchUI.SetActive(false);

        UpdateUI();
    }


    public void OnWeaponPickup()
    {
        weaponButtons.SetActive(true);
        uiGunaim.SetActive(true);
        uiCenter.SetActive(false);
    }

    public void OnDeath(bool team, bool isPlayer)
    {

        StartCoroutine(NotifyDeath(team));

        if (team)
            blueTeam--;
        else
            redTeam--;
        UpdateUI();

 

        if (blueTeam <= 0)          //blue team lost
        {
            if (character.Team)      //player is blue
                StartCoroutine(ShowEndMenu(false));
            else                    //player is red
                StartCoroutine(ShowEndMenu(true));
        }

        if (redTeam <= 0)          //red team lost
        {
            if (character.Team)      //player is blue
                StartCoroutine(ShowEndMenu(true));
            else                    //player is red
                StartCoroutine(ShowEndMenu(false));
        }

        if (isPlayer)               //player died before game ended
            StartCoroutine(ShowEndMenu(false));
    }

    private IEnumerator ShowEndMenu(bool win)
    {
        yield return new WaitForSeconds(3);
        if(win)
            FindObjectOfType<PanelManager>().OnWinRequest();
        else
            FindObjectOfType<PanelManager>().OnLoseRequest();
    }

    private void UpdateUI()
    {
        redTeamText.text = redTeam.ToString();
        blueTeamText.text = blueTeam.ToString();
    }

    private IEnumerator NotifyDeath(bool team)
    {
        if (team)
            notifications.text = "Blue player was killed";
        else
            notifications.text = "Red player was killed";

        yield return new WaitForSeconds(2f);
        notifications.text = "";

    }
}
