using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacters : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject AiPrefab;
    [SerializeField] bool team = false;
    private GameObject leader;

    /// <summary>
    /// Spawn teams of characters at 2 opposite sides of the map
    /// </summary>
    private void Start()
    {
        if (GameManager.instance == null) return;
        GameManager gm = GameManager.instance;
        
        int members = team ? gm.blueTeamNumber : gm.redTeamNumber;


        for(int i=0; i< members; i++)
        {
            if (i == 0 && gm.playerTeam == team)
            {
                Debug.Log($"Player {gm.playerTeam} this team {team}");

                leader = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);
                leader.GetComponent<Character>().Team = team;
            }
                
            else if (i == 0)
            {
                leader= Instantiate(AiPrefab, spawnPoints[i].position, Quaternion.identity);
                leader.GetComponent<Character>().Team = team;
            }
            else
            {
                GameObject c = Instantiate(AiPrefab, spawnPoints[i].position, Quaternion.identity);
                if (i > 0)
                {
                    c.GetComponent<CharacterAI>().follow = leader.transform;
                    c.GetComponent<Character>().Team = team;
                }
            }
        }
    }
}
