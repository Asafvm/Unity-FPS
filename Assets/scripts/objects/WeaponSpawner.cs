using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] Weapon weaponPrefab;
    [SerializeField] GameObject[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {

        int numberOfAgents = FindObjectOfType<GameManager>().Humanoids;
        int loc = Mathf.FloorToInt(Random.Range(0, spawnLocations.Length - numberOfAgents));
        Debug.Log($"agents: {numberOfAgents} - loc: {loc}");
        for (int i = loc; i < loc + numberOfAgents; i++)
        {
            if (spawnLocations[i].transform.childCount == 0)
            {
                Instantiate(weaponPrefab, spawnLocations[i].transform.position, Quaternion.identity, spawnLocations[i].transform);
            }

        }

        foreach (GameObject location in spawnLocations)
        {
            if (location.transform.childCount == 0)
                Destroy(location.gameObject);


        }
    }
}

    
