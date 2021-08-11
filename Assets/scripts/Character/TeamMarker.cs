using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMarker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = GetComponentInParent<Character>().Team ? Color.blue : Color.red;
    }

    public void OnTeamChange(bool team)
    {
        Debug.Log($"Team changed :: team = {team}");
        GetComponent<MeshRenderer>().material.color = team ? Color.blue : Color.red;
    }

}
